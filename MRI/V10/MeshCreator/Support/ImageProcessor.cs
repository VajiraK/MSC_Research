using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MeshCreator
{
	public class ImageProcessor
	{
		public References m_r = new References();
		//------------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
		}
		//--------------------------------------------------------------------------------------
		private MyScanData PrepareToScan(Bitmap b)
		{
			MyScanData sd;
			sd.h = b.Height;
			sd.w = b.Width;
			sd.bmData = b.LockBits(new Rectangle(0, 0, sd.w, sd.h), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			sd.stride = sd.bmData.Stride;
			sd.Scan0 = sd.bmData.Scan0;
			sd.nOffset = sd.stride - sd.w * 3;
			return sd;
		}
        //--------------------------------------------------------------------------------------
        public byte[,] BitmapToByte(Bitmap b)
        {
            MyScanData sd = PrepareToScan(b);
            byte[,]  arr = new byte[sd.w, sd.h];
            MyColor c;
            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;

                for (int y = 0; y < sd.h; ++y)
                {
                    for (int x = 0; x < sd.w; ++x)
                    {
                        c = GetPix(x, y, sd);
                        arr[x, y] = (byte)((c.r + c.g + c.b) / 3);
                    }
                }
            }
            b.UnlockBits(sd.bmData);
            return arr;
        }
        //--------------------------------------------------------------------------------------
		public Bitmap ByteToBitmap(byte[,] bi,MySize s)
        {
            Bitmap b = new Bitmap(s.Width, s.Height);
            MyScanData sd = PrepareToScan(b);
            MyColor c = new	MyColor();
            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;

                for (int y = 0; y < s.Height; ++y)
                {
                    for (int x = 0; x < s.Width; ++x)
                    {
						c = ColorMarshal.Marshal(bi[x, y]);
                        SetPix(x,y,sd,c);
                    }
                }
            }
            b.UnlockBits(sd.bmData);
            return b;
        }
        //--------------------------------------------------------------------------------------
		//public Bitmap ThresholdByteToBitmap(ByteImage bi, int t)
		//{//Threshold ByteImage to Bitmap (don't modify the ByteImage)
		//    MySize s = bi.GetSize();
		//    Bitmap tmp = new Bitmap(s.Width,s.Height);
		//    MyScanData sd = PrepareToScan(tmp);

		//    unsafe
		//    {
		//        byte* p = (byte*)(void*)sd.Scan0;

		//        for (int y = 0; y < s.Height; ++y)
		//        {
		//            for (int x = 0; x < s.Width; ++x)
		//            {
		//                if (bi.GetPix(x, y) >= t)
		//                {
		//                    p[0] = p[1] = p[2] = 255;
		//                }else{
		//                    p[0] = p[1] = p[2] = 0;
		//                }
						
		//                p += 3;
		//            }
		//            p += sd.nOffset;
		//        }
		//    }

		//    tmp.UnlockBits(sd.bmData);
		//    return tmp;
		//}
        //--------------------------------------------------------------------------------------
		//public void InverseByte(ByteImage bi)
		//{//Inverse ByteImage
		//    MySize s = bi.GetSize();

		//    for (int y = 0; y < s.Height; ++y)
		//    {
		//        for (int x = 0; x < s.Width; ++x)
		//        {
		//            if (bi.GetPix(x, y) == ColorMarshal.WHITE)
		//            {
		//                bi.SetPix(x, y,ColorMarshal.BLACK);
		//            }else{
		//                bi.SetPix(x, y,ColorMarshal.WHITE);
		//            }
		//        }
		//    }
		//}
        //--------------------------------------------------------------------------------------
		//public void ThresholdByte(ByteImage bi, int min, int max)
		//{//Threshold ByteImage
		//    MySize s = bi.GetSize();
		//    byte val;

		//    for (int y = 0; y < s.Height; ++y)
		//    {
		//        for (int x = 0; x < s.Width; ++x)
		//        {
		//            val = bi.GetPix(x, y);
		//            if (( val< min) || (val > max))
		//            {
		//                bi.SetPix(x, y, ColorMarshal.WHITE);
		//            }else{
		//                bi.SetPix(x, y,ColorMarshal.BLACK);
		//            }
		//        }
		//    }   
		//}
        //--------------------------------------------------------------------------------------
        public Bitmap InverseBitmap(Bitmap b)
        {//Inverse thresholed bitmap
            MyScanData sd = PrepareToScan(b);

            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;

                for (int y = 0; y < sd.h; ++y)
                {
                    for (int x = 0; x < sd.w; ++x)
                    {
						if (p[0] == 255)
                        {
							p[0] = p[1] = p[2] = 0;
                        }else{
							p[0] = p[1] = p[2] = 255;
                        }

                        p += 3;
                    }
                    p += sd.nOffset;
                }
            }

            b.UnlockBits(sd.bmData);
            return b;
        }
		//--------------------------------------------------------------------------------------
		public Bitmap ThresholdBitmap(Bitmap b, int t)
        {//Threshold Bitmap (Reserve original)
            b = (Bitmap)b.Clone();
			MyScanData sd = PrepareToScan(b);

			unsafe
			{
				byte* p = (byte*)(void*)sd.Scan0;

				for (int y = 0; y < sd.h; ++y)
				{
					for (int x = 0; x < sd.w; ++x)
					{
                        p[0] = (byte)((p[0] + p[1] + p[2]) / 3);

						if (p[0] >= t)
						{
							p[0] = p[1] = p[2] = 255;
						}else{
							p[0] = p[1] = p[2] = 0;
						}

						p += 3;
					}
					p += sd.nOffset;
				}
			}

			b.UnlockBits(sd.bmData);
			return b;
		}
        //--------------------------------------------------------------------------------------
		//public int[] GetByteHisto(ByteImage bi)
		//{
		//    int[] his = new int[256];
		//    MySize s = bi.GetSize();
		//    //byte[,] arr = bi.GetBytes();

		//    for (int y = 0; y < s.Height; ++y)
		//    {
		//        for (int x = 0; x < s.Width; ++x)
		//        {
		//            his[bi.GetPix(x, y)]++;
		//        }
		//    }
		//    return his;
		//}
		//--------------------------------------------------------------------------------------
        public int[] GetBitmapHisto(Bitmap b)
		{
			MyScanData sd = PrepareToScan(b);
			int[] his = new int[256];
			int g;

			unsafe
			{
				byte* p = (byte*)(void*)sd.Scan0;

				for (int y = 0; y < sd.h; ++y)
				{
					for (int x = 0; x < sd.w; ++x)
					{
						g = (p[0] + p[1] + p[2])/3;
						his[g]++;
						p += 3;
					}
					p += sd.nOffset;
				}
			}

			b.UnlockBits(sd.bmData);
			return his;
		}
		//--------------------------------------------------------------------------------------
		private void SetPix(MyPoint po, MyScanData sd,MyColor c)
        {
			int i = (po.y * sd.stride) + (po.x * 3);
            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;
                p[i] = c.b;
                p[++i] = c.g;
                p[++i] = c.r;     
            }
        }
        //--------------------------------------------------------------------------------------
        private void SetPix(int x,int y, MyScanData sd, MyColor c)
        {
            int i = (y * sd.stride) + (x * 3);
            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;
                p[i] = c.b;
                p[++i] = c.g;
                p[++i] = c.r;
            }
        }
        //--------------------------------------------------------------------------------------
        private MyColor GetPix(int x, int y, MyScanData sd)
        {
            MyColor c;
            int i = (y * sd.stride) + (x * 3);
            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;
                c.b = p[i];
                c.g = p[++i];
                c.r = p[++i];
            }
            return c;
        }
		//--------------------------------------------------------------------------------------
		private MyColor GetPix(MyPoint po, MyScanData sd)
        {
            MyColor c;
			int i = (po.y * sd.stride) + (po.x * 3);
            unsafe
            {
                byte* p = (byte*)(void*)sd.Scan0;
                c.b = p[i];
                c.g = p[++i];
                c.r = p[++i];
            }
            return c;
        }
        //--------------------------------------------------------------------------------------
		//private void SetPixByte(MyPoint po, byte ci, byte[,] arr)
		//{
		//    arr[po.x, po.y] = ci;
		//}
        //--------------------------------------------------------------------------------------
		//public int FloodFillBytes4(ByteImage bi, MyFoodFill fd)
		//{//Return true if some area filled
		//    MySize s = bi.GetSize();
		//    s.Width--;
		//    byte tar_col = ColorMarshal.WHITE;
		//    byte fill_col = fd.fill_col;
		//    MyPoint p = new MyPoint(fd.mpoint);
		//    //byte[,] arr = bi.GetBytes();
		//    int len = 0;

		//    if (bi.GetPix(p.x, p.y) != tar_col)
		//        return len;//Can't fill

		//    Queue<MyPoint> q = new Queue<MyPoint>(200);
		//    MyPoint top, right, bottom, left;

		//    q.Enqueue(p);

		//    while (q.Count != 0)
		//    {
		//        p = q.Dequeue();
		//        if (bi.GetPix(p.x, p.y) != tar_col)
		//            continue;

		//        right = p;
		//        //scann right
		//        do
		//        {
		//            bi.SetPix(right.x, right.y, fill_col);
		//            //SetPixByte(right, fill_col, arr);
		//            len++;

		//            //add top
		//            top = right; top.y--;
		//            if (top.y >= 0)
		//            {
		//                if (bi.GetPix(top.x, top.y) == tar_col)
		//                    q.Enqueue(top);
		//            }

		//            //add bottom
		//            bottom = right; bottom.y++;
		//            if (bottom.y < s.Height)
		//            {
		//                if (bi.GetPix(bottom.x, bottom.y) == tar_col)
		//                    q.Enqueue(bottom);
		//            }

		//            if (right.x == s.Width)
		//                break;
		//            right.x++;
		//        } while (bi.GetPix(right.x, right.y) == tar_col);

		//        //scann left
		//        left = p; left.x--;
		//        if (left.x >= 0)
		//        {
		//            while (bi.GetPix(left.x, left.y) == tar_col) 
		//            {
		//                bi.SetPix(left.x, left.y, fill_col);
		//                //SetPixByte(left, fill_col, arr);
		//                len++;

		//                //add top
		//                top = left; top.y--;
		//                if (top.y >= 0)
		//                {
		//                    if (bi.GetPix(top.x, top.y) == tar_col)
		//                        q.Enqueue(top);
		//                }

		//                //add bottom
		//                bottom = left; bottom.y++;
		//                if (bottom.y < s.Height)
		//                {
		//                    if (bi.GetPix(bottom.x, bottom.y) == tar_col)
		//                        q.Enqueue(bottom);
		//                }

		//                left.x--;
		//                if (left.x < 0) 
		//                    break;
		//            }
		//        }
		//    }

		//    MarkBoarders(bi, fd.fill_col);
		//    return len;
		//}
        //--------------------------------------------------------------------------------------
		//private void MarkBoarders(ByteImage bi,byte fc)
		//{
		//    int x, y;
		//    MySize s = bi.GetSize();
		//    byte bc = ColorMarshal.GetBodFromFill(fc);
		//    byte val1, val2;

		//    //Left to Right scan
		//    for (x = 1; x < s.Width; ++x)
		//    {
		//        for (y = 0; y < s.Height; ++y)
		//        {
		//            val1 = bi.GetPix(x - 1, y);
		//            val2 = bi.GetPix(x, y);
		//            if (val2 == fc)
		//            {
		//                if ((val1 != fc) && (val1 != bc))
		//                {//Ditect left face boader
		//                    bi.SetPix(x, y,bc);
		//                }
		//            }else{
		//                if ((val1 == fc) && (val2 != bc))
		//                {//Ditect right face boader
		//                    bi.SetPix(x - 1, y, bc);
		//                }
		//            }
		//        }
		//    }
		//    //Top to Down scan
		//    for (y = 1; y < s.Height; ++y)
		//    {
		//        for (x = 0; x < s.Width; ++x)
		//        {
		//            val1 = bi.GetPix(x, y - 1);
		//            val2 = bi.GetPix(x, y);
		//            if (val2 == fc)
		//            {
		//                if ((val1 != fc) && (val1 != bc))
		//                {//Ditect top face boader
		//                    bi.SetPix(x, y, bc);
		//                }
		//            }else{
		//                if ((val1 == fc) && (val2 != bc))
		//                {//Ditect bottum face boader
		//                    bi.SetPix(x, y - 1, bc);
		//                }
		//            }
		//        }
		//    }
		//}
	}
}
