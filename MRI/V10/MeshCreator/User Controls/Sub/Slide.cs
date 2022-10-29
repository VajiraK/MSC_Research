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
	public partial class Slide : UserControl
	{
		private bool m_current = false;//This is the slide currently displaying
		private bool m_selected = false;//Selected for saving
		private bool m_boolmark = false;
		private References m_r;
		public int m_num;//Slide number(Tag property contain as string)
		//------------------------------------------------------------------------------
		public Slide()
		{
			InitializeComponent();
			this.BackColor = Color.White;
			picSelect.BackColor = Color.LightGray;
			PicBookmark.BackColor = Color.LightGray;
			picSelect.MouseEnter += new System.EventHandler(Pic_MouseEnter);
			PicBookmark.MouseEnter += new System.EventHandler(Pic_MouseEnter);
			picSelect.MouseLeave += new System.EventHandler(Pic_MouseLeave);
			PicBookmark.MouseLeave += new System.EventHandler(Pic_MouseLeave);	
		}
		//---------------------------------------------------------------------------
		public void Init(References r,string snum,int num)
		{
			m_r = r;
			m_num = num;
			this.Tag = snum;
		}
		//------------------------------------------------------------------------------
		private void Pic_MouseEnter(object sender, EventArgs e)
		{
			if (!m_boolmark)
				PicBookmark.BackColor = Color.DarkGray;
			if ((!m_selected) && (!m_current))
				picSelect.BackColor = Color.DarkGray;
		}
		//------------------------------------------------------------------------------
		private void Pic_MouseLeave(object sender, EventArgs e)
		{
			if (!m_boolmark)
				PicBookmark.BackColor = Color.LightGray;
			if ((!m_selected)&&(!m_current))
				picSelect.BackColor = Color.LightGray;
		}
		//------------------------------------------------------------------------------
		private void PicBookmark_Click(object sender, EventArgs e)
		{
			m_boolmark = !m_boolmark;

			if (m_boolmark)
			{
				PicBookmark.BackColor = Color.Red;
			}else{
				PicBookmark.BackColor = Color.LightGray;
			}
		}
		//------------------------------------------------------------------------------
		private void picSelect_Click(object sender, EventArgs e)
		{
			m_r.m_img_list.SlideChanged(this);
		}
		//------------------------------------------------------------------------------
		public Control SetTip
		{
			get
			{
				return picSelect;
			}
		}
		//------------------------------------------------------------------------------
		public bool Current 
		{
			set
			{
				m_current = value;
				if (m_current)
				{
					if (m_selected)
						picSelect.BackColor = Color.Black;//Both selected and current
					else
						picSelect.BackColor = Color.Blue;
				}else{
					if (m_selected)
						picSelect.BackColor = Color.Gold;
					else
						picSelect.BackColor = Color.LightGray;
				}
			}
		}
		//------------------------------------------------------------------------------
		public bool Selected
		{
			set
			{
				m_selected = value;
				if (m_selected)
				{
					if (m_current)
						picSelect.BackColor = Color.Black;//Both selected and current
					else
						picSelect.BackColor = Color.Gold;
				}else{
					if (m_current)
						picSelect.BackColor = Color.Blue;
					else
						picSelect.BackColor = Color.LightGray;
				}
			}
		}
		//------------------------------------------------------------------------------
		private void picSelect_DoubleClick(object sender, EventArgs e)
		{
			if(Control.ModifierKeys == Keys.Shift)
				m_r.m_img_list.Slide_DoubleClick(this,true);
			else
				m_r.m_img_list.Slide_DoubleClick(this, false);
		}
	}
}
