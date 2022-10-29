using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AFI = AForge.Imaging;
using AForge.Imaging.Filters;

namespace MeshCreator
{
	public class ByteImage
	{
		private List<MRIObject> m_obj_list;
		private UmImage			m_ori_image;//Original umimage
		private byte[,]			m_pixels;//Result after processing m_umimage
		private byte[,]			m_obj_mask;//Used to mark objects
		private MySize			m_size;
		private int				m_pos;//Posision in the cube
		//---------------------------------------------------------------------------
		public int Posision
		{
			get
			{
				return m_pos;
			}
		}
		//---------------------------------------------------------------------------
		public ByteImage(MySize s)
		{
			m_size = s;
			m_pixels = new byte[m_size.Width, m_size.Height];
			m_obj_mask = new byte[m_size.Width, m_size.Height];
		}
		//---------------------------------------------------------------------------
		public ByteImage(UmImage image,int pos)
		{
			m_size		= image.GetSize();
			m_pixels	= new byte[m_size.Width, m_size.Height];
			m_obj_mask	= new byte[m_size.Width, m_size.Height];
			m_obj_list	= new List<MRIObject>(10);
			m_ori_image	= image;
			m_pos = pos;
		}
		//---------------------------------------------------------------------------
		public Point ImageCenter
		{
			get
			{ 
				Point p = Point.Empty;
				p.X = m_size.Width / 2;
				p.Y = m_size.Height / 2;
				return p; 
			}
		}
		//---------------------------------------------------------------------------
		public static ByteImage FromFile(string path,int pos)
		{
			UmImage um = UmImage.FromFile(path);
			ByteImage bi = new ByteImage(um,pos);
			return bi;
		}
		//---------------------------------------------------------------------------
		public void UpdateFromUm(UmImage image)
		{
			MyPoint p = new MyPoint();
			for (p.y = 0; p.y < m_size.Height; p.y++)
			{
				for (p.x = 0; p.x < m_size.Width; p.x++)
					m_pixels[p.x, p.y] = image.GetPix(p);
			}
		}
		//---------------------------------------------------------------------------
		public UmImage OriUm
		{
			get { return m_ori_image; }
		}
		//---------------------------------------------------------------------------
		public UmImage OriCloneUm
		{
			get { return m_ori_image.Clone(); }
		}
		//---------------------------------------------------------------------------
		public MySize Size
		{
			get { return m_size; }
		}
		//---------------------------------------------------------------------------
		public byte[,] GetPixels()
		{//clonimg is vital(because FloodFill modify original data)
			return (byte[,])m_pixels; 
		}
		//---------------------------------------------------------------------------
		public byte[,] GetObjectMask()
		{
			return m_obj_mask;
		}
		//---------------------------------------------------------------------------
		public List<MRIObject> GetObjects
		{
			get { return m_obj_list; }
		}
		//---------------------------------------------------------------------------
		public byte ObjectCount 
		{
			get { return (byte)m_obj_list.Count; }
		}
		//---------------------------------------------------------------------------
		public void ClearLastObject()
		{
			int i = m_obj_list.Count;
			if (i!=0)
			{
				m_obj_list[--i].Clear();
				m_obj_list.RemoveAt(i);
			}
		}
		//---------------------------------------------------------------------------
		public MRIObject GetObjectByFill(byte fill)
		{
			foreach (MRIObject obj in m_obj_list)
			{
				if (obj.FillColor == fill)
					return obj;
			}
			return null;
		}
		//--------------------------------------------------------------------
		public MRIObject GetObjectByIndex(int i)
		{
			return m_obj_list[i];
		}
		//---------------------------------------------------------------------------
        public MRIObject AddObject(int len, byte fillcol)
		{
            MRIObject obj = new MRIObject(len, fillcol, this);
            m_obj_list.Add(obj);
            return obj;
		}
		//---------------------------------------------------------------------------
		public void Dispose()
		{
			m_obj_list = null;
			m_obj_mask = null;
			m_pixels = null;
			m_ori_image.Dispose();
		}
		//--------------------------------------------------------------------
		public void CreateBoaders(Stack<MyPoint> st)
		{
			MyPoint p = new MyPoint();
			byte[,] mask = (byte[,])m_obj_mask.Clone();
			//Find border pix
			for (p.x = 0; p.x < m_size.Width; p.x++)
			{
				for (p.y = 0; p.y < m_size.Height; p.y++)
				{
					if (ColorMarshal.IsBorder(mask[p.x,p.y]))
					{//Boader found :)
						CreateBoader(p, mask);
					}
				}
			}
		}
		//--------------------------------------------------------------------
        private void CreateBoader(MyPoint p, byte[,] mask)
		{
			Branch	bra = new Branch(this);
			MyPoint cp = p;
            MyPoint startp = p;
            bool    bfound = false;//Found branch
            bool    gotpix = false;//Found boarder pixel
			byte	bor = mask[p.x,p.y];

            bra.PushPoint(p);//Push start point but donot black it

			int w = m_size.Width - 1;
			int h = m_size.Height - 1;

			while (true)
			{//Scann eight nabers counter clock vice to find next baoder pixcel
				//Down-left
				if ((p.x != 0) && (p.y < h))
				{
					if (bor == mask[p.x - 1, p.y + 1])
					{
						//p.x = p.x - 1; p.y = p.y + 1;
                        gotpix = true;
                        cp = new MyPoint(p.x - 1, p.y + 1);//Get the point and gray it
					}
				}
				//Down
				if (p.y < h)
				{
					if (bor == mask[p.x, p.y + 1])
					{
						//p.y = p.y + 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x, p.y + 1));//There is a previous brach so put this one to stack
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x, p.y + 1);
						}
					}
				}
				//Down-right
				if ((p.x < w) && (p.y < h))
				{
					if (bor == mask[p.x + 1, p.y + 1])
					{
						//p.x = p.x + 1; p.y = p.y + 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x + 1, p.y + 1));
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x + 1, p.y + 1);
						}
					}
				}
				//Right
				if (p.x < w)
				{
					if (bor == mask[p.x + 1, p.y])
					{
						//p.x = p.x + 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x + 1, p.y));
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x + 1, p.y);
						}
					}
				}
				//Right-top
				if ((p.x < w) && (p.y != 0))
				{
					if (bor == mask[p.x + 1, p.y - 1])
					{
						//p.x = p.x + 1; p.y = p.y - 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x + 1, p.y - 1));
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x + 1, p.y - 1);
						}
					}
				}
				//Top
				if (p.y != 0)
				{
					if (bor == mask[p.x, p.y - 1])
					{
						//p.y = p.y - 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x, p.y - 1));
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x, p.y - 1);
						}
					}
				}
				//Top-left
				if ((p.x != 0) && (p.y != 0))
				{
					if (bor == mask[p.x - 1, p.y - 1])
					{
						//p.x = p.x - 1; p.y = p.y - 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x - 1, p.y - 1));
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x - 1, p.y - 1);
						}
					}
				}
				//Left
				if (p.x != 0)
				{
					if (bor == mask[p.x - 1, p.y])
					{
						//p.x = p.x - 1;
                        if (gotpix)
						{
                            bfound = true;
                            //st.Push(new MyPoint(p.x - 1, p.y));
						}else{
                            gotpix = true;
                            cp = new MyPoint(p.x - 1, p.y);
						}
					}
				}
                //*********************************************************************
                if (gotpix)
				{
                    p = cp;
                    cp.bra_pos = bfound;
                    bra.PushPoint(cp, mask);
                    bfound = gotpix = false;
				}else{
				//Brach end
                    if ((startp.x == p.x) && (startp.y == p.y))
                    {//At the bigging of the branch so we are done :)
                        mask[p.x, p.y] = ColorMarshal.BLACK;
                        MRIObject obj = this.GetObjectByFill(ColorMarshal.GetFillFromBod(bor));
                        obj.AddBranch(bra);
                        Console.WriteLine(bra.PointCount);
                        break;
                    }else{
                        p = bra.GotoLastBranch();
                    }
				}
			}
		}
	}
}
