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
	public partial class MRIToolBar : UserControl
	{
		private References m_r;
		//---------------------------------------------------------------------------
		public MRIToolBar()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{

		}
		//------------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
			Reset();
		}
		//------------------------------------------------------------------------------
		private void btnOpen_Click(object sender, EventArgs e)
		{
			m_r.m_main_form.open3DFile();
		}
		//---------------------------------------------------------------------------
		private void btnShowController_Click(object sender, EventArgs e)
		{
			m_r.m_main_form.ShowController();
		}
		//---------------------------------------------------------------------------
		private void MRIToolBar_Load(object sender, EventArgs e)
		{
			this.Width = 22;
		}
		//---------------------------------------------------------------------------
	}
}
