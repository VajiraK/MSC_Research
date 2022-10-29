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
	public partial class DoubleSlider : UserControl
	{
		private Threshold m_threshold;
		//---------------------------------------------------------------------------
		public void Init(Threshold threshold)
		{
			m_threshold = threshold;
		}
		//---------------------------------------------------------------------------
		public DoubleSlider()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		private void trkMin_Scroll(object sender, EventArgs e)
		{
			if (trkMin.Value > trkMax.Value)
				trkMin.Value = trkMax.Value - 1;
			
			lblMin.Text = trkMin.Value.ToString();
			m_threshold.DoublTrack_Scroll(trkMin.Value, trkMax.Value);
		}
		//---------------------------------------------------------------------------
		private void trkMax_Scroll(object sender, EventArgs e)
		{
			if (trkMin.Value > trkMax.Value)
				trkMax.Value = trkMin.Value + 1;
			lblMax.Text = trkMax.Value.ToString();
			m_threshold.DoublTrack_Scroll(trkMin.Value, trkMax.Value);
		}
		//---------------------------------------------------------------------------
		private void DoubleSlider_Load(object sender, EventArgs e)
		{
			trkMax.Value = trkMax.Maximum;
			lblMax.Text = trkMax.Maximum.ToString();
		}
		//---------------------------------------------------------------------------
		public void SetValues(int minval,int maxval)
		{
			trkMin.Value = minval;
			trkMax.Value = maxval;
		}
	}
}
