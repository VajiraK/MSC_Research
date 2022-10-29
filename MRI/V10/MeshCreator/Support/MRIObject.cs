using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MeshCreator
{
	//################################################################################
    //public class Branch
    //{
    //    private ByteImage m_bi;
    //    private Stack<MyPoint> m_point_stack;
    //    //---------------------------------------------------------------------------
    //    public Branch(ByteImage bi)
    //    {
    //        m_bi = bi;
    //        m_point_stack = new Stack<MyPoint>(100);
    //    }
    //    //---------------------------------------------------------------------------
    //    public void AddPoint(MyPoint p, byte[,] mask)
    //    {
    //        m_point_stack.Push(p);
    //        mask[p.x, p.y] = ColorMarshal.BLACK;
    //    }
    //    //---------------------------------------------------------------------------
    //    public void Revers()
    //    {
    //        m_point_stack.Reverse();
    //    }
    //    //---------------------------------------------------------------------------
    //    public MyPoint GetPoint(int i)
    //    {
    //        return m_point_stack.Pop();
    //    }
    //    //---------------------------------------------------------------------------
    //    public int PointCount
    //    {
    //        get 
    //        {
    //            //Console.WriteLine(m_point_stack.Count);
    //            return m_point_stack.Count; 
    //        }
    //    }
    //}
    public class Branch
    {
        private ByteImage m_bi;
        private Stack<MyPoint> m_point_stack;
        //---------------------------------------------------------------------------
        public Branch(ByteImage bi)
        {
            m_bi = bi;
            m_point_stack = new Stack<MyPoint>(100);
        }
        //---------------------------------------------------------------------------
        public void PushPoint(MyPoint p)
        {
            m_point_stack.Push(p);
        }
        //---------------------------------------------------------------------------
        public void PushPoint(MyPoint p, byte[,] mask)
        {
            m_point_stack.Push(p);
            mask[p.x, p.y] = ColorMarshal.BLACK;
        }
        //---------------------------------------------------------------------------
        public MyPoint PopPoint(int i)
        {
            return m_point_stack.Pop();
        }
        //---------------------------------------------------------------------------
        //public void ReversePoints()
        //{
        //    m_point_stack.Reverse();
        //}
        //---------------------------------------------------------------------------
        public MyPoint GotoLastBranch()
        {
            MyPoint mp = new MyPoint();
            int c = m_point_stack.Count;

            for (int i = 0; i < c; i++)
            {
                mp = m_point_stack.Pop();
                if (mp.bra_pos)
                    return mp;
            }

            return mp;
        }
        //---------------------------------------------------------------------------
        public int PointCount
        {
            get { return m_point_stack.Count; }
        }
    }
    //public class Branch
    //{
    //    private ByteImage m_bi;
    //    private List<MyPoint> m_point_list;
    //    //---------------------------------------------------------------------------
    //    public Branch(ByteImage bi)
    //    {
    //        m_bi = bi;
    //        m_point_list = new List<MyPoint>(100);
    //    }
    //    //---------------------------------------------------------------------------
    //    public void AddPoint(MyPoint p, byte[,] mask)
    //    {
    //        m_point_list.Add(p);
    //        mask[p.x, p.y] = ColorMarshal.BLACK;
    //    }
    //    //---------------------------------------------------------------------------
    //    public MyPoint GetPoint(int i)
    //    {
    //        return m_point_list[i];
    //    }
    //    //---------------------------------------------------------------------------
    //    public int PointCount
    //    {
    //        get { return m_point_list.Count; }
    //    }
    //}
	//################################################################################
	public class MRIObject
	{
		private List<Branch>	m_branch_list;
		private ByteImage		m_bi;
		private int				m_length;
		private byte			m_fill_color;
		private byte			m_bor_color;
		private MyPoint			m_centroid;
		//---------------------------------------------------------------------------
		public MRIObject(int len, byte fillcol, ByteImage bi)
		{
			m_branch_list = new List<Branch>(10);
			m_length = len;
			m_fill_color = fillcol;
			m_bi = bi;
			m_bor_color = ColorMarshal.GetBodFromFill(fillcol);
		}
		//---------------------------------------------------------------------------
		public ByteImage GetByteImage()
		{
			return m_bi;
		}
		//---------------------------------------------------------------------------
		public Branch GetBranch(int i)
		{
			return m_branch_list[i];
		}
		//---------------------------------------------------------------------------
		public void AddBranch(Branch bra)
		{
            //bra.ReversePoints();
			m_branch_list.Add(bra);
		}
		//---------------------------------------------------------------------------
		public int BranchCount 
		{
			get{return m_branch_list.Count;}
		}
		//---------------------------------------------------------------------------
		public int Length 
		{
			get { return m_length; }
		}
		//---------------------------------------------------------------------------
		public void IncreaseArea(int a) 
		{
			m_length += a;
		}
		//---------------------------------------------------------------------------
		public byte FillColor
		{
			get { return m_fill_color; }
		}
		//---------------------------------------------------------------------------
		public MyPoint[] GetObjPoints()
		{
		    MySize s = m_bi.Size;
		    byte[,] msk = m_bi.GetObjectMask();
		    MyPoint[] arr = new MyPoint[m_length];
		    int c = 0;

		    for (int x = 0; x < s.Width; x++)
		    {
		        for (int y = 0; y < s.Height; y++)
		        {
		            if ((msk[x, y] == m_fill_color)||(msk[x, y] == m_bor_color))
		            {
                        if (c < m_length)
                        {
                            arr[c].x = x;
                            arr[c++].y = y;
                        }
		            }
		        }
		    }
		    return arr;
		}
		//---------------------------------------------------------------------------
		public MyPoint Centroid 
		{
			get{return m_centroid;}
		}
		//---------------------------------------------------------------------------
		public MyPoint FindCentroid()
		{
			int xtot = 0;
			int ytot = 0;
			MySize s = m_bi.Size;
		    byte[,] msk = m_bi.GetObjectMask();

		    for (int x = 0; x < s.Width; x++)
		    {
		        for (int y = 0; y < s.Height; y++)
		        {
		            if ((msk[x, y] == m_fill_color)||(msk[x, y] == m_bor_color))
		            {
						xtot += x;
						ytot += y;
		            }
		        }
		    }
			m_centroid = new MyPoint(xtot/m_length,ytot/m_length);
			return m_centroid;
		}
		//---------------------------------------------------------------------------
		public void Mark(Bitmap bmp)
		{
			BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int stride = bmData.Stride;
			IntPtr Scan0 = bmData.Scan0;
			MySize s = m_bi.Size;
			MyColor fc = ColorMarshal.Marshal(m_fill_color);
			MyColor bc = ColorMarshal.Marshal(m_bor_color);
			byte[,] msk = m_bi.GetObjectMask();
			int i = 0;

			unsafe
			{
				byte* p;
				for (int x = 0; x < s.Width; x++)
				{
					for (int y = 0; y < s.Height; y++)
					{
						if (msk[x, y] == m_fill_color)
						{
							i = (y * stride) + (x * 3);
							p = (byte*)(void*)Scan0;
							p[i] = fc.b;
							p[++i] = fc.g;
							p[++i] = fc.r;
						} else{
							if (msk[x, y] == m_bor_color)
							{
								i = (y * stride) + (x * 3);
								p = (byte*)(void*)Scan0;
								p[i] = bc.b;
								p[++i] = bc.g;
								p[++i] = bc.r;
							}
						}
					}
				}
			}

			bmp.UnlockBits(bmData);
		}
		//---------------------------------------------------------------------------
		public void Clear()
		{
			MySize s = m_bi.Size;
			byte[,] msk = m_bi.GetObjectMask();
			for (int x = 0; x < s.Width; x++)
			{
				for (int y = 0; y < s.Height; y++)
				{
					if ((msk[x, y] == m_fill_color)||(msk[x, y] == m_bor_color))
						msk[x, y] = ColorMarshal.BLACK;
				}
			}
		}
		//---------------------------------------------------------------------------
		//public MyPoint GetObjectCenter 
		//{
		//    get
		//    {
		//        MySize s = m_bi.GetSize();
		//        byte val;
		//        int xmin = s.Width;
		//        int xmax = 0;
		//        int ymin = s.Height;
		//        int ymax = 0;

		//        for (int x = 0; x < s.Width; x++)
		//        {
		//            for (int y = 0; y < s.Height; y++)
		//            {
		//                val = m_bi.GetPix(x, y);
		//                if ((m_fill_color == val) || (m_bor_color == val))
		//                {
		//                    if (xmin > x) xmin = x;
		//                    if (xmax < x) xmax = x;
		//                    if (ymin > y)ymin = y;
		//                    if (ymax < y)ymax = y;
		//                }
		//            }
		//        }
		//        int xc = xmin + ((xmax - xmin) / 2);
		//        int yc = ymin + ((ymax - ymin) / 2);

		//        //return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
		//        return new MyPoint(xc,yc);
		//    }
		//}
	}
}
