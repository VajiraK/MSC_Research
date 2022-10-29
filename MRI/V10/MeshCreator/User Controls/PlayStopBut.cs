using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace MeshCreator
{
	public partial class PlayStopBut : UserControl
	{
		private References m_r;
		private bool m_start;
		//---------------------------------------------------------------------------
		public PlayStopBut()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
		}
		//---------------------------------------------------------------------------
		private void button1_Click(object sender, EventArgs e)
		{
			m_start = !m_start;

			if (m_start)
			    button1.Image = global::MeshCreator.Properties.Resources.img_stop;
			else
			    button1.Image = global::MeshCreator.Properties.Resources.img_play;
					
			m_r.m_tool_bar.Enabled = !m_start;
			tmrPlay.Enabled = m_start;
		}
		//---------------------------------------------------------------------------
		private void PlayStopBut_Load(object sender, EventArgs e)
		{
			m_start = false;
			button1.Image = global::MeshCreator.Properties.Resources.img_play;
		}
		//---------------------------------------------------------------------------
		private void trkPlaySpeed_Scroll(object sender, EventArgs e)
		{
			int val = trkPlaySpeed.Value;
			tmrPlay.Interval = val;
			toolTip1.SetToolTip(trkPlaySpeed, val.ToString() + " ms");
		}
		//---------------------------------------------------------------------------
		public void Stop()
		{
			tmrPlay.Stop();
			button1.Image = global::MeshCreator.Properties.Resources.img_play;
			m_r.m_tool_bar.Enabled = true;
			m_start = false;
		}
		//---------------------------------------------------------------------------
		private void tmrPlay_Tick(object sender, EventArgs e)
		{
			m_r.m_img_list.Tmr_Tick();
		}
	}
}
