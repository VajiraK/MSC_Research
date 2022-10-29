using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;		
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace _3DView
{
	public enum LastAction
	{
		Transform,Rotate,none
	}

	[Serializable]
	public class State
	{
		public LastAction m_laction = LastAction.none;
		//Rotation amounts
		private float m_xRot;
		private float m_yRot;
		private float m_zRot;
		//Translations
		private float m_xTra;
		private float m_yTra;
		private float m_zTra;
		//Lights
		private float m_xLRot;
		private float m_yLRot;
		private float m_zLPos;
		public string m_path;
		//---------------------------------------------------------------------------
		public static State Deserialize(string path)
		{
			State st = new State();
			try
			{
				StreamReader objStreamReader = new StreamReader(path);
				XmlSerializer x = new XmlSerializer(st.GetType());
				st = (State)x.Deserialize(objStreamReader);
				objStreamReader.Close();
			}catch (Exception){
				return null;
			}

			return st;
		}
		//---------------------------------------------------------------------------
		public void Serialize(string path)
		{
			StreamWriter objStreamWriter = new StreamWriter(path);
			XmlSerializer x = new XmlSerializer(this.GetType());
			x.Serialize(objStreamWriter, this);
			objStreamWriter.Close();
		}
		//---------------------------------------------------------------------------
		public State()
		{
			Reset();
		}
		//---------------------------------------------------------------------------
		public void Reset()
		{
			//Rotation amounts
			m_xRot = 0;
			m_yRot = 0;
			m_zRot = 0;
			//Translations
			m_xTra = 0;
			m_yTra = 0;
			m_zTra = 0;
			//Lights
			m_xLRot = 0;
			m_yLRot = 0;
		}
		//---------------------------------------------------------------------------
		public float xRot
		{
			get { return m_xRot; }
			set { m_xRot = value; }
		}
		//---------------------------------------------------------------------------
		public float yRot
		{
			get { return m_yRot; }
			set { m_yRot = value; }
		}
		//---------------------------------------------------------------------------
		public float zRot
		{
			get { return m_zRot; }
			set { m_zRot = value; }
		}
		//---------------------------------------------------------------------------
		public float xTra
		{
			get { return m_xTra; }
			set { m_xTra = value; }
		}
		//---------------------------------------------------------------------------
		public float yTra
		{
			get { return m_yTra; }
			set { m_yTra = value; }
		}
		//---------------------------------------------------------------------------
		public float zTra
		{
			get { return m_zTra; }
			set { m_zTra = value; }
		}
		//---------------------------------------------------------------------------
		public float xLRot
		{
			get { return m_xLRot; }
			set { m_xLRot = value; }
		}
		//---------------------------------------------------------------------------
		public float yLRot
		{
			get { return m_yLRot; }
			set { m_yLRot = value; }
		}
		//---------------------------------------------------------------------------
		public float zLPos
		{
			get { return m_zLPos; }
			set { m_zLPos = value; }
		}
	}
}
