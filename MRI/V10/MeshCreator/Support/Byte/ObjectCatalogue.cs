using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeshCreator
{
	public class CatalogueItem
	{
		public int StartSlide;
		public int EndSlide;
		public byte FillColor;
	}
	//###########################################################################
	public class ObjectCatalogue
	{
		int m_cur_index = -1;
		private CatalogueItem[] m_items = new CatalogueItem[ColorMarshal.MAX_OBJ];
		//---------------------------------------------------------------------------
		public void Add(CatalogueItem item)
		{
			m_items[++m_cur_index] = item;
		}
		//---------------------------------------------------------------------------
		public void RemoveLast()
		{
			m_items[m_cur_index--] = null;
		}
		//---------------------------------------------------------------------------
		public CatalogueItem GetItem(int index)
		{
			return m_items[index];
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{
			for (int i = 0; i < ColorMarshal.MAX_OBJ; i++)
				m_items[i] = null;
			m_cur_index = -1;
		}
		//---------------------------------------------------------------------------
		public int Count 
		{
			get { return m_cur_index+1; }
		}
	}
}
