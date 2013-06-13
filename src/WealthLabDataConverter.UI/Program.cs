// =================================================
// File:
// WealthLabDataConverter/WealthLabDataConverter/Program.cs
// 
// Last updated:
// 2013-06-13 12:39 PM
// =================================================

#region Usings

using System;
using System.Windows.Forms;

#endregion

namespace WealthLabDataConverter
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
