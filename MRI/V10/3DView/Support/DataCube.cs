using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace _3DView
{
	public enum ColIndex
	{
		BLACK_COLOR = 0,
		WHITE_COLOR = 1,
		BORDER_COLOR = 2,
		OBJ_COL_1 = 3,//Starting m_fill_col_index value of PictureBoxEx
		OBJ_COL_2 = 4,
		OBJ_COL_3 = 5,
		OBJ_COL_4 = 6,
		OBJ_COL_5 = 7,
		OBJ_COL_6 = 8,
		OBJ_COL_7 = 9,
		OBJ_COL_8 = 10,
		OBJ_COL_9 = 11,
		OBJ_COL_10 = 12,
		OBJ_COL_11 = 13,
		OBJ_COL_12 = 14
	}
	//##########################################################################################
	public struct CrossViewData
	{
		public Bitmap  image;
		public Point ori_ap;//Original 3D file axis point
		public Point cur_ap;//Currently using axis point (Set using controller)
	}
	//##########################################################################################
	public struct MySize
	{
		public int Width;
		public int Height;
	}
	//##########################################################################################
	public class DataCube
	{
		private References m_r;
		private List<DataSlide> m_Slides;
		private MySize m_size;
		//--------------------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
		}
		//--------------------------------------------------------------------------------------
		public bool LoadDataFile(string path)
		{
			int nslides, blen, nbra,nobj, p;
			byte col;
			short x, y;
			CrossViewData cdata;

			//try
			{
			    using (FileStream fs = new FileStream(path, FileMode.Open))
			    {
			        using (BinaryReader br = new BinaryReader(fs))
			        {
						DataSlide ds;
						Branch bra;
						MRIObject obj;
						//Check singnature
						byte[] sng1 = { 86, 65, 74, 73, 82, 65, 45, 77, 82, 73, 67, 85, 66, 69, 45, 86, 56 };
						byte[] sng2 = br.ReadBytes(17);
						for (int k = 0; k < 17; k++)
						{
							if (sng1[k]!=sng2[k])
							{
								MessageBox.Show("Invalid singnature!", "MRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return false;
							}
						}
						m_size.Width = br.ReadInt32();
						m_size.Height = br.ReadInt32();
						nslides = br.ReadInt32();//No of slides
						//Read axis point
						cdata.ori_ap = new Point(br.ReadInt32(), br.ReadInt32());
						cdata.cur_ap = cdata.ori_ap;
						//Read midle crossection image *******************
						int i = m_size.Width * m_size.Height;
						int nOffset, c = 0;
						byte[] arr = br.ReadBytes(i);
						cdata.image = new Bitmap(m_size.Width, m_size.Height);
						BitmapData bmData = cdata.image.LockBits(new Rectangle(0, 0, m_size.Width, m_size.Height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
						nOffset = bmData.Stride - m_size.Width * 3;
						unsafe
						{
							byte* pdata = (byte*)(void*)bmData.Scan0;

							for (i = 0; i < m_size.Height; i++)
							{
								for (int j = 0; j < m_size.Width; j++)
								{
                                    if (arr[c++]!=0)
                                        pdata[0] = pdata[1] = pdata[2] = 255;
									pdata += 3;
								}
								pdata += nOffset;
							}
						}
						arr = null;
						cdata.image.UnlockBits(bmData);
						m_r.m_controller.SetCrossImage(cdata);
						//Read midle crossection image *******************

						if (nslides > 320)
						{
							MessageBox.Show("Too many slides!", "MRI", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}

						m_Slides = new List<DataSlide>(nslides);

						for (i = 0; i < nslides; i++)
						{//***************** Reading slides *****************
							nobj = br.ReadByte();//Get number of objects
							ds = new DataSlide(nobj);
							for (int j = 0; j < nobj; j++)
							{//Reading objects ****************************
								nbra = br.ReadInt32();//Get number of branches
								obj = new MRIObject(nbra);

								for (int k = 0; k < nbra; k++)
								{//Reading branches ****************************
									blen = br.ReadInt32();//Get branch point count 
									bra = new Branch(blen);
									p = 0;

									while (blen != p)
									{//Reading vertexes *************************
										x = br.ReadInt16();//2 Bytes(short)
										y = br.ReadInt16();//2 Bytes(short)
										col = br.ReadByte();//1 Bytes
										bra.AddVertext(x, y, col);
										p++;
									}//Reading vertexes *************************
									obj.AddBranch(bra);
								}//Reading branches ****************************
								ds.AddObject(obj);
							}//Reading objects ****************************
							m_Slides.Add(ds);
						}//***************** Reading slides *****************
					}
				}
			}
            //catch (Exception)
            //{
            //    return false;
            //}
			
			return true;
		}
        //--------------------------------------------------------------------------------------
        //public int RenderDataCube(Point ap, int scale)
        // {
        //     DataSlide sl;
        //     MRIObject obj;
        //     Branch bra;
        //     MyVertex v1 = null;
        //     MyVertex v2 = null;
        //     MyVertex v3 = null;

        //     int nbra, nobj;
        //     float fscale = 100.0f / scale;
        //     int len, ns = m_Slides.Count;

        //     //Z scale
        //     float zstep = 1.0f / fscale;
        //     float z = (ns / 2) * zstep * (-1);

        //     int dls = GL.GenLists(1);
        //     GL.NewList(dls, ListMode.Compile);
        //     GL.Color3(Color.Gray);

        //     MyTexture tx = MyTexture.LoadTexture(@"Images/t1.png");
        //     tx.MakeCurrent();

        //     for (int i = 0; i < ns; i++)
        //     {//************* Go through all the slides **********

        //         sl = m_Slides[i];
        //         nobj = sl.ObjectCount;

        //         for (int j = 0; j < nobj; j++)
        //         {//Go through objects ************
        //             obj = sl.GetObject(j);
        //             nbra = obj.BranchCount;
        //             for (int k = 0; k < nbra; k++)
        //             {//Go through branches ************
        //                 bra = obj.GetBranch(k);
        //                 len = bra.VertexCount;

        //                 GL.Begin(BeginMode.Points);
        //                 for (int a = 0; a < len - 1; a++)
        //                 {//Go through vertexes ************
        //                     v1 = bra.GetVertex(a, ap, fscale, z);
        //                     v2 = new MyVertex(v1.X, v1.Y, z + zstep);
        //                     v3 = bra.GetVertex(a + 1, ap, fscale, z);

        //                     MyVertex.DrawTriangle(v1, v2, v3, true);
        //                     v1 = new MyVertex(v3.X, v3.Y, v3.Z + zstep);
        //                     MyVertex.DrawTriangle(v3, v2, v1, true);
        //                 }
        //                 GL.End();
        //             }
        //         }
        //         z += zstep;
        //     }//************* Go through all the slides **********

        //     GL.EndList();
        //     return dls;
        // }
        //--------------------------------------------------------------------------------------
        public int RenderDataCube(Point ap, int scale)
        {
            DataSlide sl;
            MRIObject obj;
            Branch bra;
            MyVertex v1 = null;
            MyVertex v2 = null;
            MyVertex v3 = null;

            int nbra, nobj;
            float fscale = 100.0f / scale;
            int len, ns = m_Slides.Count;

            //Z scale
            //float zstep = 1.0f / fscale;
            float zstep = 0.4f;
            float z = (ns / 2) * zstep * (-1);

            int dls = GL.GenLists(1);
            GL.NewList(dls, ListMode.Compile);
            GL.Color3(Color.Gray);

            MyTexture tx = MyTexture.LoadTexture(@"Images/t1.png");
            tx.MakeCurrent();

            for (int i = 0; i < ns; i++)
            {//************* Go through all the slides **********

                sl = m_Slides[i];
                nobj = sl.ObjectCount;

                for (int j = 0; j < nobj; j++)
                {//Go through objects ************
                    obj = sl.GetObject(j);
                    nbra = obj.BranchCount;
                    Console.WriteLine(nbra);
                    for (int k = 0; k < nbra; k++)
                    {//Go through branches ************
                        bra = obj.GetBranch(k);
                        len = bra.VertexCount;
                        //Console.WriteLine(len);
                        GL.Begin(BeginMode.Triangles);
                        for (int a = 0; a < len - 1; a++)
                        {//Go through vertexes ************
                            v1 = bra.GetVertex(a, ap, fscale, z);
                            v2 = new MyVertex(v1.X, v1.Y, z + zstep);
                            v3 = bra.GetVertex(a + 1, ap, fscale, z);

                            MyVertex.DrawTriangle(v1, v2, v3, true);
                            v1 = new MyVertex(v3.X, v3.Y, v3.Z + zstep);
                            MyVertex.DrawTriangle(v3, v2, v1, true);
                        }
                        GL.End();
                    }
                }
                z += zstep;
            }//************* Go through all the slides **********

            GL.EndList();
            return dls;
        }
    }
}
