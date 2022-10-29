using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AFI = AForge.Imaging;
using AForge;

namespace MeshCreator
{
	public partial class PicExPipeline : PicEx
	{
		private UmImage m_ori_image;
		private UmImage m_pro_image;
		private ProcessList m_pro_list = new ProcessList(10);
		//---------------------------------------------------------------------------
		public ProcessList GetProcessList()
		{
			return m_pro_list;
		}
		//---------------------------------------------------------------------------
		public PicExPipeline()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		protected UmImage ProUmImage
		{
			get { return m_pro_image; }
		}
		//---------------------------------------------------------------------------
		public void ClearProcessItems()
		{
			m_pro_list.Clear();
			ExecuteProcessList();
		}
		//---------------------------------------------------------------------------
		public void RemoveProcessItem(int i)
		{
			m_pro_list.Remove(i);
			ExecuteProcessList();
		}
		//---------------------------------------------------------------------------
		public void AddProcessItem(ProcessItem pi)
		{
			ApplyProcessItem(m_pro_image,pi);
			m_pro_list.Add(pi);
			base.SetImage(m_pro_image);
		}
		//---------------------------------------------------------------------------
		private void ExecuteProcessList()
		{
			m_pro_image = m_ori_image.Clone();
			ExecuteProcessList(m_pro_image);
			base.SetImage(m_pro_image);
		}
		//---------------------------------------------------------------------------
		public void ExecuteProcessList(UmImage image)
		{
			for (int i = 0; i < m_pro_list.Count; i++)
				ApplyProcessItem(image, m_pro_list.GerItem(i));
		}
		//---------------------------------------------------------------------------
		private void ApplyProcessItem(UmImage image,ProcessItem pi)
		{
			switch (pi.m_pro_type)
			{
				case ProcessType.Threshold:
					IP.Threshold(image, pi);
					break;
				case ProcessType.Invert:
					IP.Invert(image);
					break;
				case ProcessType.Dilatation:
				case ProcessType.Erosion:
				case ProcessType.Opening:
				case ProcessType.Closing:
					IP.GrowShrink(image, pi);
					break;
				case ProcessType.GaussianSharpen:
					IP.GaussianSharpen(image);
					break;
				case ProcessType.HistogramEqualization:
					IP.HistogramEq(image);
					break;
				case ProcessType.ConservativeSmoothing:
					IP.ConservativeSmooth(image);
					break;
				case ProcessType.Median:
					IP.MedianFilter(image);
					break;
				default:
					break;
			}
		}
		//---------------------------------------------------------------------------
		protected new void SetImage(UmImage um)
		{
			m_ori_image = um.Clone();
			ExecuteProcessList();
		}
		//---------------------------------------------------------------------------
		public UmImage ProcessedUnImage
		{
			get { return m_pro_image; }
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{
			m_pro_list.Clear();
			m_ori_image = null;
			m_pro_image = null;
		}
	}
}
