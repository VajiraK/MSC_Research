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
	public partial class CellCon : UserControl
	{
		private short m_val = -1;
		//---------------------------------------------------------------------------
		public CellCon()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public short Value 
		{
			get { return m_val; }
			set
			{
				if (value==1)
				{
					BackColor = Color.White;
					m_val = 1;
				}
				if (value == -1)
				{
					BackColor = Color.Black;
					m_val = -1;
				}
			}
		}
		//---------------------------------------------------------------------------
		private void CellCon_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (BackColor == Color.Black)
				{
					BackColor = Color.White;
					m_val = 1;
				}
				else
				{
					BackColor = Color.Black;
					m_val = -1;
				}
			}
		}
	}
}
