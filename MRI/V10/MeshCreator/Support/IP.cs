using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AFI = AForge.Imaging;
using AForge;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using Accord.Imaging;

namespace MeshCreator
{
	static class IP
	{
		//---------------------------------------------------------------------------
		public static void Threshold(UmImage image, ProcessItem pi)
		{
			AFI.UnmanagedImage ui = image.AFIUnmanagedImage;
			long npix = ui.Width * ui.Height;

			unsafe
			{
				byte* p = (byte*)(void*)ui.ImageData;
				int nOffset = ui.Stride - ui.Width;

				for (int y = 0; y < ui.Height; ++y)
				{
					for (int x = 0; x < ui.Width; ++x)
					{
						if ((p[0] < pi.th_min) || (p[0] > pi.th_max))
						{
							p[0] = 0;
						}
						else
						{
							p[0] = 255;
						}
						p++;
					}
					p += nOffset;
				}
			}
		}
		//---------------------------------------------------------------------------
		public static void GaussianSharpen(UmImage image)
		{
			int[,] kernel = {
            { 0, -2,  0 },
            { -2,  11,  -2},
            {  0, -2, 0 } };
			Convolution filter = new Convolution(kernel);
			filter.Divisor = 3;
			filter.ApplyInPlace(image.AFIUnmanagedImage);
		}
		//---------------------------------------------------------------------------
		public static void Invert(UmImage image)
		{
			Invert filter = new Invert();
			filter.ApplyInPlace(image.AFIUnmanagedImage);
		}
		//---------------------------------------------------------------------------
		public static void CanvasMove(UmImage image, IntPoint p)
		{
			CanvasMove filter = new CanvasMove(p, (byte)0);
			filter.ApplyInPlace(image.AFIUnmanagedImage);

		}
		//---------------------------------------------------------------------------
		public static void GrowShrink(UmImage image, ProcessItem pi)
		{
			AFI.UnmanagedImage iu = image.AFIUnmanagedImage;
			IInPlaceFilter f;

			switch (pi.m_pro_type)
			{
				case ProcessType.Dilatation:
					f = new Dilatation(pi.m_element);
					f.ApplyInPlace(iu);
					break;
				case ProcessType.Erosion:
					f = new Erosion(pi.m_element);
					f.ApplyInPlace(iu);
					break;
				case ProcessType.Opening:
					f = new Opening(pi.m_element);
					f.ApplyInPlace(iu);
					break;
				case ProcessType.Closing:
					f = new Closing(pi.m_element);
					f.ApplyInPlace(iu);
					break;
				default:
					break;
			}
		}
		//---------------------------------------------------------------------------
		public static void HistogramEq(UmImage image)
		{
			HistogramEqualization filter = new HistogramEqualization();
			filter.ApplyInPlace(image.AFIUnmanagedImage);
		}
		//---------------------------------------------------------------------------
		public static void MedianFilter(UmImage image)
		{
			Median filter = new Median();
			filter.ApplyInPlace(image.AFIUnmanagedImage);
		}
		//---------------------------------------------------------------------------
		public static void ConservativeSmooth(UmImage image)
		{
			ConservativeSmoothing filter = new ConservativeSmoothing();
			filter.ApplyInPlace(image.AFIUnmanagedImage);
		}
		//---------------------------------------------------------------------------
		public static void HarrisCornersDetect(UmImage image)
		{
			double sigma = (double)1.4f;
			float k = 0.04f;
			float threshold = 20000.0f;

			// Create a new Harris Corners Detector using the given parameters
			HarrisCornersDetector harris = new HarrisCornersDetector(k);
			harris.Measure = HarrisCornerMeasure.Harris;
			harris.Threshold = threshold;
			harris.Sigma = sigma;

			// Create a new AForge's Corner Marker Filter
			CornersMarker corners = new CornersMarker(harris, Color.Red);

			// Apply the filter and display it on a picturebox
			corners.ApplyInPlace(image.AFIUnmanagedImage);
		}
		//---------------------------------------------------------------------------
		public static void GCCollect()
		{
			GC.Collect();
		}
		//---------------------------------------------------------------------------
		public static void MRIMessageBox(string msg)
		{
			MessageBox.Show(msg, "MRI", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		//---------------------------------------------------------------------------
		private static bool IsInRange(MyPoint p, FloodFillInfo ffi, byte[,] pixels)
		{
			if ((pixels[p.x, p.y] >= ffi.m_min) && (pixels[p.x, p.y] <= ffi.m_max))
			{
				return true;
			}else{
				return false;
			}
		}
		//---------------------------------------------------------------------------
		public static int FloodFill(FloodFillInfo ffi)
		{
			ByteImage bi = ffi.m_bi;
			MySize s = bi.Size;
			MyPoint p = ffi.m_start_point;
			byte[,] pixels = bi.GetPixels();

			if (!IsInRange(p, ffi, pixels))
				return 0;//Can't fill

			byte[,] objmask = bi.GetObjectMask();
			Queue<MyPoint> q = new Queue<MyPoint>(200);
			MyPoint top, right, bottom, left;
			int len = 0;
			s.Width--;

			q.Enqueue(p);

			while (q.Count != 0)
			{
				p = q.Dequeue();
				//if (bi.GetPix(p.x, p.y) != tar_col)
				if (!IsInRange(p, ffi, pixels))
					continue;

				right = p;
				//scann right
				do
				{
					//bi.SetPix(right.x, right.y, fill_col);
					pixels[right.x, right.y] = ffi.m_fillcol;
					objmask[right.x, right.y] = ffi.m_obj_fill;
					len++;

					//add top
					top = right; top.y--;
					if (top.y >= 0)
					{
						//if (bi.GetPix(top.x, top.y) == tar_col)
						if (IsInRange(top, ffi, pixels))
							q.Enqueue(top);
					}

					//add bottom
					bottom = right; bottom.y++;
					if (bottom.y < s.Height)
					{
						//if (bi.GetPix(bottom.x, bottom.y) == tar_col)
						if (IsInRange(bottom, ffi, pixels))
							q.Enqueue(bottom);
					}

					if (right.x == s.Width)
						break;
					right.x++;
					//} while (bi.GetPix(right.x, right.y) == tar_col);
				} while (IsInRange(right, ffi, pixels));

				//scann left
				left = p; left.x--;
				if (left.x >= 0)
				{
					//while (bi.GetPix(left.x, left.y) == tar_col)
					while (IsInRange(left, ffi, pixels))
					{
						//bi.SetPix(left.x, left.y, fill_col);
						pixels[left.x, left.y] = ffi.m_fillcol;
						objmask[left.x, left.y] = ffi.m_obj_fill;
						len++;

						//add top
						top = left; top.y--;
						if (top.y >= 0)
						{
							//if (bi.GetPix(top.x, top.y) == tar_col)
							if (IsInRange(top, ffi, pixels))
								q.Enqueue(top);
						}

						//add bottom
						bottom = left; bottom.y++;
						if (bottom.y < s.Height)
						{
							//if (bi.GetPix(bottom.x, bottom.y) == tar_col)
							if (IsInRange(bottom, ffi, pixels))
								q.Enqueue(bottom);
						}

						left.x--;
						if (left.x < 0)
							break;
					}
				}
			}

			if (len > 5)
			{
				MRIObject obj = bi.GetObjectByFill(ffi.m_obj_fill);
				if (obj==null)
				{
					//No object with this color
                    obj = bi.AddObject(len, ffi.m_obj_fill);
				} else{
					//There is a object with this color so increase area of existing object
					obj.IncreaseArea(len);
				}

                MarkBoarders(objmask, obj, ffi);
				return len;
			}

			return 0;
		}
        //--------------------------------------------------------------------------------------
        //private static void SetBodColor(byte[,] objmask, int x, int y, byte bc, FloodFillInfo ffi)
        //{
        //    int xx;
            
        //    if (objmask[x, y] != ffi.m_obj_fill)
        //        xx = 0;

        //    objmask[x, y] = bc;

        //}   
        //--------------------------------------------------------------------------------------
        private static void MarkBoarders(byte[,] objmask, MRIObject obj, FloodFillInfo ffi)
		{
			int x, y;
			MySize s = ffi.m_bi.Size;
			byte bc = ColorMarshal.GetBodFromFill(ffi.m_obj_fill);
			byte val1, val2;
            //int len = 0;

			//Left to Right scan
			for (x = 1; x < s.Width; ++x)
			{
			    for (y = 0; y < s.Height; ++y)
			    {
			        val1 = objmask[x - 1, y];
			        val2 = objmask[x, y];
			        if (val2 == ffi.m_obj_fill)
			        {
			            if ((val1 != ffi.m_obj_fill) && (val1 != bc))
			            {//Ditect left face boader
			                objmask[x, y] = bc;
                            //SetBodColor(objmask, x, y, bc, ffi);
			            }
			        }else{
			            if ((val1 == ffi.m_obj_fill) && (val2 != bc))
			            {//Ditect right face boader
			                objmask[x - 1, y] = bc;
                            //SetBodColor(objmask, x - 1, y, bc, ffi);
                            //len++;
			            }
			        }
			    }
			}
			//Top to Down scan
			for (y = 1; y < s.Height; ++y)
			{
			    for (x = 0; x < s.Width; ++x)
			    {
			        val1 = objmask[x, y - 1];
			        val2 = objmask[x, y];
			        if (val2 == ffi.m_obj_fill)
			        {
			            if ((val1 != ffi.m_obj_fill) && (val1 != bc))
			            {//Ditect top face boader
			                objmask[x, y] = bc;
                            //SetBodColor(objmask, x, y, bc, ffi);
			            }
			        }else{
			            if ((val1 == ffi.m_obj_fill) && (val2 != bc))
			            {//Ditect bottum face boader
			                objmask[x, y - 1] = bc;
                            //SetBodColor(objmask, x, y - 1, bc, ffi);
                            //len++;
			            }
			        }
			    }
			}

            //obj.IncreaseArea(len);
		}
	}
}