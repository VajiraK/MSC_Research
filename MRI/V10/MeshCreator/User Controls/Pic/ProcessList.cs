using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeshCreator
{
	public enum ProcessType
	{
		Dilatation,
		Erosion,
		Opening,
		Closing,
		Threshold,
		Invert,
		GaussianSharpen,
		HistogramEqualization,
		ConservativeSmoothing,
		Median
	}
	//######################################################################
	public class ProcessItem
	{
		public ProcessType m_pro_type;
		public int th_max = 0;
		public int th_min = 0;
		public short[,] m_element;
	}
	//######################################################################
	public class ProcessList
	{
		private List<ProcessItem> m_list;
		//---------------------------------------------------------------------------
		public ProcessList(int c)
		{
			m_list = new List<ProcessItem>(c);
		}
		//---------------------------------------------------------------------------
		public void Clear()
		{
			m_list.Clear();
		}
		//---------------------------------------------------------------------------
		public void Remove(int i)
		{
			m_list.RemoveAt(i);
		}
		//---------------------------------------------------------------------------
		public void Add(ProcessItem pi)
		{
			m_list.Add(pi);
		}
		//---------------------------------------------------------------------------
		public int Count 
		{
			get {return m_list.Count; }
		}
		//---------------------------------------------------------------------------
		public ProcessItem GerItem(int i)
		{
			return m_list[i];
		}
	}

}
