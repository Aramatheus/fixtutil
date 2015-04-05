using System;
using System.Collections.Generic;
//using System.Linq; was from .NET 4.0
using System.Windows.Forms;

namespace Fallout_Fixt_developer_tool
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Fallout_Fixt_developer_tool());
		}
	}
}
