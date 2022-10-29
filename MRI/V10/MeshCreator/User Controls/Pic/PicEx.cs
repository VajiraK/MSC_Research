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
	public partial class PicEx : UserControl
	{
		protected References m_r;
		private SolidBrush m_b1 = new SolidBrush(Color.Red);
		private SolidBrush m_b2 = new SolidBrush(Color.Yellow);
		private Pen m_pblack = new Pen(Color.Black);
		private Pen m_pred = new Pen(Color.Red);
		private Graphics m_g;
		//---------------------------------------------------------------------------
		public PicEx()
		{
			InitializeComponent();
		}
		//------------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
		}
		//---------------------------------------------------------------------------
		public void DrawHoverCircle(Point p)
		{
			p.Offset(-5, -5);
			pictureBox1.Refresh();
			m_g.DrawEllipse(m_pred, p.X, p.Y, 10, 10);
		}
		//------------------------------------------------------------------------------
		protected void SetImage(UmImage um)
		{
			Bitmap bmp = um.ToBitmap();
			pictureBox1.Size = bmp.Size;
			pictureBox1.Image = bmp;
			m_g = pictureBox1.CreateGraphics();
		}
		//------------------------------------------------------------------------------
		protected void SetImage(Bitmap bmp)
		{//Call by PicExOverLay
			pictureBox1.Size = bmp.Size;
			pictureBox1.Image = bmp;
			m_g = pictureBox1.CreateGraphics();
		}
		//------------------------------------------------------------------------------
		public PictureBox PicBox 
		{ 
			get { return pictureBox1; } 
		}
		//---------------------------------------------------------------------------
		protected void DrawAxisPoint(Point p)
		{
			pictureBox1.Refresh();
			Rectangle r = new Rectangle(p.X, p.Y, 28, 28);
			r.Offset(-14, -14);

			//Left
			m_g.FillPie(m_b1, r, 180, 45);
			m_g.DrawPie(m_pblack, r, 180, 45);
			//Right
			m_g.FillPie(m_b2, r, 270, 45);
			m_g.DrawPie(m_pblack, r, 270, 45);
			//Top
			m_g.FillPie(m_b1, r, 0, 45);
			m_g.DrawPie(m_pblack, r, 0, 45);
			//Bottom
			m_g.FillPie(m_b2, r, 90, 45);
			m_g.DrawPie(m_pblack, r, 90, 45);
		}
	}
}
