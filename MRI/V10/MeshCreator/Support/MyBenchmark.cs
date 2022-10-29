using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text;

namespace MeshCreator
{
	class MyBenchmark
	{
		private static Stopwatch m_st;
		//---------------------------------------------------------------------------
		public static void Start()
		{
			m_st = Stopwatch.StartNew();

		}
		//---------------------------------------------------------------------------
		public static void Stop(string msg)
		{
			m_st.Stop();
			Console.WriteLine(string.Format("{0} -> {1}ms",msg,m_st.ElapsedMilliseconds));
		}
	}
}
