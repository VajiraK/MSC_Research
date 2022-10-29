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
	public partial class StructureEleCon : UserControl
	{
		private CellCon[] m_cells = new CellCon[9];
		//---------------------------------------------------------------------------
		public StructureEleCon()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		private void StructureEleCon_Load(object sender, EventArgs e)
		{
			int x = 0;
			int y = 0;
			for (int i = 0; i < 9; i++)
			{
				m_cells[i] = new CellCon();
				m_cells[i].Location = new Point(x,y);
				Controls.Add(m_cells[i]);
				x += 16;
				if (x==48)
				{
					x = 0;
					y += 16;
				}
			}
		}
		//---------------------------------------------------------------------------
		public short[,] GetStrucElement()
		{
			short[,] ele = new short[3,3];
			int c = 0;
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
					ele[x,y] = m_cells[c++].Value;
			}
			return ele;
		}
		//---------------------------------------------------------------------------
		private void styleOneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			short[,] ele = { { -1, 1, -1 }, { 1, 1, 1 }, { -1, 1, -1 } };
			SetStyle(ele);
		}
		//---------------------------------------------------------------------------
		private void style2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			short[,] ele = { { 1, -1, 1 }, { -1, -1, -1 }, { 1, -1, 1 } };
			SetStyle(ele);
		}
		//---------------------------------------------------------------------------
		private void style3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			short[,] ele = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
			SetStyle(ele);
		}
		//---------------------------------------------------------------------------
		private void style4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			short[,] ele = { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
			SetStyle(ele);
		}
		//---------------------------------------------------------------------------
		private void SetStyle(short[,] ele)
		{
			int c = 0;
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
					m_cells[c++].Value = ele[x, y];
			}
		}
	}
}
