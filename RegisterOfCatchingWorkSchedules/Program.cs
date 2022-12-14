using RegisterOfCatchingWorkSchedules.View;
using System;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	internal static class Program
	{
		public static Session Session;
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Session = new Session();
			Application.Run(new MainForm());
		}
	}
}
