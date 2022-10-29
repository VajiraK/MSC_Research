using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using AFI = AForge.Imaging;
using AForge.Imaging.Filters;

namespace MeshCreator
{
	public class UmImage
	{
		private AFI.UnmanagedImage m_afum_image;//8bppIndexed unmanaged image
		//---------------------------------------------------------------------------
		public UmImage(Bitmap bmp)
		{
			AFI.UnmanagedImage tmp = AFI.UnmanagedImage.FromManagedImage(bmp);

			if (tmp.PixelFormat != PixelFormat.Format8bppIndexed)
			{
				Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
				m_afum_image = filter.Apply(tmp);
				tmp.Dispose();
			}else{
				m_afum_image = tmp;
			}
		}
		//---------------------------------------------------------------------------
		public static UmImage FromFile(string path) 
		{
			Bitmap bmp = new Bitmap(path);
			UmImage um = new UmImage(bmp);
			bmp.Dispose();
			return um;
		}
		//---------------------------------------------------------------------------
		private UmImage(){}
		//---------------------------------------------------------------------------
		public UmImage Clone()
		{
			UmImage tmp = new UmImage();
			tmp.m_afum_image = this.m_afum_image.Clone();
			return tmp;
		}
		//---------------------------------------------------------------------------
		public Bitmap ToBitmap()
		{
			return m_afum_image.ToManagedImage();
		}
		//---------------------------------------------------------------------------
		public AFI.UnmanagedImage AFIUnmanagedImage 
		{
			get { return m_afum_image; }
		}
		//---------------------------------------------------------------------------
		public MySize GetSize()
		{
			MySize s;
			s.Height = m_afum_image.Height;
			s.Width = m_afum_image.Width;
			return s;
		}
		//---------------------------------------------------------------------------
		public byte GetPix(MyPoint p)
		{
			int i = (p.y * m_afum_image.Stride) + p.x;
			unsafe
			{
				byte* val = (byte*)(void*)m_afum_image.ImageData;
				return val[i];
			}
		}
		//---------------------------------------------------------------------------
		public void Dispose()
		{
			m_afum_image.Dispose();
		}
		//public void SetPix(MyPoint p, FloodFillInfo ffi)
		//{
		//    int i = (p.y * m_afum_image.Stride) + p.x;
		//    unsafe
		//    {
		//        byte* val = (byte*)(void*)m_afum_image.ImageData;
		//        val[i] = ffi.m_fillcol;
		//    }
		//}
		//---------------------------------------------------------------------------
		//public bool IsInRange(MyPoint p, FloodFillInfo ffi)
		//{
		//    int i = (p.y * m_afum_image.Stride) + p.x;

		//    unsafe
		//    {
		//        byte* arr = (byte*)(void*)m_afum_image.ImageData;
		//        byte v = arr[i];
		//        if ((arr[i] >= ffi.m_min) && (arr[i] <= ffi.m_max))
		//        {
		//            return true;
		//        }else{
		//            return false;
		//        }
		//    }
		//}
	}
}
