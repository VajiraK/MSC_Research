using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MeshCreator
{
    public class frmMain : Form
    {
        private FilterList m_fil_list = new FilterList();
        private ProcessListCon m_pro_list = new ProcessListCon();
        private ImageListEx m_img_lst = new ImageListEx();
        private PicContainer m_pic_con = new PicContainer();
        private SplitContainer m_split_main = new SplitContainer();
        private MRIToolBar m_toolbar = new MRIToolBar();
        private References m_ref = new References();
        private ImageProcessor m_img_proc = new ImageProcessor();//One and only instance :)
        //---------------------------------------------------------------------------
        public frmMain()
        {
            this.SuspendLayout();
            //From properties
            this.Text = "MRICube File Creator";
            this.Size = new Size(850,650);
            this.MinimumSize = new Size(500, 400);
            //Toolbar
            m_toolbar.Dock = DockStyle.Top;
            this.Controls.Add(m_toolbar);
            //m_pic_con
            m_pic_con.Dock = DockStyle.Fill;
            //ProcessListCon
            m_pro_list.Size = new Size(293, 300);
            //FilterList
            m_fil_list.Top = 300;
            //m_split_main
            m_split_main.Size = new System.Drawing.Size(this.Width - 16, this.Height - 185);
            m_split_main.SplitterDistance = 514;
            m_split_main.IsSplitterFixed = true;
            m_split_main.FixedPanel = FixedPanel.Panel2;
            m_split_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            m_split_main.Location = new System.Drawing.Point(0, 38);
            m_split_main.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            m_split_main.TabIndex = 0;
            m_split_main.Panel1.Controls.Add(m_pic_con);
            m_split_main.Panel2.AutoScroll = true;
            m_split_main.Panel2.Controls.Add(m_pro_list);
            m_split_main.Panel2.Controls.Add(m_fil_list);
            this.Controls.Add(m_split_main);
            //ImageListEx
            m_img_lst.Dock = DockStyle.Bottom;
            this.Controls.Add(m_img_lst);
            this.ResumeLayout();
            //************************************
            //Set references
            m_ref.m_main_form = this;
            m_ref.m_tool_bar = m_toolbar;
            m_toolbar.Init(m_ref);
            m_ref.m_pix_con = m_pic_con;
            m_pic_con.Init(m_ref);
            m_ref.m_pro_list = m_pro_list;
            m_pro_list.Init(m_ref);
            m_ref.m_filt_list = m_fil_list;
            m_fil_list.Init(m_ref);
            m_ref.m_img_pro = m_img_proc;
            m_img_proc.Init(m_ref);
            m_ref.m_img_list = m_img_lst;
            m_img_lst.Init(m_ref);
        }
		//---------------------------------------------------------------------------
		public void ResetApplication()
		{
			m_ref.m_img_list.Reset();
			m_ref.m_filt_list.Reset();
			m_ref.m_pro_list.Reset();
            m_ref.m_pix_con.Reset();
			m_ref.m_tool_bar.Reset();
			IP.GCCollect();
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{

		}
		//---------------------------------------------------------------------------
		public void OnLoadImages(bool start)
		{
			if (start)
			{
				m_ref.m_main_form.Enabled = false;
				m_ref.m_flash_form = new frmFlash();
				this.Enabled = false;
				m_ref.m_flash_form.Show();
				Application.DoEvents();
			}
			else
			{
				m_ref.m_flash_form.Close();
				m_ref.m_main_form.Enabled = true;
				m_ref.m_filt_list.OnLoadImages();
				m_ref.m_pro_list.OnLoadImages();
				m_ref.m_tool_bar.OnLoadImages();
			}
		}
        //---------------------------------------------------------------------------
		public void OnPropagate(bool start)
        {
			if (start)
			{
				m_ref.m_flash_form = new frmFlash();
				this.Enabled = false;
				m_ref.m_flash_form.Show();
				Application.DoEvents();
			}else{
				m_ref.m_flash_form.Close();
				this.Enabled = true;
			}
        }

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// frmMain
			// 
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Name = "frmMain";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);

		}

		private void frmMain_Load(object sender, EventArgs e)
		{

		}
        //---------------------------------------------------------------------------
    }
}
