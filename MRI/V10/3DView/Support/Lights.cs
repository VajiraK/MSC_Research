using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace _3DView
{
	class Lights
	{
		private float[] m_glb_amb = new float[4];

		private float[] m_lgt0_amb = new float[4];
		private float[] m_lgt0_def = new float[4];
		private float[] m_lgt0_spe = new float[4];
		private float[] m_lgt0_Pos = new float[4];
		private float[] m_lgt0_dir = new float[3];
		public int		m_DrawSphere;
		private References m_r;
		//---------------------------------------------------------------------------
		public void Int(References r)
		{
			m_r = r;

			// Enable lighting
			GL.Enable(EnableCap.Lighting);
			//GL.LightModel(LightModelParameter.LightModelTwoSide, 1);
			GL.Enable(EnableCap.ColorMaterial);

			// Set Material properties to follow glColor values
            GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.AmbientAndDiffuse);
			// All materials hereafter have full specular reflectivity with a high shine
			GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, 128);

			//No global ambient :(
			GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.0f, 0.0f, 0.0f, 1.0f });

			//************************ LIGHT 0 *****************************
			//Position
			m_lgt0_Pos[0] = m_lgt0_Pos[1] = m_lgt0_Pos[2] = 0.0f;
			m_lgt0_Pos[3] = 1.0f;
			GL.Light(LightName.Light0, LightParameter.Position, m_lgt0_Pos);
			//Ambient
			m_lgt0_amb[0] = m_lgt0_amb[1] = m_lgt0_amb[2] = 1.0f;
			m_lgt0_amb[3] = 1.0f;
			GL.Light(LightName.Light0, LightParameter.Ambient, m_lgt0_amb);
			//Diffuse
			m_lgt0_def[0] = m_lgt0_def[1] = m_lgt0_def[2] = 0.7f;
			GL.Light(LightName.Light0, LightParameter.Diffuse, m_lgt0_def);
			//Specular
			m_lgt0_spe[0] = m_lgt0_spe[1] = m_lgt0_spe[2] = 0.7f;
			m_lgt0_spe[3] = 1.0f;
			GL.Light(LightName.Light0, LightParameter.Specular, m_lgt0_spe);
			// Cut off angle
			GL.Light(LightName.Light0, LightParameter.SpotCutoff, 360.0f);
			//Direction (Has no effect when Cut off angle >= 180
			m_lgt0_dir[0] = 1.0f; m_lgt0_dir[1] = 0.0f; m_lgt0_dir[2] = 0.0f;
			GL.Light(LightName.Light0, LightParameter.SpotDirection, m_lgt0_dir);

			GL.Enable(EnableCap.Light0);
			//************************ LIGHT 0 *****************************
		}
		//---------------------------------------------------------------------------
		public void Render()
		{
			State s = m_r.m_state;
			GL.PushMatrix();

			GL.Rotate(s.xLRot, 1.0f, 0.0f, 0.0f);
			GL.Rotate(s.yLRot, 0.0f, 1.0f, 0.0f);			

			// Specify new position and direction in rotated coords.
			m_lgt0_Pos[2] = s.zLPos;
			GL.Light(LightName.Light0, LightParameter.Position, m_lgt0_Pos);
			
			// Save the lighting state variables
			GL.PushAttrib(AttribMask.LightingBit);
			// Turn off lighting and specify a bright yellow sphere
			GL.Disable(EnableCap.Lighting);
			MyTexture.Disable();
			GL.Translate(m_lgt0_Pos[0], m_lgt0_Pos[1], m_lgt0_Pos[2]);
			GL.CallList(m_DrawSphere);
			MyTexture.Enable();
			// Restore lighting state variables
			GL.PopAttrib();
			//Restore coordinate transformations
			GL.PopMatrix();
		}
	}
}
