using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MeshCreator
{
	public enum MRIPropTypes
	{
		Forward,
		Backward,
		Full
	}
	//################################################################################
	public enum MRISteps
	{
		Processing,
		Marking
	}
    //################################################################################
    #region Structures
    public struct MySize
    {
        public int Width;
        public int Height;
    }
    //################################################################################
    public struct MyPoint
    {
        public int x;
        public int y;
        public bool bra_pos;
        //--------------------------------------------------------------------------------------
        public MyPoint(Point p)
        {
            this.x = p.X;
            this.y = p.Y;
            bra_pos = false;
        }
        //--------------------------------------------------------------------------------------
        public MyPoint(int x, int y,bool bra)
        {
            this.x = x;
            this.y = y;
            bra_pos = bra;
        }
        //--------------------------------------------------------------------------------------
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
            bra_pos = false;
        }
        //--------------------------------------------------------------------------------------
        public bool Eq(MyPoint p)
        {
            if ((this.x == p.x) && (this.y == p.y))
                return true;
            else
                return false;
        }
    }
    //################################################################################
    public struct MyColor
    {
        public byte r;
        public byte g;
        public byte b;
        //--------------------------------------------------------------------------------------
        public bool Eq(MyColor c)
        {
            if ((this.r == c.r) && (this.g == c.g) && (this.b == c.b))
                return true;
            else
                return false;
        }
        //--------------------------------------------------------------------------------------
        public MyColor(Color c)
        {
            this.r = c.R;
            this.g = c.G;
            this.b = c.B;
        }
        //--------------------------------------------------------------------------------------
        public MyColor(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
    //################################################################################
    public struct MyScanData
    {
        public IntPtr Scan0;
        public BitmapData bmData;
        public int stride;
        public int nOffset;
        public int h;
        public int w;
    }
	//################################################################################
	public struct FloodFillInfo
	{
		public MyPoint	m_start_point;
		public byte		m_tarcol;
		public byte		m_min;
		public byte		m_max;
		public byte		m_fillcol;//use to fill grayscale image
		public byte		m_obj_fill;
		public ByteImage m_bi;
		//---------------------------------------------------------------------------
		public void SetTolerance(byte tolerance)
		{
			int t = tolerance / 2;

			int min = m_tarcol - t;
			int max = m_tarcol + t;

			if (min < 0)
				min = 0;
			this.m_min = (byte)min;

			if (max > 255)
				max = 255;
			this.m_max = (byte)max;

			m_fillcol = (byte)(m_max + 1);
		}
	}
    #endregion
    //################################################################################

}