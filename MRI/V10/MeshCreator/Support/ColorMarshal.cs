using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeshCreator
{
	class ColorMarshal
	{
		public const byte BLACK = 0;
		public const byte WHITE = 1;
		public const byte MAX_OBJ = 10;

		private const byte BOR_1 = 2;
		private const byte BOR_2 = 3;
		private const byte BOR_3 = 4;
		private const byte BOR_4 = 5;
		private const byte BOR_5 = 6;
		private const byte BOR_6 = 7;
		private const byte BOR_7 = 8;
		private const byte BOR_8 = 9;
		private const byte BOR_9 = 10;
		private const byte BOR_10 = 11;

		private const byte FIL_1 = 12;
		private const byte FIL_2 = 13;
		private const byte FIL_3 = 14;
		private const byte FIL_4 = 15;
		private const byte FIL_5 = 16;
		private const byte FIL_6 = 17;
		private const byte FIL_7 = 18;
		private const byte FIL_8 = 19;
		private const byte FIL_9 = 20;
		private const byte FIL_10 = 21;

		private const byte INVALIED = 100;

		private const byte MAX_BOD = BOR_10;
		private const byte MAX_FIL = FIL_10;
		//---------------------------------------------------------------------------
		private ColorMarshal() { }
		//---------------------------------------------------------------------------
		public static byte GetNextFill(byte cur_fill)
		{
			cur_fill++;
			if (cur_fill <= MAX_FIL)
				return cur_fill;

			return INVALIED;
		}
		//---------------------------------------------------------------------------
		public static bool IsBorder(byte b)
		{
			if ((b >= BOR_1) && (b <= MAX_BOD))
				return true;
			else
				return false;
		}
		//---------------------------------------------------------------------------
		public static byte GetNextBor(byte cur_bod)
		{
			cur_bod++;
			if (cur_bod <= MAX_BOD)
				return cur_bod;

			return INVALIED;
		}
		//---------------------------------------------------------------------------
		public static byte GetBordColor(int index)
		{
			switch (index)
			{
				case 0:
					return BOR_1;
				case 1:
					return BOR_2;
				case 2:
					return BOR_3;
				case 3:
					return BOR_4;
				case 4:
					return BOR_5;
				case 5:
					return BOR_6;
				case 6:
					return BOR_7;
				case 7:
					return BOR_8;
				case 8:
					return BOR_9;
				case 9:
					return BOR_10;
				default:
					return INVALIED;
			}
		}
		//---------------------------------------------------------------------------
		public static bool IsMatch(byte b)
		{
			if (b == BOR_1)return true;
			if (b == BOR_2) return true;
			if (b == BOR_3) return true;
			if (b == BOR_4) return true;
			if (b == BOR_5) return true;
			if (b == BOR_6) return true;
			if (b == BOR_7) return true;
			if (b == BOR_8) return true;
			if (b == BOR_9) return true;
			if (b == BOR_10) return true;
			return false;
		}
		//---------------------------------------------------------------------------
		public static byte GetFirstBor()
		{
			return BOR_1;
		}
		//---------------------------------------------------------------------------
		public static byte GetFirstFill()
		{
			return FIL_1;
		}
		//---------------------------------------------------------------------------
		public static byte GetBodFromFill(byte fill)
		{
			switch (fill)
			{
				case FIL_1:
					return BOR_1;
				case FIL_2:
					return BOR_2;
				case FIL_3:
					return BOR_3;
				case FIL_4:
					return BOR_4;
				case FIL_5:
					return BOR_5;
				case FIL_6:
					return BOR_6;
				case FIL_7:
					return BOR_7;
				case FIL_8:
					return BOR_8;
				case FIL_9:
					return BOR_9;
				case FIL_10:
					return BOR_10;
				default:
					break;
			}
			return INVALIED;
		}
		//---------------------------------------------------------------------------
		public static byte GetFillFromBod(byte bod)
		{
			switch (bod)
			{
				case BOR_1:
					return FIL_1;
				case BOR_2:
					return FIL_2;
				case BOR_3:
					return FIL_3;
				case BOR_4:
					return FIL_4;
				case BOR_5:
					return FIL_5;
				case BOR_6:
					return FIL_6;
				case BOR_7:
					return FIL_7;
				case BOR_8:
					return FIL_8;
				case BOR_9:
					return FIL_9;
				case BOR_10:
					return FIL_10;
				default:
					break;
			}
			return INVALIED;
		}
		//---------------------------------------------------------------------------
		public static bool IsInvalied(byte c)
		{
		    if (c == INVALIED)
		        return true;
		    else
		        return false;
		}
		//---------------------------------------------------------------------------
		public static MyColor Marshal(byte c)
		{
			MyColor mc = new MyColor();

			switch (c)
			{
				case WHITE:
					mc.r = 255; mc.g = 255; mc.b = 255;
					break;
				case BLACK:
					mc.r = 0; mc.g = 0; mc.b = 0;
					break;
				case FIL_1:
					mc.r = 255; mc.g = 0; mc.b = 0;//Red
					break;
				case FIL_2:
					mc.r = 0; mc.g = 255; mc.b = 0;//Green
					break;
				case FIL_3:
					mc.r = 0; mc.g = 0; mc.b = 255;//Blue
					break;
				case FIL_4:
					mc.r = 255; mc.g = 255; mc.b = 0;//Yellow
					break;
				case FIL_5:
					mc.r = 167; mc.g = 103; mc.b = 69;//Brown
					break;
				case FIL_6:
					mc.r = 0; mc.g = 128; mc.b = 128;//Teal
					break;
				case FIL_7:
					mc.r = 153; mc.g = 217; mc.b = 234;//Light blue
					break;
				case FIL_8:
					mc.r = 163; mc.g = 73; mc.b = 164;//Purple
					break;
				case FIL_9:
					mc.r = 255; mc.g = 174; mc.b = 201;//Pink
					break;
				case FIL_10:
					mc.r = 181; mc.g = 230; mc.b = 29;//Lime
					break;
				default:
					if ((c >= BOR_1) && (c <= MAX_BOD))
						mc.r = 255; mc.g = 201; mc.b = 14;
					break;
			}

			return mc;
		}
	}
}
