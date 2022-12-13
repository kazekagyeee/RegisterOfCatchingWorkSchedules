using RegisterOfCatchingWorkSchedules.Services;
using RegisterOfCatchingWorkSchedules.View;

namespace RegisterOfCatchingWorkSchedules
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			using var dbContext = new AppDBContext();
			Application.Run(new MainForm());
			dbContext.SaveChanges();
		}
	}
}