using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DView
{
	public partial class CossView : UserControl
	{
		private References		m_r;
		private Timer			m_timer;
		private bool			m_use_cur_ax = false;//When true using current axis instead of original 3D file one :)
		private CrossViewData	m_cdata;
		private Point			m_mouse_point,m_click_point;
		private Graphics		m_g;
		private SolidBrush		m_b1 = new SolidBrush(Color.Red);
		private SolidBrush		m_b2 = new SolidBrush(Color.Yellow);
		private Pen				m_pblack = new Pen(Color.Black);
		private Pen				m_pred = new Pen(Color.Red);
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
			trkPacity.Value = 70;
			m_r.m_controller.Opacity = 0.7;
		}
		//---------------------------------------------------------------------------
		public CossView()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public Point AxisPoint
		{
			get
			{
				if (m_use_cur_ax)
				{
					return m_cdata.cur_ap;
				}else{
					return m_cdata.ori_ap;
				}
			}
		}
		//---------------------------------------------------------------------------
		public void SetCrossImage(CrossViewData cdata)
		{
			m_cdata = cdata;
			m_click_point = m_cdata.ori_ap;
			pictureBox1.Size = m_cdata.image.Size;
			pictureBox1.Image = m_cdata.image;
			m_g = pictureBox1.CreateGraphics();
			btnSetAxis.Enabled = true;
		}
		//---------------------------------------------------------------------------
		private void DrawAxisPoint()
		{
			if (m_cdata.image != null)
			{
				Point ap = this.AxisPoint;
				Rectangle r = new Rectangle(ap.X, ap.Y, 28, 28);
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
		//---------------------------------------------------------------------------
		private void m_timer_Tick(object sender, EventArgs e)
		{
			m_timer.Stop();
			Point p = m_click_point;
			p.Offset(-5,-5);
			m_g.DrawEllipse(m_pred, p.X, p.Y, 10, 10);
			DrawAxisPoint();
		}
		//---------------------------------------------------------------------------
		private void CossView_Load(object sender, EventArgs e)
		{
			m_timer = new Timer();
			m_timer.Interval = 100;
			m_timer.Tick += new EventHandler(m_timer_Tick);
		}
		//---------------------------------------------------------------------------
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (m_cdata.image != null)
			{
				m_timer.Start();
			}
		}
		//---------------------------------------------------------------------------
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (m_cdata.image!=null)
			{
				btnSetAxis.Enabled = true;
				m_click_point = m_mouse_point;
				pictureBox1.Refresh();
			}
		}
		//---------------------------------------------------------------------------
		private void cmdSetAxis_Click(object sender, EventArgs e)
		{
			m_use_cur_ax = true;
			m_cdata.cur_ap = m_click_point;
			btnSetAxis.Enabled = false;
			btnResetAxis.Enabled = true;
			pictureBox1.Refresh();
			Updare3DView();
		}
		//---------------------------------------------------------------------------
		private void Updare3DView()
		{
			m_r.m_main_form.Enabled = false;
			m_r.m_controller.Enabled = false;
			m_r.m_glscreen.DrawMRI(this.AxisPoint);
			m_r.m_controller.Enabled = true;
			m_r.m_main_form.Enabled = true;
		}
		//---------------------------------------------------------------------------
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			m_mouse_point = e.Location;
		}
		//---------------------------------------------------------------------------
		private void btnResetAxis_Click(object sender, EventArgs e)
		{
			m_use_cur_ax = false;
			btnResetAxis.Enabled = false;
			pictureBox1.Refresh();
			Updare3DView();
			btnSetAxis.Enabled = true;
		}
		//---------------------------------------------------------------------------
		private void trkPacity_Scroll(object sender, EventArgs e)
		{
			m_r.m_controller.Opacity = (double)trkPacity.Value/100.0d;
		}
	}
}
