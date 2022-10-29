using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DView
{
	public struct MyTrackVal
	{
		public int min;
		public int max;
		public int val;
	}
	//---------------------------------------------------------------------------
	public enum MyTrkConstant
	{
		OXTraMin = -200,
		OXTraMax = 200,

		OYTraMin = OXTraMin,
		OYTraMax = OXTraMax,

		PMaxDepth	= 400,//Perspective view depth
		LookAtz		= 50,//Look at eye z location
		OZTraMin	= -PMaxDepth + 50,
		OZTraMax	= 0,

		LZTraMin = 0,
	}
	//---------------------------------------------------------------------------
	public enum MyTrackType
	{
		RotX,
		RotY,
		RotZ,
		TransX,
		TransY,
		TransZ,
		Ligx,
		Ligy,
		LigPos
	}
	//#################################################################################
	public partial class TrackBarEx : UserControl
	{
		private References m_r;
		private MyTrackType m_type;
		//---------------------------------------------------------------------------
		public TrackBarEx()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void SetValues(MyTrackVal vals)
		{
			trackBar1.Minimum = vals.min;
			trackBar1.Maximum = vals.max;
			trackBar1.Value = vals.val;
			lblVal.Text = vals.val.ToString();
		}
		//---------------------------------------------------------------------------
		public void Init(References r, string text, MyTrackVal vals, MyTrackType type)
		{
			m_r = r;
			lblName.Text = text;
			m_type = type;
			SetValues(vals);
		}
		//---------------------------------------------------------------------------
		public void SetValue(int val)
		{
			trackBar1.Value = val;
			lblVal.Text = val.ToString();
		}
		//---------------------------------------------------------------------------
		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			lblVal.Text = trackBar1.Value.ToString();
			m_r.m_glscreen.TrackerChange(m_type, trackBar1.Value);
		}
	}
}
