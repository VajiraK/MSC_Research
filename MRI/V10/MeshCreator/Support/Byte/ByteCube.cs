using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace MeshCreator
{
	public class ByteCube
	{
		private List<ByteImage> m_image_list;
		private int				m_count;
		private MySize			m_size;
		private References		m_r;
		//---------------------------------------------------------------------------
		public ByteCube( MySize s,int intcount, References r)
		{
			m_image_list = new List<ByteImage>(intcount);
			m_size = s;
			m_count = 0;
			m_r = r;
		}
		//---------------------------------------------------------------------------
		public MySize Size 
		{
			get { return m_size; }
		}
		//---------------------------------------------------------------------------
		public ByteImage GetImage(int index)
		{
			return m_image_list[index];
		}
		//---------------------------------------------------------------------------
		public void AddImage(ByteImage bi)
		{
			MySize s = bi.Size; 
			if ((m_size.Width == s.Width) && (m_size.Height == s.Height))
			{
				m_image_list.Add(bi);
				m_count = m_image_list.Count;
			}else{
				IP.MRIMessageBox("Uneven image found!");
			}
		}
		//---------------------------------------------------------------------------
		public void Dispose()
		{
			for (int i = 0; i < m_count; i++)
				m_image_list[i].Dispose();
			m_image_list.Clear();
			IP.GCCollect();
		}
		//---------------------------------------------------------------------------
		public int Count 
		{
			get { return m_count; }
		}
		//---------------------------------------------------------------------------
		public List<ByteImage> ImageList 
		{ 
			get{return m_image_list;}
		}
		//---------------------------------------------------------------------------
		public void Save(string savepath, int from, int to)
		{
			int p;
			MemoryStream ms = new MemoryStream();
			BinaryWriter mbw = new BinaryWriter(ms);
			FileStream fs = new FileStream(savepath, FileMode.Create);
			BinaryWriter fbw = new BinaryWriter(fs);
            
			//Write signature VAJIRA-MRICUBE-V6
			byte[] sng = {86,65,74,73,82,65,45,77,82,73,67,85,66,69,45,86,56};
			mbw.Write(sng);
			//Write slides dimension 
			mbw.Write(m_size.Width);
			mbw.Write(m_size.Height);
			//Write no of slides
			to++;
			int i = to - from;
			mbw.Write(i);
			//Write axis point
            Point ap = m_r.m_pix_con.PicOver.AxisPoint;
			mbw.Write(ap.X); mbw.Write(ap.Y);
			//Write midle crossection image *******************
			i = i / 2;
            ByteImage bi = m_image_list[i + from];
			Byte[,] arr = bi.GetObjectMask();

			for (i = 0; i < m_size.Height; i++)
			{
				for (int j = 0; j < m_size.Width; j++)
				{
					mbw.Write(arr[j, i]);
				}
			}
			arr = null;
			//Write midle crossection image *******************
			int c = 0;
            int blen;
			MyPoint po;
			Stack<MyPoint> st = new Stack<MyPoint>(100);//Give stack for ByteImage (Efficient than one for each ByteImage)
			//CreateBoaders and Write objects for individual slide 
			for (i = from; i < to; i++)
			{
				bi = m_image_list[i];
				bi.CreateBoaders(st);
				mbw.Write(bi.ObjectCount);//Write no of Objects(Byte)
				for (int k = 0; k < bi.ObjectCount; k++)
				{
					MRIObject obj = bi.GetObjectByIndex(k);
					mbw.Write(obj.BranchCount);//Write no of Branches
					for (int j = 0; j < obj.BranchCount; j++)
					{
					    Branch bra = obj.GetBranch(j);
                        blen = bra.PointCount;
                        mbw.Write(blen);
                        //bra.Revers();
                        for (int m = 0; m < blen; m++)
					    {
                            po = bra.PopPoint(m);
					        mbw.Write((short)po.x);
					        mbw.Write((short)po.y);
					        mbw.Write((byte)255);
					    }
					}
				}

				if (c++==10)
				{//Write 10 slides at a time
					p = (int)ms.Position;//must get before closing ms
					mbw.Close();
					fbw.Write(ms.GetBuffer(), 0, p);// ms.GetBuffer().Length != p
					ms.Close();
					ms = null;
					c = 0;
					if (i < to)
					{//Still there are remaining slides so need ms
						ms = new MemoryStream();
						mbw = new BinaryWriter(ms);
					}
				}
			}

			if (ms!=null)
			{//ms contains data so write them to HD
				p = (int)ms.Position;//must get before closing ms
				mbw.Close();
				fbw.Write(ms.GetBuffer(), 0, p);
				ms.Close();
				ms = null;
			}
			fbw.Close();
			fs.Close();
			fs = null;
			IP.GCCollect();
		}
	}
}
