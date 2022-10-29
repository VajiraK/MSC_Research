using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AFI = AForge.Imaging;

namespace MeshCreator
{
	public partial class PicExFinal : PicExPipeline
	{
		private FloodFillInfo m_ffi;
		private PictureBox m_picbox;
		private MRISteps m_step;
		private ByteImage m_bi;//Reference to the currently selected ByteImage of ImageList
		//---------------------------------------------------------------------------
		public PicExFinal()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public MRISteps Step 
		{ 
			set { m_step = value; } 
		}
		//---------------------------------------------------------------------------
		public void SetImage(UmImage image, ByteImage bi)
		{
			m_bi = bi;
			base.SetImage(image);
		}
		//------------------------------------------------------------------------------
		public new void Init(References r)
		{
			base.Init(r);
			m_picbox = base.PicBox;
			m_ffi = new FloodFillInfo();
			m_picbox.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
			m_picbox.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
			Reset();
		}
		//------------------------------------------------------------------------------
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
            if (m_picbox.Image != null)
                m_r.m_pix_con.DrawHoverCircle(e.Location);
		}
		//---------------------------------------------------------------------------
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			if (ColorMarshal.IsInvalied(m_ffi.m_obj_fill))
			{
			    IP.MRIMessageBox("Maximum number of objects already selected!");
			    return;
			}

			if (m_step == MRISteps.Marking)
			{
				UmImage um = this.ProcessedUnImage;
				m_ffi.m_bi = m_bi;
				m_ffi.m_start_point = new MyPoint(e.Location);
				m_ffi.m_tarcol = um.GetPix(m_ffi.m_start_point);
				m_ffi.SetTolerance(m_r.m_tool_bar.Tolerance);

				if (IP.FloodFill(m_ffi) != 0)
				{
					MRIObject obj = m_ffi.m_bi.GetObjectByFill(m_ffi.m_obj_fill);
					m_r.m_pix_con.PicOver.MarkObjects(m_bi);
					m_r.m_tool_bar.OnObjectSelect();
				}
			}
		}
		//---------------------------------------------------------------------------
		public void PropagateObject(MRIPropTypes pt)
		{
			//FloodFillInfo f = m_ffi;
			//f.m_obj_fill--;
			m_r.m_img_list.PropagateObject(m_ffi,pt);
		}
		//---------------------------------------------------------------------------
		public new void Reset()
		{
			m_ffi.m_obj_fill = ColorMarshal.GetFirstFill();
			m_step = MRISteps.Processing;
			base.Reset();
		}
		//---------------------------------------------------------------------------
		public void UndoObjectMark()
		{
			//m_ffi.m_obj_fill--;
			m_bi.ClearLastObject();
            m_r.m_pix_con.PicOver.MarkObjects(m_bi);
		}
		//---------------------------------------------------------------------------
		public void NextObject() 
		{
			m_ffi.m_obj_fill = ColorMarshal.GetNextFill(m_ffi.m_obj_fill);
		}
		//---------------------------------------------------------------------------
		public void UndoPropagate() 
		{
			//m_ffi.m_obj_fill--;
		}
		//---------------------------------------------------------------------------
		public void OnStepChanged(MRISteps st)
		{
			m_step = st;
			if (m_step== MRISteps.Marking)
				m_bi.UpdateFromUm(base.ProcessedUnImage);//Updating the cerrent slide ByteImage
		}

		private void PicExFinal_Load(object sender, EventArgs e)
		{

		}
	}
}
