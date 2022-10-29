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
	public partial class PointInfo : UserControl
	{
		private References m_r;
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
		}
		//---------------------------------------------------------------------------
		public PointInfo()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void SetInfo(Color c,Point m,Point off)
		{
			lblInfo.Text = string.Format("X - {0}\nY - {1}",m.X,m.Y);
			picColor.BackColor = c;
			//Point p = m_r.m_main_form.Location ;
			m.X -= off.X-10;
			m.Y -= off.Y;
			this.Location = m;
			this.Refresh();
		}
		//---------------------------------------------------------------------------
		private void PointInfo_Load(object sender, EventArgs e)
		{
			this.Size = new Size(63, 71);
		}
	}
}
