using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _3DView
{
	class MyTexture
	{
		private int m_id;
		//---------------------------------------------------------------------------
		private MyTexture(){}
		//---------------------------------------------------------------------------
		public static MyTexture LoadTexture(string filename)
		{
			try
			{
				MyTexture tx = new MyTexture();
				//Generate new id
				tx.m_id = GL.GenTexture();
				//Create new texture object
				GL.BindTexture(TextureTarget.Texture2D, tx.m_id);
				//Save textre characteristics on texture object
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
				//Data for the new texture object
				Bitmap bmp = new Bitmap(filename);
				BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);
				bmp.UnlockBits(bmp_data);
				bmp.Dispose();
				return tx;
			}catch (Exception){
				return null;
			}
		}
		//---------------------------------------------------------------------------
		public void MakeCurrent()
		{
			GL.BindTexture(TextureTarget.Texture2D, m_id);
		}
		//---------------------------------------------------------------------------
		public void Delete()
		{
			GL.DeleteTexture(m_id);
		}
		//---------------------------------------------------------------------------
		public static void Enable()
		{
			GL.Enable(EnableCap.Texture2D);
		}
		//---------------------------------------------------------------------------
		public static void Disable()
		{
			GL.Disable(EnableCap.Texture2D);
		}
	}
}
