using System;
using System.Security;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace MeshCreator
{
    public partial class ImageListEx : UserControl,IMessageFilter
    {
		const int				WM_KEYDOWN = 0x0100;
		const int				VK_RIGHT = 0x27;
		const int				VK_LEFT = 0x25;
        public string           m_path = @"D:\Vajira\MSc\Research\Cube\images\5";
        private Slide			m_cur_slide = null;//Blue color or Black when both sel and cur
        private ByteCube        m_byte_cube;
        private References      m_r;
		private MRISteps		m_step;
		private int				m_count, m_sel_index, m_start, m_end;
		private ObjectCatalogue m_obj_cat = new ObjectCatalogue();
        private bool            m_forward;
        //---------------------------------------------------------------------------
        public ImageListEx()
        {
            InitializeComponent();
        }
		//---------------------------------------------------------------------------
		public void Reset()
		{
			m_obj_cat.Reset();
			floImages.Controls.Clear();
			lblSlices.Text		= "0 Slices";
			lblSelected.Text	= "N/A";
			m_step = MRISteps.Processing;
			floImages.ContextMenu = null;
			//Stop play
			btnPlay.Stop();
			m_count = 0;
		}
        //---------------------------------------------------------------------------
        public void Init(References r)
        {
            m_r = r;
			btnPlay.Init(m_r);
			Application.AddMessageFilter(this);
        }
        //---------------------------------------------------------------------------
        private void btnLoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = m_path;

            if (fb.ShowDialog() == DialogResult.OK)
            {
				string filename, strnum = null;
				int i = 0;
				Slide sl = new Slide();
				m_cur_slide = sl;
                m_path = fb.SelectedPath; 
                floImages.Visible = false;
				floImages.SuspendLayout();

				//Reset entire application
				m_r.m_main_form.ResetApplication();
				filename = string.Format("{0}\\{1}.bmp", m_path, i);

				if (File.Exists(filename))
				{
					if (m_byte_cube != null)
					{
						m_byte_cube.Dispose();
						m_byte_cube = null;
					}

					ByteImage bi = ByteImage.FromFile(filename,0);
					m_byte_cube = new ByteCube(bi.Size, 100,m_r);
					m_byte_cube.AddImage(bi);
					//Add first slide
					sl.Init(m_r, "0", i);
					toolTip1.SetToolTip(sl.SetTip, "0");
					floImages.Controls.Add(sl);
					sl = new Slide();
					m_r.m_main_form.OnLoadImages(true);

					for (i = 1; i < 1000; i++)
					{
						strnum = i.ToString();
						filename = string.Format("{0}\\{1}.bmp", m_path, strnum);
						if (File.Exists(filename))
						{
							m_byte_cube.AddImage(ByteImage.FromFile(filename,i));
							//Add slide
							sl.Init(m_r, strnum, i);
							toolTip1.SetToolTip(sl.SetTip, strnum);
							floImages.Controls.Add(sl);
							sl = new Slide();
							m_r.m_flash_form.UpdateDisplay(i.ToString());
						}else{
							break;
						}
					}
				}

				fb.Dispose();
				if (i>0)
				{
					m_count = floImages.Controls.Count;
					SlideChanged(m_cur_slide);
					//m_r.m_pix_ori.IntAxisPoint();//Axis point starts here
					lblSlices.Text = string.Format("{0} Slices",strnum);
					m_r.m_main_form.OnLoadImages(false);
					floImages.ResumeLayout();
					floImages.Visible = true;
					btnPlay.Enabled = true;
				}else{
					//Something wrong
					floImages.Visible = true;
					IP.MRIMessageBox("Unable to load images");
				}
            }
        }
		//---------------------------------------------------------------------------
		public void Slide_DoubleClick(Slide sl,bool shift)
		{//Call when Slide controls picSelect double clicked
			if (m_step == MRISteps.Marking)
			{
				int i; int end, start;
				end = start = 0;
				Slide c;
				bool b = false;
				if (shift)
				{//Selecting range
					if (m_start>sl.m_num)
					{
						end = m_start;
						m_start = sl.m_num;
						start = m_start;
						b = true;
					}
					if (m_end < sl.m_num)
					{
						start = m_end + 1;
						m_end = sl.m_num;
						end = m_end + 1;
						b = true;
					}
					if (b)
					{
						for (i = start; i < end; i++)
						{
							c = (Slide)floImages.Controls[i];
							c.Selected = true;
						}
					}
				}else{
					//Single selection
					m_end++;
					for (i = m_start; i < m_end; i++)
					{
						c = (Slide)floImages.Controls[i];
						c.Selected = false;
					}
					m_end--;
					sl.Selected = true;
					m_start = m_end = sl.m_num;
				}
			}
		}
        //---------------------------------------------------------------------------
		public void SlideChanged(Slide sl)
        {//Call when Slide control picSelect clicked
			if (m_cur_slide != null)
				m_cur_slide.Current = false;
			m_cur_slide = sl;
			sl.Current = true;
			m_sel_index = sl.m_num;
            lblSelected.Text = string.Format("Selected - {0}", m_sel_index);
			m_r.m_pix_con.PicOri.SetImage(m_byte_cube.GetImage(m_sel_index));
        }
		//---------------------------------------------------------------------------
		public bool AddSlideDevGraphs()
		{
			int i,c = 0;
			CatalogueItem citem;

			//Find all centroids
			for (c = 0; c < ColorMarshal.MAX_OBJ; c++)
			{
				citem = m_obj_cat.GetItem(c);
				if (citem!=null)
				{
                    //for (i = citem.StartSlide; i <= citem.EndSlide; i++)
                    //    m_byte_cube.GetImage(i).GetObjectByFill(citem.FillColor).FindCentroid();
                    for (i = citem.StartSlide; i <= citem.EndSlide; i++)
                    {
                        MyPoint m = m_byte_cube.GetImage(i).GetObjectByFill(citem.FillColor).FindCentroid();
                        string s = string.Format("{0},{1}",m.x,m.y);
                        Console.WriteLine(s);
                    }
				}else{
					break;
				}
			}

			//Create graphs per-objects
			bool b = false;
			DevGraph dg;
			for (c = 0; c < m_obj_cat.Count; c++)
			{
				citem = m_obj_cat.GetItem(c);
				if (citem != null)
				{
					if (citem.StartSlide!=citem.EndSlide)
					{
						b = true;
						dg = new DevGraph();
						dg.SetGraphBounds(c, 0, 50, 100, 0, m_byte_cube.Count / 2, m_byte_cube.Count);
						dg.DrawGraphs(m_byte_cube, citem);
						m_r.m_dev_form.AddObjectGraph(dg);
					}
				}
			}

			if (!b)
			{
			    IP.MRIMessageBox("Object(s) contains within a one slide, so no deviation can be calculated");
			    return false;
			} else{
				return true;
			}
		}
		//---------------------------------------------------------------------------
		public void PropagateObject(FloodFillInfo fd,MRIPropTypes pt)
		{
			int i = 0;
			int c = 0;
			ByteImage bi;
			UmImage um;
			bool obj_found;

			CatalogueItem citem = new CatalogueItem();
			citem.FillColor = fd.m_obj_fill;
			citem.StartSlide = m_sel_index;
			citem.EndSlide = m_sel_index;

			m_r.m_main_form.OnPropagate(true);
			MyPoint[] oarr = m_byte_cube.GetImage(m_sel_index).GetObjectByFill(fd.m_obj_fill).GetObjPoints();

			if ((pt == MRIPropTypes.Forward)||(pt == MRIPropTypes.Full))
			{
				//Downwards from current slide
				for (i = m_sel_index + 1; i < m_count; i++)
				{
					c++;
					obj_found = false;
					m_r.m_flash_form.UpdateDisplay(c.ToString());
					bi = m_byte_cube.GetImage(i);
					um = bi.OriCloneUm;
					//Apply necessary filters :)
					m_r.m_pix_con.PicInter.ExecuteProcessList(um);
					m_r.m_pix_con.PicFinal.ExecuteProcessList(um);
					bi.UpdateFromUm(um);
					fd.m_bi = bi;

					foreach (MyPoint p in oarr)
					{
						fd.m_start_point = p;
						if (IP.FloodFill(fd) != 0)
							obj_found = true;
					}

					if (obj_found == false)
					{//No object in this slide so stop here
						break;
					}

					oarr = fd.m_bi.GetObjectByFill(fd.m_obj_fill).GetObjPoints();
				}
				citem.EndSlide = i-1;
			}

			if ((pt == MRIPropTypes.Backward) || (pt == MRIPropTypes.Full))
			{
				//Upwards from current slide
				oarr = m_byte_cube.GetImage(m_sel_index).GetObjectByFill(fd.m_obj_fill).GetObjPoints();

				for (i = m_sel_index - 1; i >= 0; i--)
				{
					c++;
					obj_found = false;
					m_r.m_flash_form.UpdateDisplay(c.ToString());
					bi = m_byte_cube.GetImage(i);
					um = bi.OriCloneUm;
					//Apply necessary filters :)
					m_r.m_pix_con.PicInter.ExecuteProcessList(um);
					m_r.m_pix_con.PicFinal.ExecuteProcessList(um);
					bi.UpdateFromUm(um);
					fd.m_bi = bi;

					foreach (MyPoint p in oarr)
					{
						fd.m_start_point = p;
						if (IP.FloodFill(fd) != 0)
							obj_found = true;
					}

					if (obj_found == false)
					{//No object in this slide so stop here
						break;
					}

					oarr = fd.m_bi.GetObjectByFill(fd.m_obj_fill).GetObjPoints();
				}
				citem.StartSlide = i+1;
			}

			m_obj_cat.Add(citem);
			m_r.m_main_form.OnPropagate(false);
		}
		//---------------------------------------------------------------------------
		public void ClearLastObjects()
		{
			foreach (ByteImage bi in m_byte_cube.ImageList)
				bi.ClearLastObject();
			m_obj_cat.RemoveLast();
			SlideChanged(m_cur_slide);
		}
		//---------------------------------------------------------------------------
		private void mnuSelectAll_Click(object sender, EventArgs e)
		{
			SelAllImages();
		}
		//---------------------------------------------------------------------------
		public void SelAllImages()
		{
			foreach (Slide s in floImages.Controls)
				s.Selected = true;

			m_start = 0;
			Slide se = (Slide)floImages.Controls[m_count - 1];
			m_end = se.m_num;
		}
		//---------------------------------------------------------------------------
		public void Tmr_Tick()
		{
            m_forward = true;
			MoveSideSelection();
		}
		//---------------------------------------------------------------------------
		private void  MoveSideSelection()
		{
			if ((m_cur_slide == null)||(this.Enabled==false))
				return;
			int i = m_cur_slide.m_num;

			if (m_forward)
			{
				if (++i==m_count)
					i = 0;
			}else{
				if (--i<0)
					i = m_count-1;
			}
			
			SlideChanged((Slide)floImages.Controls[i]);
		}
		//---------------------------------------------------------------------------
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == WM_KEYDOWN)
			{
				if ((int)m.WParam == VK_LEFT)
				{
                    m_forward = false;
                    tmrKeyPress.Start();
					return true;
				}
				if ((int)m.WParam == VK_RIGHT)
				{
                    m_forward = true;
                    tmrKeyPress.Start();
					return true;
				}
			}
			return false;
		}
		//---------------------------------------------------------------------------
		public void Save()
		{
			SaveFileDialog sf = new SaveFileDialog();
			sf.Filter = "MRICube File(s)|*.mric";
			sf.FileName = "Untitled";

			if (sf.ShowDialog(m_r.m_main_form) == DialogResult.OK)
			{
				m_byte_cube.Save(sf.FileName,0,m_count-1);
				IP.MRIMessageBox("3D MRI File successfully created ");
			}

			sf.Dispose();
			this.Refresh();//Good for redrawing toolbar :)
		}
        //---------------------------------------------------------------------------
        private void tmrKeyPress_Tick(object sender, EventArgs e)
        {
            tmrKeyPress.Stop();
            MoveSideSelection();
            m_cur_slide.Select();
        }
	}
}
