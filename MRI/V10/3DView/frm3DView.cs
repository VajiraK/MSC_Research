using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace _3DView
{
	public partial class frm3DView : Form
	{
		private References m_r;
		//---------------------------------------------------------------------------
		public frm3DView()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		private void frm3DView_Load(object sender, EventArgs e)
		{
			m_r				= new References();
			m_r.m_state		= new State();
			m_r.m_controller = new frmControlPanel();
			m_r.m_main_form = this;
			m_r.m_glscreen	= scrMain;
			m_r.m_glcontro	= scrMain.Init(m_r);
			m_r.m_controller.Init(m_r);
			mriToolBar1.Init(m_r);
		}
		//---------------------------------------------------------------------------
		public void ShowController()
		{
			if (m_r.m_controller.WindowState == FormWindowState.Minimized)
				m_r.m_controller.WindowState = FormWindowState.Normal;

			m_r.m_controller.Show();
			m_r.m_controller.BringToFront();
		}
		//---------------------------------------------------------------------------
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		//---------------------------------------------------------------------------
		public void open3DFile()
		{
			m_r.m_glscreen.Terminate();
			m_r.m_glscreen.Init(m_r);
			m_r.m_glscreen.Visible = false;

			OpenFileDialog of = new OpenFileDialog();
			of.Filter = "MRICube File(s)|*.mric";

			if (of.ShowDialog() == DialogResult.OK)
			{
				m_r.m_glscreen.SupressMouseEvents(500);//Prevent triggering mouse events to preserve MV matrix state
				m_r.m_state.Reset();
				LoadCubeFile(of.FileName);
			}
			m_r.m_glscreen.Visible = true;
		}
		//---------------------------------------------------------------------------
		private void saveStateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sf = new SaveFileDialog();
			sf.Filter = "MRICube State File(s)|*.mris";
			if (sf.ShowDialog() == DialogResult.OK)
			{
				m_r.m_state.Serialize(sf.FileName);
			}
		}
		//---------------------------------------------------------------------------
		private void openStateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = "MRICube File(s)|*.mris";
			if (of.ShowDialog() == DialogResult.OK)
			{
				State st = State.Deserialize(of.FileName);
				if (st!=null)
				{
					m_r.m_state = st;
					LoadCubeFile(st.m_path);
				}else{
					MessageBox.Show("Unable to open that file!");
				}
			}
		}
		//---------------------------------------------------------------------------
		private void LoadCubeFile(string path)
		{
			if (m_r.m_glscreen.LoadDataCube(path))
			{
				m_r.m_state.m_path = path;
				this.Text = "MRI-3DView [" + Path.GetFileName(path) + "]";
				return;
			}
			MessageBox.Show("Unable to open that file! \nPath - " + path);
		}
	}
}
