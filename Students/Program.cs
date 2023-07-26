using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Tydzien5Lekcja25ZD
{
	internal static class Program
	{
		public static string FilePath =
			Path.Combine(Environment.CurrentDirectory, "students.txt");

		public static List<string> Groups = new List<string> { "Klasa I", "Klasa II", "Klasa III" };

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}
	}
}
