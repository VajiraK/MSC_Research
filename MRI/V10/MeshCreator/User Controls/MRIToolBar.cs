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
			btnSlideDev.Enabled = false;
			btnDiscard.Enabled = false;
			btnNextSel.Enabled = false;
			btnProBackward.Enabled = false;
			btnProFull.Enabled = false;
			btnProForward.Enabled = false;
			btnUndo.Enabled = false;
			btnSelect.Enabled = false;
			btnSelect.Checked = false;
			btnSaveCube.Enabled = false;
			cmbTolerance.SelectedIndex = 31;
		}
		//------------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;

			for (int i = 0; i < 151; i++)
				cmbTolerance.Items.Add(i.ToString());

			Reset();
		}
		//---------------------------------------------------------------------------
		private void btnSelect_Click(object sender, EventArgs e)
		{
			btnSelect.Checked = !btnSelect.Checked;
			if (btnSelect.Checked)
			{
                m_r.m_pix_con.PicFinal.OnStepChanged(MRISteps.Marking);
				m_r.m_img_list.Enabled = false;
			}
			else
			{
                m_r.m_pix_con.PicFinal.OnStepChanged(MRISteps.Processing);
				m_r.m_img_list.Enabled = true;
			}
		}
		//---------------------------------------------------------------------------
		public void OnLoadImages()
		{
			btnSlideDev.Enabled = false;
			btnDiscard.Enabled = false;
			btnNextSel.Enabled = false;
			btnProBackward.Enabled = false;
			btnProFull.Enabled = false;
			btnProForward.Enabled = false;
			btnUndo.Enabled = false;
			btnSelect.Enabled = true;
			btnSelect.Checked = false;
			m_r.m_img_list.Enabled = true;
		}
		//---------------------------------------------------------------------------
		public void OnObjectSelect()
		{
			m_r.m_pix_con.PicFinal.Step = MRISteps.Processing;
			btnDiscard.Enabled = false;
			btnNextSel.Enabled = false;
			btnProBackward.Enabled = true;
			btnProFull.Enabled = true;
			btnProForward.Enabled = true;
			btnUndo.Enabled = true;
			btnSelect.Enabled = false;
			btnSelect.Checked = false;
		}
		//---------------------------------------------------------------------------
		private void btnDiscard_Click(object sender, EventArgs e)
		{
			m_r.m_pix_con.PicFinal.UndoPropagate();
			m_r.m_img_list.ClearLastObjects();
			OnLoadImages();
		}
		//---------------------------------------------------------------------------
		private void btnNextSel_Click(object sender, EventArgs e)
		{
			btnSaveCube.Enabled = true;
			btnDiscard.Enabled = false;
			btnNextSel.Enabled = false;
			btnProBackward.Enabled = false;
			btnProFull.Enabled = false;
			btnProForward.Enabled = false;
			btnUndo.Enabled = false;
			btnSelect.Enabled = true;
			btnSelect.Checked = false;
			m_r.m_img_list.Enabled = true;
			m_r.m_pix_con.PicFinal.NextObject();
		}
		//---------------------------------------------------------------------------
		private void btnUndo_Click(object sender, EventArgs e)
		{
			m_r.m_pix_con.PicFinal.UndoObjectMark();
			m_r.m_img_list.Enabled = true;
			OnLoadImages();
		}
		//---------------------------------------------------------------------------
		public byte Tolerance 
		{
			get { return (byte)int.Parse(cmbTolerance.Text); }
		}
		//---------------------------------------------------------------------------
		private void btnSaveCube_Click(object sender, EventArgs e)
		{
			m_r.m_img_list.Save();
		}
		//---------------------------------------------------------------------------
		private void OnPropagate(MRIPropTypes pt)
		{
			btnSlideDev.Enabled = true;
			btnDiscard.Enabled = true;
			btnNextSel.Enabled = true;
			btnProBackward.Enabled = false;
			btnProFull.Enabled = false;
			btnProForward.Enabled = false;
			btnUndo.Enabled = false;
			btnSelect.Enabled = false;
			btnSelect.Checked = false;
			m_r.m_img_list.Enabled = true;
			m_r.m_pix_con.PicFinal.PropagateObject(pt);
		}
		//---------------------------------------------------------------------------
		private void btnProForward_Click(object sender, EventArgs e)
		{
			OnPropagate(MRIPropTypes.Forward);
		}
		//---------------------------------------------------------------------------
		private void btnProBackward_Click(object sender, EventArgs e)
		{
			OnPropagate(MRIPropTypes.Backward);
		}
		//---------------------------------------------------------------------------
		private void btnProFull_Click(object sender, EventArgs e)
		{
			OnPropagate(MRIPropTypes.Full);
		}
		//---------------------------------------------------------------------------
		private void btnSlideDev_Click(object sender, EventArgs e)
		{
			frmDeviationGraph f = new frmDeviationGraph();
			m_r.m_dev_form = f;
			if(m_r.m_img_list.AddSlideDevGraphs())
				f.ShowDialog(m_r.m_main_form);
		}


	}
}
