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
    public partial class Threshold : UserControl
    {
        //private ByteImage		m_bi;
        private Bitmap          m_his_bit;
        private int             m_h, m_w,m_min,m_max;
        private Graphics        m_pic_gra,m_bit_gra;
		private SolidBrush		m_his_brush = new SolidBrush(Color.FromArgb(50, 240, 120, 0));
		private Rectangle		m_rect;
		private int[]           m_his;
        private References      m_r;
        //---------------------------------------------------------------------------
        public Threshold()
        {
            InitializeComponent();
        }
		//---------------------------------------------------------------------------
		public void Reset()
		{
			//m_bi = null;
			tmrRefresh.Enabled = true;
			m_min = 120;
			m_max = 130;
			doubleSlider1.SetValues(m_min, m_max);
		}
        //---------------------------------------------------------------------------
		public Bitmap Image
		{
			set
			{
				//m_bi = new ByteImage(value, m_r);
				//m_his = m_r.m_img_pro.GetByteHisto(m_bi);
				//PrepareHistogram();
				//tmrRefresh.Enabled = true;
				//this.Enabled = true;
			}
		}
        //---------------------------------------------------------------------------
        public void Init(References r)
        {
            m_r = r;
			m_rect = new Rectangle(0, 0, 10, picThreshold.Height - 2);
			doubleSlider1.Init(this);
			Reset();
        }
        //---------------------------------------------------------------------------
        private void trackBarLevel_Scroll(object sender, EventArgs e)
        {
            tmrRefresh.Enabled = true;
        }
		//---------------------------------------------------------------------------
		public void DoublTrack_Scroll(int min,int max)
		{
			m_min = min;
			m_max = max;
			tmrRefresh.Enabled = true;
		}
        //---------------------------------------------------------------------------
        private void Threshold_Load(object sender, EventArgs e)
        {
            m_pic_gra = picThreshold.CreateGraphics();
            m_w = picThreshold.Width;
            m_h = picThreshold.Height;
            m_his_bit = new Bitmap(m_w, m_h, m_pic_gra);
            m_bit_gra = Graphics.FromImage(m_his_bit);
        }
        //-------------------------------------------------------------------------------
        private void PrepareHistogram()
        {
            int i, hmax = 0;
            int h = m_h - 7;
            Point p1 = new Point(0, h);
            Point p2 = new Point(0, 0);
            double hcon,hline = 0;

            m_bit_gra.Clear(Color.White);

            for (i = 0; i < 256; i++)
            {
                if (hmax < m_his[i])
                    hmax = m_his[i];
            }

            hcon = h / (double)hmax;

            for (i = 0; i < 256; i++)
            {
                if (m_his[i]!=0)
                {
                    p1.X = i + 2;
                    p2.X = p1.X;
                    hline = m_his[i] * hcon;
                    p2.Y = h - (int)hline;
                    m_bit_gra.DrawLine(new Pen(Color.DarkGray, 1), p1, p2);
                }
            }
        }
        //-------------------------------------------------------------------------------
        private void picThreshold_Paint(object sender, PaintEventArgs e)
        {
            tmrRefresh.Enabled = true;
        }
        //-------------------------------------------------------------------------------
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
			//tmrRefresh.Enabled = false;
			//if (m_bi != null)
			//{
			//    m_pic_gra.DrawImage(m_his_bit, 0, 0);
			//    Application.DoEvents();
			//    m_rect.X = m_min+2;
			//    m_rect.Width = m_max - m_min;
			//    m_pic_gra.FillRectangle(m_his_brush, m_rect);
			//    //ByteImage tmp = m_bi.Clone();
			//    //tmp.Threshold(m_min, m_max);
			//}else{
			//    m_pic_gra.Clear(Color.White);
			//}
        }
        //-------------------------------------------------------------------------------
        private void chkInverse_CheckedChanged(object sender, EventArgs e)
        {
            tmrRefresh.Enabled = true;
        }
		//---------------------------------------------------------------------------
		private void btnApply_Click(object sender, EventArgs e)
		{
			m_r.m_filt_list.DoThreshold(m_min, m_max);
		}
    }
}
