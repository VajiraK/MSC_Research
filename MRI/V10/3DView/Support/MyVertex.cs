using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace _3DView
{
	class MyVertex
	{
		public float	X;
		public float	Y;
		public float	Z;
		public int		m_col;
		//---------------------------------------------------------------------------
		public MyVertex()
		{
			X = 0;
			Y = 0;
			m_col = 0;
		}
		//---------------------------------------------------------------------------
		public MyVertex(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
			m_col = 0;
		}
		//---------------------------------------------------------------------------
		public MyVertex(float x,float y,int col)
		{
			X = x;
			Y = y;
			m_col = col;
		}
		//---------------------------------------------------------------------------
		public override string ToString()
		{
			return string.Format("({0}\t,\t({1})\t,\t({2})", this.X, this.Y, this.Z);
		}
		//---------------------------------------------------------------------------
		public static void Print3(MyVertex v1, MyVertex v2, MyVertex v3)
		{
			Console.WriteLine(string.Format("v1 - {0}", v1.ToString()));
			Console.WriteLine(string.Format("v2 - {0}", v2.ToString()));
			Console.WriteLine(string.Format("v3 - {0}", v3.ToString()));
		}
		//---------------------------------------------------------------------------
		public static void DrawTriangle(MyVertex v1, MyVertex v2, MyVertex v3, bool norm)
		{
			if (norm)
			{
				MyVertex a = new MyVertex(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
				MyVertex b = new MyVertex(v2.X - v3.X, v2.Y - v3.Y, v2.Z - v3.Z);
				MyVertex n = new MyVertex();
				// calculate the cross product and place the resulting vector
				n.X = (a.Y * b.Z) - (a.Z * b.Y);
				n.Y = (a.Z * b.X) - (a.X * b.Z);
				n.Z = (a.X * b.Y) - (a.Y * b.X);
				// calculate the length of the vector
				float len = (float)Math.Sqrt((n.X * n.X) + (n.Y * n.Y) + (n.Z * n.Z));
				// avoid division by 0
				if (len == 0.0f)len = 1.0f;
				// reduce to unit size
				n.X /= len;
				n.Y /= len;
				n.Z /= len;

				GL.Normal3(n.X, n.Y, n.Z);
				GL.TexCoord2(0.0f, 0.5f);
				GL.Vertex3(v1.X, v1.Y, v1.Z);
				GL.TexCoord2(1.0f, 0.0f);
				GL.Vertex3(v2.X, v2.Y, v2.Z);
				GL.TexCoord2(0.0f, 0.0f);
				GL.Vertex3(v3.X, v3.Y, v3.Z);
			}else{
				GL.Normal3(0.0, 0.0, 1.0);
				GL.TexCoord2(0.0f, 0.5f);
				GL.Vertex3(v1.X, v1.Y, v1.Z);
				GL.TexCoord2(1.0f, 0.0f);
				GL.Vertex3(v2.X, v2.Y, v2.Z);
				GL.TexCoord2(0.0f, 0.0f);
				GL.Vertex3(v3.X, v3.Y, v3.Z);
			}
		}
	}
}
