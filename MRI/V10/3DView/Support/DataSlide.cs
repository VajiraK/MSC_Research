using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DView
{
	class Branch
    {
        List<MyVertex> m_ver_list;
		//---------------------------------------------------------------------------
        public Branch(int nv)
        {
            m_ver_list = new List<MyVertex>(nv);
        }
		//---------------------------------------------------------------------------
		public void AddVertext(int x, int y, int col)
        {
            MyVertex v = new MyVertex();
            v.X = x;
            v.Y = y;
			v.m_col = col;
            m_ver_list.Add(v);
        }
		//---------------------------------------------------------------------------
        public MyVertex GetVertext(int i)
        {
            return m_ver_list[i];
        }
		//---------------------------------------------------------------------------
        public int VertexCount
        {
            get { return m_ver_list.Count; }
        }
		//---------------------------------------------------------------------------
		public MyVertex GetVertex(int vn, Point ap, float scale,float z)
		{
			MyVertex v1 = m_ver_list[vn];
			MyVertex v2 = new MyVertex((v1.X - ap.X) / scale,(v1.Y - ap.Y) / scale,z);
			//MyVertex v2 = new MyVertex(v1.X , v1.Y , z);
			return v2;
		}
    }
	//###############################################################################
	class MRIObject
	{
		List<Branch> m_bra_list;
		//---------------------------------------------------------------------------
		public MRIObject(int nb)
		{
			m_bra_list = new List<Branch>(nb);
		}
		//---------------------------------------------------------------------------
		public void AddBranch(Branch b)
		{
			m_bra_list.Add(b);
		}
		//---------------------------------------------------------------------------
		public Branch GetBranch(int i)
		{
			return m_bra_list[i];
		}
		//---------------------------------------------------------------------------
		public int BranchCount
		{
			get { return m_bra_list.Count; }
		}
	}
	//###############################################################################
	class DataSlide
	{
		List<MRIObject> m_obj_list;
		//---------------------------------------------------------------------------
		public DataSlide(int no)
		{
			m_obj_list = new List<MRIObject>(no);
		}
		//---------------------------------------------------------------------------
		public void AddObject(MRIObject o)
		{
			m_obj_list.Add(o);
		}
		//---------------------------------------------------------------------------
		public MRIObject GetObject(int i)
		{
			return m_obj_list[i];
		}
		//---------------------------------------------------------------------------
		public int ObjectCount
		{
			get { return m_obj_list.Count; }
		}
	}
}
