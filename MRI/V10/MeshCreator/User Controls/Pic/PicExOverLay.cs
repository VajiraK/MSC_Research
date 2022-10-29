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
	public partial class PicExOverLay : PicEx
	{
		private PictureBox m_picbox;
		private Point m_ax_point;
		private bool m_ax_manual_set;
		//---------------------------------------------------------------------------
		public PicExOverLay()
		{
			InitializeComponent();
		}
		//------------------------------------------------------------------------------
		public void SetImage(Bitmap bmp24, ByteImage bi)
		{
            base.SetImage(bmp24);
            MarkObjects(bi);
            m_r.m_pix_con.PicInter.SetImage(bi);
            if (!m_ax_manual_set)
                AxisPoint = bi.ImageCenter;
            else
                timer1.Start();
		}
		//------------------------------------------------------------------------------
		public new void Init(References r)
		{
            base.Init(r);
            m_picbox = base.PicBox;
            m_picbox.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
		}
		//---------------------------------------------------------------------------
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
            AxisPoint = e.Location;
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{
			m_ax_manual_set = false;
		}
		//---------------------------------------------------------------------------
		public Point AxisPoint
		{
			set 
			{
				m_ax_manual_set = true;
				m_ax_point = value;
				timer1.Start();
			}
			get { return m_ax_point; }
		}
		//---------------------------------------------------------------------------
		public void MarkObjects(ByteImage bi)
		{
			Bitmap bmp24 = m_r.m_pix_con.PicOri.Image;
			foreach (MRIObject obj in bi.GetObjects)
				obj.Mark(bmp24);
			m_picbox.Image = bmp24;
		}
		//---------------------------------------------------------------------------
		private void timer1_Tick(object sender, EventArgs e)
		{
            //timer1.Stop();
            //if (m_picbox.Image != null)
            //    base.DrawAxisPoint(m_ax_point);
		}
	}
}
