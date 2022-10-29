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
	public partial class DilaEroCon : UserControl
	{
		private References m_r;
		//---------------------------------------------------------------------------
		public DilaEroCon()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
		}
		//---------------------------------------------------------------------------
		private void btnDilatate_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Dilatation;
			pi.m_element = EleConDialate.GetStrucElement();
			m_r.m_filt_list.DoGrowShrink(pi);
		}
		//---------------------------------------------------------------------------
		private void btnErode_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Erosion;
			pi.m_element = EleConErode.GetStrucElement();
			m_r.m_filt_list.DoGrowShrink(pi);
		}
		//---------------------------------------------------------------------------
		private void btnOpen_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Opening;
			pi.m_element = EleConOpen.GetStrucElement();
			m_r.m_filt_list.DoGrowShrink(pi);
		}
		//---------------------------------------------------------------------------
		private void btnClose_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Closing;
			pi.m_element = EleConClose.GetStrucElement();
			m_r.m_filt_list.DoGrowShrink(pi);
		}
	}
}
