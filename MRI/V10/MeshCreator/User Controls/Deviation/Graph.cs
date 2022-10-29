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
	public partial class Graph : UserControl
	{
		public Graph()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public string AxisName 
		{
			set { lblAxis.Text = value; } 
		}
		//---------------------------------------------------------------------------
		public Bitmap Image
		{
			set { pictureBox1.Image = value; } 
		}
		//---------------------------------------------------------------------------
		public Size GraphSize 
		{
			get { return pictureBox1.Size; }
		}
		//---------------------------------------------------------------------------
		public void SetBounds(string[] sarr)
		{
			lblAxisMin.Text = sarr[0];
			lblAxisMid.Text = sarr[1];
			lblAxisMax.Text = sarr[2];
			lblSlideMin.Text = sarr[3];
			lblSlideMid.Text = sarr[4];
			lblSlideMax.Text = sarr[5];
		}
		//---------------------------------------------------------------------------
		private void Graph_Load(object sender, EventArgs e)
		{

		}
	}
}
