using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeshCreator
{
	public partial class picExOriginal : PicEx
	{
		public picExOriginal()
		{
			InitializeComponent();
		}
		//------------------------------------------------------------------------------
		public void SetImage(ByteImage bi)
		{
			Bitmap bmp = bi.OriUm.ToBitmap();
			//Must be Format24bppRgb, other vice we cannot draw color objects on overlaypic
			Bitmap bmp24 = AForge.Imaging.Image.Clone(bmp, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			bmp.Dispose();
			base.SetImage(bmp24);
			m_r.m_pix_con.PicOver.SetImage(bmp24, bi);
		}
		//---------------------------------------------------------------------------
		public Bitmap Image
		{//Call by overlaypic
			get {
				return AForge.Imaging.Image.Clone((Bitmap)base.PicBox.Image);
			} 
		}
	}
}
