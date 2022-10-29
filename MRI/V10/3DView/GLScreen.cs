using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace _3DView
{
	public partial class GLScreeen : UserControl
	{
		private MyTexture[]		m_textures = new MyTexture[6];
		private Timer			m_timer, tmrAnimation;
		private bool			m_sup_mevent = false;
		private References		m_r;
		private DataCube		m_cube;
		private int				m_DrawCube;
		private int				m_DrawMRI = 0;
		private Point			m_mousep;
		private Lights			m_lights = new Lights();
		private GLControl		m_glcontrol = new GLControl();
		//---------------------------------------------------------------------------
		public GLScreeen()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------
		public void SupressMouseEvents(int ms)
		{//SupressMouseEvents when openning file, help to prevent mouse move event trigger
			m_timer.Interval = ms;
			m_sup_mevent = true;
			m_timer.Start();
		}
		//---------------------------------------------------------------------------
		private void m_timer_Tick(object sender, EventArgs e)
		{//Fire by SupressMouseEvents and m_glcontrol_Resize
			m_timer.Stop();
			if (m_sup_mevent)
			{
				m_timer.Interval = 100;
				m_sup_mevent = false;
				return;
			}
			SetupView();
		}
		//---------------------------------------------------------------------------
		public void TrackerChange(MyTrackType sender, int val)
		{//Call by parent TrackerBars
			State s = m_r.m_state;
			switch (sender)
			{
				case MyTrackType.TransX:
					s.xTra = val; break;
				case MyTrackType.TransY:
					s.yTra = val; break;
				case MyTrackType.TransZ:
					s.zTra = val; break;
				case MyTrackType.RotX:
					s.xRot = val; break;
				case MyTrackType.RotY:
					s.yRot = val; break;
				case MyTrackType.RotZ:
					s.zRot = val; break;
				case MyTrackType.Ligx:
					s.xLRot = val; break;
				case MyTrackType.Ligy:
					s.yLRot = val; break;
				case MyTrackType.LigPos:
					s.zLPos = val; break;
				default:
					break;
			}
			Render();
		}
		//---------------------------------------------------------------------------
		private void m_glcontrol_MouseWheel(object sender, MouseEventArgs e)
		{
			State s = m_r.m_state;
			//ZTra
			s.zTra = s.zTra + (e.Delta / 120) * 5;
			//int d = (int)MyTrackType.OZTraMin;
			if (s.zTra < (int)MyTrkConstant.OZTraMin)
				s.zTra = (int)MyTrkConstant.OZTraMin;
			if (s.zTra > (int)MyTrkConstant.OZTraMax)
				s.zTra = (int)MyTrkConstant.OZTraMax;
			m_r.m_controller.TrackerChanged(MyTrackType.TransZ, (int)s.zTra);
			Render();
		}
		//---------------------------------------------------------------------------
		public void Terminate()
		{
			tmrAnimation.Dispose();
			m_timer.Dispose();
			m_glcontrol.Dispose();
			m_glcontrol = null;
			GC.Collect();
		}
		//---------------------------------------------------------------------------
		public GLControl Init(References r) 
		{
			m_timer = new Timer();
			m_timer.Stop();
			m_timer.Interval = 100;
			m_timer.Tick += new EventHandler(m_timer_Tick);

			m_r = r;
			//Create GLControl
			ColorFormat cf = new ColorFormat();
			GraphicsMode gm = new GraphicsMode(32, 24, 8, 4, cf, 4, true);
			m_glcontrol = new GLControl(gm);
			m_glcontrol.Dock = DockStyle.Fill;
			this.Controls.Add(m_glcontrol);

			GL.ClearColor(Color.Black);
			GL.Enable(EnableCap.DepthTest);
			GL.ShadeModel(ShadingModel.Smooth);
			GL.FrontFace(FrontFaceDirection.Ccw);
			GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
			MyTexture.Enable();

			m_lights.Int(m_r);
			SetupView();

			tmrAnimation = new Timer();
			tmrAnimation.Interval = 24;
			tmrAnimation.Tick += new EventHandler(tmrAnimation_Tick);
			m_timer.Start();//Deleay setup view call

			//Create display lists
			m_DrawCube = DrawCube(20);
			m_lights.m_DrawSphere = DrawSphere(1, 10);
			m_r.m_state.xRot = 40;
			tmrAnimation.Start();

			m_glcontrol.Paint += new PaintEventHandler(m_glcontrol_Paint);
			m_glcontrol.Resize += new EventHandler(m_glcontrol_Resize);
			m_glcontrol.MouseMove += new MouseEventHandler(m_glcontrol_MouseMove);
			m_glcontrol.MouseWheel += new MouseEventHandler(m_glcontrol_MouseWheel);
			return m_glcontrol;
		}
		//---------------------------------------------------------------------------
		public void SetupView()
		{
			float aspect = this.ClientSize.Width / (float)this.ClientSize.Height;
			//Perspective projection
			Matrix4 projection_matrix;
			Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspect, 1, (float)MyTrkConstant.PMaxDepth, out projection_matrix);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref projection_matrix);
			//Look at
			Matrix4 lookat = Matrix4.LookAt(0, 0, (float)MyTrkConstant.LookAtz, 0, 0, 0, 0, 1, 0);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref lookat);
			//Viewport
			GL.Viewport(ClientRectangle);

			Render();
			//Set translate tracker bars
			//m_r.m_controller.SetTrkValues(this.ClientSize.Width, this.ClientSize.Height);
		}
		//---------------------------------------------------------------------------
		private void m_glcontrol_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_sup_mevent)
				return;

			State s = m_r.m_state;
			//Rotation
			if (e.Button == MouseButtons.Left)
			{
				//XRot
				s.xRot = s.xRot + (e.Y - m_mousep.Y);
				if (s.xRot < 0)
					s.xRot = 360;
				if (s.xRot > 360)
					s.xRot = 0;
				m_r.m_controller.TrackerChanged(MyTrackType.RotX, (int)s.xRot);
				//YRot
				s.yRot = s.yRot + (e.X - m_mousep.X);
				if (s.yRot < 0)
					s.yRot = 360;
				if (s.yRot > 360)
					s.yRot = 0;
				m_r.m_controller.TrackerChanged(MyTrackType.RotY, (int)s.yRot);
				m_r.m_state.m_laction = LastAction.Rotate;
				Render();
			}
			//Translate
			if (e.Button == MouseButtons.Right)
			{
				//XTra
				s.xTra = s.xTra + (e.X - m_mousep.X);
				if (s.xTra < (int)MyTrkConstant.OXTraMin)
					s.xTra = (int)MyTrkConstant.OXTraMin;
				if (s.xTra > (int)MyTrkConstant.OXTraMax)
					s.xTra = (int)MyTrkConstant.OXTraMax;
				m_r.m_controller.TrackerChanged(MyTrackType.TransX, (int)s.xTra);
				//YTra
				s.yTra = s.yTra - (e.Y - m_mousep.Y);
				if (s.yTra < (int)MyTrkConstant.OYTraMin)
					s.yTra = (int)MyTrkConstant.OYTraMin;
				if (s.yTra > (int)MyTrkConstant.OYTraMax)
					s.yTra = (int)MyTrkConstant.OYTraMax;
				m_r.m_controller.TrackerChanged(MyTrackType.TransY, (int)s.yTra);
				Render();
			}

			m_mousep = e.Location;
			
		}
		//---------------------------------------------------------------------------
		private void m_glcontrol_Paint(object sender, PaintEventArgs e)
		{
			if (!this.DesignMode)
				Render();
		}
		//---------------------------------------------------------------------------
		private void Render()
		{
			State s = m_r.m_state;
			// Clear the window and the depth buffer
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.PushMatrix();
			GL.Translate(s.xTra, s.yTra, s.zTra);

			m_lights.Render();

			GL.Rotate(s.xRot, 1.0f, 0.0f, 0.0f);
			GL.Rotate(s.yRot, 0.0f, 1.0f, 0.0f);
			GL.Rotate(s.zRot, 0.0f, 0.0f, 1.0f);

			if (m_DrawMRI != 0)
			{
				GL.CallList(m_DrawMRI);
			}else{
				GL.CallList(m_DrawCube);
			}

			GL.PopMatrix();
			//Console.WriteLine(string.Format("{0}-{1}-{2}", s.m_xRot, s.m_yRot, s.m_zRot));
			m_glcontrol.SwapBuffers();
		}
		//---------------------------------------------------------------------------
		private int DrawSphere(float r, int n)
		{
			float len = r;
			float pi = (float)Math.PI;
			int inc = n;
			int z, x;

			int dls = GL.GenLists(1);
			GL.NewList(dls, ListMode.Compile);

			GL.Color3(Color.Gold);

			for (z = 0; z < 90; z += inc)
			{
				float dist1 = len * (float)Math.Sin((pi * z) / 180);
				float dist2 = len * (float)Math.Sin((pi * (z + inc)) / 180);

				float dist1a = (float)Math.Sqrt(len * len - dist1 * dist1);
				float dist2a = (float)Math.Sqrt(len * len - dist2 * dist2);

				for (x = 0; x < 360; x += inc)
				{
					float x1 = (float)dist1a * (float)Math.Cos((2 * pi * x) / 360);
					float y1 = (float)dist1a * (float)Math.Sin(2 * pi * x / 360);

					float x2 = (float)dist1a * (float)Math.Cos(2 * pi * (x + inc) / 360);
					float y2 = (float)dist1a * (float)Math.Sin(2 * pi * (x + inc) / 360);

					float x3 = (float)dist2a * (float)Math.Cos(2 * pi * x / 360);
					float y3 = (float)dist2a * (float)Math.Sin(2 * pi * x / 360);

					float x4 = (float)dist2a * (float)Math.Cos(2 * pi * (x + inc) / 360);
					float y4 = (float)dist2a * (float)Math.Sin(2 * pi * (x + inc) / 360);

					GL.Begin(BeginMode.Quads);
					GL.Vertex3(x1, y1, dist1);
					GL.Vertex3(x2, y2, dist1);
					GL.Vertex3(x4, y4, dist2);
					GL.Vertex3(x3, y3, dist2);
					GL.End();

					GL.Begin(BeginMode.Quads);
					GL.Vertex3(x1, y1, -dist1);
					GL.Vertex3(x2, y2, -dist1);
					GL.Vertex3(x4, y4, -dist2);
					GL.Vertex3(x3, y3, -dist2);
					GL.End();
				}
			}

			GL.EndList();
			return dls;
		}
		//---------------------------------------------------------------------------
		private void m_glcontrol_Resize(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				m_timer.Start();
			}
		}
		//---------------------------------------------------------------------------
		private int DrawCubeEx(float x)
		{
			m_textures[0] = MyTexture.LoadTexture(@"Images\1.png");
			m_textures[1] = MyTexture.LoadTexture(@"Images\2.png");
			m_textures[2] = MyTexture.LoadTexture(@"Images\3.png");
			m_textures[3] = MyTexture.LoadTexture(@"Images\4.png");
			m_textures[4] = MyTexture.LoadTexture(@"Images\5.png");
			m_textures[5] = MyTexture.LoadTexture(@"Images\6.png");

			for (int i = 0; i < m_textures.Length; i++)
			{
				if (m_textures[i] == null)
				{//One of the texture fail so use normal DrawCube
					//Delete created textures
					for (int j = 0; j < i; j++)
						m_textures[j].Delete();
					return DrawCube(x);
				}
			}

			int dls = GL.GenLists(1);
			GL.NewList(dls, ListMode.Compile);
			GL.Color3(Color.White);
			x = x / 2;
			
			// Front Face
			m_textures[0].MakeCurrent();
			GL.Begin(BeginMode.Quads);
			GL.Normal3(0.0f, 0.0f, 1.0f);		// Normal Facing Forward
			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-(x), -(x), x);
			GL.TexCoord2(0.0f,1.0f);
			GL.Vertex3(x, -(x), x);
			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(x, x, x);
			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(-(x), x, x);
			GL.End();

			// Back Face 
			m_textures[1].MakeCurrent();
			GL.Begin(BeginMode.Quads);
			GL.Normal3(0.0f, 0.0f, -1.0f);		// Normal Facing Away  
			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-(x), -(x), -(x));
			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(-(x), x, -(x));
			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(x, x, -(x));
			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(x, -(x), -(x));
			GL.End();

			// Top Face      
			m_textures[2].MakeCurrent();
			GL.Begin(BeginMode.Quads);
			GL.Normal3(0.0f, 1.0f, 0.0f);		// Normal Facing Up     
			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-(x), x, -(x));
			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(-(x), x, x);
			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(x, x, x);
			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(x, x, -(x));
			GL.End();

			// Bottom Face    
			m_textures[3].MakeCurrent();
			GL.Begin(BeginMode.Quads);
			GL.Normal3(0.0f, -1.0f, 0.0f);		// Normal Facing Down   
			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-(x), -(x), -(x));
			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(x, -(x), -(x));
			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(x, -(x), x);
			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(-(x), -(x), x);
			GL.End();

			// Right face
			m_textures[4].MakeCurrent();
			GL.Begin(BeginMode.Quads);
			GL.Normal3(1.0f, 0.0f, 0.0f);		// Normal Facing Right
			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(x, -(x), -(x));
			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(x, x, -(x));
			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(x, x, x);
			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(x, -(x), x);
			GL.End();

			// Left Face   
			m_textures[5].MakeCurrent();
			GL.Begin(BeginMode.Quads);
			GL.Normal3(-1.0f, 0.0f, 0.0f);		// Normal Facing Left   
			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-(x), -(x), -(x));
			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(-(x), -(x), x);
			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(-(x), x, x);
			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(-(x), x, -(x));
			GL.End();

			GL.EndList();
			return dls;
		}
		//---------------------------------------------------------------------------
		private int DrawCube(float x)
		{
			int dls = GL.GenLists(1);
			GL.NewList(dls, ListMode.Compile);

            float[][] ctrlpoints = new float[4][] { new float[] { -4, -4, 0 }, new float[] { -2, 4, 0 }, new float[] { 2, -4, 0 }, new float[] { 4, 4, 0 } };

            GL.Map1(MapTarget.Map1Vertex3, 0.0f, 1.0f, 3, 4, new float[] {  -4, -4, 0 ,  -2, 4, 0 ,  2, -4, 0 , 4, 4, 0  });
            GL.Enable(EnableCap.Map1Vertex3);

            int i;
            GL.Begin(BeginMode.LineStrip);
            for (i = 0; i <= 30; i++)
                GL.EvalCoord1(i / 30.0);
            GL.End();


            GL.PointSize(5f);
            GL.Begin(BeginMode.Points);
            for (i = 0; i < 4; i++)
                GL.Vertex3(ref ctrlpoints[i][0]);
            GL.End();


			x = x / 2;
			GL.Begin(BeginMode.Quads);
			// Front Face
			GL.Color3(Color.Red);
			GL.Normal3(0.0f, 0.0f, 1.0f);		// Normal Facing Forward
			GL.Vertex3(-(x), -(x), x);
			GL.Vertex3(x, -(x), x);
			GL.Vertex3(x, x, x);
			GL.Vertex3(-(x), x, x);
			// Back Face 
			GL.Color3(Color.Green);
			GL.Normal3(0.0f, 0.0f, -1.0f);		// Normal Facing Away   
			GL.Vertex3(-(x), -(x), -(x));
			GL.Vertex3(-(x), x, -(x));
			GL.Vertex3(x, x, -(x));
			GL.Vertex3(x, -(x), -(x));
			// Top Face      
			GL.Color3(Color.Gold);
			GL.Normal3(0.0f, 1.0f, 0.0f);		// Normal Facing Up     
			GL.Vertex3(-(x), x, -(x));
			GL.Vertex3(-(x), x, x);
			GL.Vertex3(x, x, x);
			GL.Vertex3(x, x, -(x));
			// Bottom Face    
			GL.Color3(Color.Blue);
			GL.Normal3(0.0f, -1.0f, 0.0f);		// Normal Facing Down   
			GL.Vertex3(-(x), -(x), -(x));
			GL.Vertex3(x, -(x), -(x));
			GL.Vertex3(x, -(x), x);
			GL.Vertex3(-(x), -(x), x);
			// Right face
			GL.Color3(Color.Yellow);
			GL.Normal3(1.0f, 0.0f, 0.0f);		// Normal Facing Right
			GL.Vertex3(x, -(x), -(x));
			GL.Vertex3(x, x, -(x));
			GL.Vertex3(x, x, x);
			GL.Vertex3(x, -(x), x);
			// Left Face   
			GL.Color3(Color.Moccasin);
			GL.Normal3(-1.0f, 0.0f, 0.0f);		// Normal Facing Left   
			GL.Vertex3(-(x), -(x), -(x));
			GL.Vertex3(-(x), -(x), x);
			GL.Vertex3(-(x), x, x);
			GL.Vertex3(-(x), x, -(x));
			GL.End();

			GL.EndList();
			return dls;
		}
		//---------------------------------------------------------------------------
		public bool LoadDataCube(string path)
		{
			if (m_cube != null)
			{
				m_cube = null;
				GC.Collect();
			}

			m_cube = new DataCube();
			m_cube.Init(m_r);

			//LoadIdentity
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
			//Restore status
			State s = m_r.m_state;
			if (s.m_laction == LastAction.Rotate)
			{
				GL.Rotate(s.xRot, 1.0f, 0.0f, 0.0f);
				GL.Rotate(s.yRot, 0.0f, 1.0f, 0.0f);
				GL.Rotate(s.zRot, 0.0f, 0.0f, 1.0f);
				GL.Translate(s.xTra, s.yTra, s.zTra);
			}else{
				GL.Translate(s.xTra, s.yTra, s.zTra);
				GL.Rotate(s.xRot, 1.0f, 0.0f, 0.0f);
				GL.Rotate(s.yRot, 0.0f, 1.0f, 0.0f);
				GL.Rotate(s.zRot, 0.0f, 0.0f, 1.0f);
			}

			if (m_cube.LoadDataFile(path))
			{//File loaded successfully
				if (DrawMRI(m_r.m_controller.AxisPoint))
				{//MRI Drawen successfully so clear all textures use by welcom cube
					for (int i = 0; i < m_textures.Length; i++)
					{
						if (m_textures[i] != null)
							m_textures[i].Delete();
					}
					GL.DeleteLists(m_DrawCube, 1);
					return true;
				}
			}
			return false;
		}
		//---------------------------------------------------------------------------
		public bool DrawMRI(Point ap)
		{
		    //Delete display list
		    GL.DeleteLists(m_DrawMRI, 1);
		    m_DrawMRI = m_cube.RenderDataCube(ap, 20);
		    if (m_DrawMRI!=0)
		    {
				tmrAnimation.Stop();
		        Render();
		        return true;
		    }
			
		    return false;
		}

        private void GLScreeen_Load(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------------------------
        private void tmrAnimation_Tick(object sender, EventArgs e)
		{
			m_r.m_state.yRot++;
			Render();
		}
		
	}
}
