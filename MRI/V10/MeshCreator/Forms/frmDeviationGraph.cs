using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeshCreator
{
	public partial class frmDeviationGraph : Form
	{
		public frmDeviationGraph()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void AddObjectGraph(DevGraph dg)
		{
			dg.Init();
			flowLayoutPanel1.Controls.Add(dg);
		}

		private void btnDivNormalize_Click(object sender, EventArgs e)
		{

		}

		private void frmDeviationGraph_Load(object sender, EventArgs e)
		{
			
		}
	}
}
