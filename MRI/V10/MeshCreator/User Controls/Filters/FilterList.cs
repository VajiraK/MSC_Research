using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;

namespace MeshCreator
{
	public partial class FilterList : UserControl
	{
		private References m_r;
		//---------------------------------------------------------------------------
		public FilterList()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
			threshold1.Init(r);
			dilaEroCon1.Init(r);
			Reset();
		}
		//---------------------------------------------------------------------------
		private void btnInvers_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Invert;
			m_r.m_pro_list.AddItem(pi, false);
		}
		//---------------------------------------------------------------------------
		private void btnSharpen_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.GaussianSharpen;
			m_r.m_pro_list.AddItem(pi,false);
		}
		//---------------------------------------------------------------------------
		public void DoThreshold(int min, int max)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Threshold;
			pi.th_min = min;
			pi.th_max = max;
			m_r.m_pro_list.AddItem(pi, false);
		}
		//---------------------------------------------------------------------------
		public void DoGrowShrink(ProcessItem pi)
		{
			m_r.m_pro_list.AddItem(pi, false);
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{
			this.Enabled = false;
			threshold1.Reset();
		}
		//---------------------------------------------------------------------------
		public void OnLoadImages()
		{
			this.Enabled = true;
		}
		//---------------------------------------------------------------------------
		private void cmdHisEqualization_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.HistogramEqualization;
			m_r.m_pro_list.AddItem(pi, false);
		}
		//---------------------------------------------------------------------------
		private void btnConseSmooth_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.ConservativeSmoothing;
			m_r.m_pro_list.AddItem(pi, false);
		}
		//---------------------------------------------------------------------------
		private void btnMedian_Click(object sender, EventArgs e)
		{
			ProcessItem pi = new ProcessItem();
			pi.m_pro_type = ProcessType.Median;
			m_r.m_pro_list.AddItem(pi, false);
		}

        private void threshold1_Load(object sender, EventArgs e)
        {

        }
	}
}
