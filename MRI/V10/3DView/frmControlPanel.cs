using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DView
{
	public partial class frmControlPanel : Form
	{
		private References m_r;
		//---------------------------------------------------------------------------
		public frmControlPanel()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public Point AxisPoint
		{
			get
			{
				return picCossView.AxisPoint;
			}
		}
		//---------------------------------------------------------------------------
		public void Init(References r)
		{
			m_r = r;

			MyTrackVal tval;
			tval.min = 0; tval.max = 360; tval.val = 0;
			trkRotX.Init(m_r, "X", tval, MyTrackType.RotX);
			trkRotY.Init(m_r, "Y", tval, MyTrackType.RotY);
			trkRotZ.Init(m_r, "Z", tval, MyTrackType.RotZ);
			trkLghX.Init(m_r, "XRot", tval, MyTrackType.Ligx);
			trkLghY.Init(m_r, "YRot", tval, MyTrackType.Ligy);

			tval.min = (int)MyTrkConstant.OZTraMin; tval.max = (int)MyTrkConstant.OZTraMax; tval.val = 0;
			trkTraZ.Init(m_r, "Z", tval, MyTrackType.TransZ);
			trkLghPos.Init(m_r, "ZPos", tval, MyTrackType.LigPos);

			tval.min = (int)MyTrkConstant.OXTraMin; tval.max = (int)MyTrkConstant.OXTraMax; tval.val = 0;
			trkTraX.Init(m_r, "X", tval, MyTrackType.TransX);
			tval.min = (int)MyTrkConstant.OYTraMin; tval.max = (int)MyTrkConstant.OYTraMax; tval.val = 0;
			trkTraY.Init(m_r, "Y", tval, MyTrackType.TransY);

			picCossView.Init(m_r);
		}
		//---------------------------------------------------------------------------
		//public void SetTrkValues(int w, int h)
		//{
		//    MyTrackVal tval;
		//    w = w / 2;
		//    tval.min = -w; tval.max = w; tval.val = 0;
		//    trkTraX.Init(m_r, "X", tval, MyTrackType.TransX);

		//    h = h / 2;
		//    tval.min = -h; tval.max = h; tval.val = 0;
		//    trkTraY.Init(m_r, "Y", tval, MyTrackType.TransY);
		//}
		//---------------------------------------------------------------------------
		public void TrackerChanged(MyTrackType sender, int val)
		{//Set Tracker val according to GLScreen mouse events
			switch (sender)
			{
				case MyTrackType.TransX:
					trkTraX.SetValue(val); break;
				case MyTrackType.TransY:
					trkTraY.SetValue(val); break;
				case MyTrackType.TransZ:
					trkTraZ.SetValue(val); break;
				case MyTrackType.RotX:
					trkRotX.SetValue(val); break;
				case MyTrackType.RotY:
					trkRotY.SetValue(val); break;
				case MyTrackType.RotZ:
				//m_zRot = val; break;
				case MyTrackType.Ligx:
				//m_xLRot = val; break;
				case MyTrackType.Ligy:
				//m_yLRot = val; break;
				case MyTrackType.LigPos:
				//lightPos[2] = val; break;
				default:
					break;
			}
		}
		//---------------------------------------------------------------------------
		private void frmControlPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
		}
		//---------------------------------------------------------------------------
		public void SetCrossImage(CrossViewData cdata)
		{
			picCossView.SetCrossImage(cdata);
		}
	}
}
