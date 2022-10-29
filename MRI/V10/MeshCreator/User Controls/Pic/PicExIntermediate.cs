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
	public partial class PicExIntermediate : PicExPipeline
	{
		ByteImage m_bi;//Reference to the currently selected ByteImage of ImageList
		//---------------------------------------------------------------------------
		public PicExIntermediate()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void SetImage(ByteImage bi)
		{
			m_bi = bi;
			base.SetImage(m_bi.OriUm);
			ImageChanged();
		}
		//---------------------------------------------------------------------------
		public void ImageChanged()
		{
			m_r.m_pix_con.PicFinal.SetImage(base.ProcessedUnImage, m_bi);
		}
	}
}
