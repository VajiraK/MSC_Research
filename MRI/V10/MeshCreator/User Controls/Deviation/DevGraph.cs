using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace MeshCreator
{
	public partial class DevGraph : UserControl
	{
		public DevGraph()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void Init()
		{
			graphY.AxisName = "Y Axis Deviation";
		}
		//---------------------------------------------------------------------------
		public void DrawGraphs(ByteCube bc ,CatalogueItem citem)
		{
			graphX.Image = DrawGraph(bc,citem,true); ;
			graphY.Image = DrawGraph(bc,citem,false); ;
		}
		//---------------------------------------------------------------------------
		private Bitmap DrawGraph(ByteCube bc,CatalogueItem citem,bool xaxis)
		{
			MySize slidesize = bc.Size;
			Size gs = graphX.GraphSize;
			Bitmap bmp = new Bitmap(gs.Width,gs.Height,PixelFormat.Format24bppRgb);
			Graphics g = Graphics.FromImage(bmp);
			int gycenter = gs.Height/2;
			int i;
			MyColor mc;
			MRIObject obj = null;
		
			//Proportional coordinate mappings
			double xp = (double)gs.Width / (double)bc.Count;
			double yp = 0;
			if (xaxis)
				yp = (double)gs.Height / (double)slidesize.Width;
			else
				yp = (double)gs.Height / (double)slidesize.Height;
				
			int gy = 0;
			int c = 0;

			//Genatate graph coordinates
			Point[] gparr = new Point[citem.EndSlide-citem.StartSlide+1];
			for (i = citem.StartSlide; i <= citem.EndSlide; i++)
			{
				obj = bc.GetImage(i).GetObjectByFill(citem.FillColor);
				gparr[c].X = (int)(xp * (double)i);

				if (xaxis)
					gy = (int)((double)obj.Centroid.x * yp);
				else
					gy = (int)((double)obj.Centroid.y * yp);

				gparr[c++].Y =  gy;
			}

			//Drawing the graph
			mc = ColorMarshal.Marshal(citem.FillColor);
			Color col = Color.FromArgb(mc.r, mc.g, mc.b);
			picObjColor.BackColor = col;
			Pen linep = new Pen(col);
			g.Clear(Color.White);
			g.DrawLines(linep,gparr);
			return bmp;
		}
		//---------------------------------------------------------------------------
		public void SetGraphBounds(int nobj,int amin, int amid, int amax, int smin, int smid, int smax)
		{
			string[] sarr= new  string[6]{amin.ToString(),amid.ToString(),amax.ToString(),smin.ToString(),smid.ToString(),smax.ToString()}; 
			lblObjectName.Text = string.Format("Object {0}",nobj);
			graphX.SetBounds(sarr);
			graphY.SetBounds(sarr);
		}
		//---------------------------------------------------------------------------
		private void DevGraph_Load(object sender, EventArgs e)
		{

		}
	}
}
