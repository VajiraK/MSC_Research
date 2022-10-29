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
	public partial class ProcessListCon : UserControl
	{
		private References m_r;
		private PicExPipeline m_active_pic;
		//---------------------------------------------------------------------------
		public ProcessListCon()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;
			Reset();
		}
		//---------------------------------------------------------------------------
		private void cmbCurrentPic_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbCurrentPic.SelectedIndex==0)
                m_active_pic = m_r.m_pix_con.PicInter;
			else
                m_active_pic = m_r.m_pix_con.PicFinal;

			listView1.Items.Clear();
			ProcessList pl = m_active_pic.GetProcessList();
			for (int i = 0; i < pl.Count; i++)
				AddItem(pl.GerItem(i),true);
		}
		//---------------------------------------------------------------------------
		public void AddItem(ProcessItem pi,bool justfill)
		{
			listView1.SuspendLayout();
			ListViewItem li = listView1.Items.Add(listView1.Items.Count.ToString());
			li.SubItems.Add(pi.m_pro_type.ToString());
			li.SubItems.Add("N/A");

			if (!justfill)
			{
				m_active_pic.AddProcessItem(pi);
				UpdateFinalPic();
			}

			listView1.Items[listView1.Items.Count - 1].Selected = true;
			FormateListView();
			listView1.Select();
		}
		//---------------------------------------------------------------------------
		private void btnClear_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			m_active_pic.ClearProcessItems();
			UpdateFinalPic();
		}
		//---------------------------------------------------------------------------
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count!=0)
			{
				listView1.SuspendLayout();
				ListViewItem li = listView1.SelectedItems[0];
				m_active_pic.RemoveProcessItem(li.Index);
				UpdateFinalPic();
				listView1.Items.Remove(li);

				if (listView1.Items.Count!=0)
					listView1.Items[listView1.Items.Count - 1].Selected = true;
				FormateListView();
			}

			listView1.Select();
		}
		//---------------------------------------------------------------------------
		private void UpdateFinalPic()
		{
			if (cmbCurrentPic.SelectedIndex==0)
				m_r.m_pix_con.PicInter.ImageChanged();
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{
			this.Enabled = false;
			listView1.Items.Clear();
			m_active_pic = m_r.m_pix_con.PicInter;
			cmbCurrentPic.SelectedIndex = 0;
		}
		//---------------------------------------------------------------------------
		private void FormateListView()
		{
			bool b = false;
			int i = 0;
			foreach (ListViewItem item in listView1.Items)
			{
				item.Text = i.ToString();
				if (b)
					item.BackColor = Color.LightGray;
				else
					item.BackColor = Color.LightYellow;
				b = !b;
				i++;
			}
			listView1.ResumeLayout();
		}
		//---------------------------------------------------------------------------
		public void OnLoadImages()
		{
			this.Enabled = true;
		}
	}
}
