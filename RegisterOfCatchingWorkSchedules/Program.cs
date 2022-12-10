using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
    internal static class Program
    {
        public static RegisterDBContext DBContext;
        public static SessionService Session;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DBContext = new RegisterDBContext();
            Session = new SessionService();

			//var tmn = DBContext.Municipality.Add(new Municipality() { MunicipalityName = "Тюмень" });
			//DBContext.Municipality.Add(new Municipality() { MunicipalityName = "Тобольск" });
			//DBContext.Municipality.Add(new Municipality() { MunicipalityName = "Ишим" });

   //         for (int i = 1; i <= 6; i++)
   //             tmn.Places.Add(new Places() { PlacesName = $"{i} мкр" });
			//DBContext.SaveChanges();

			Application.Run(new MainForm());
        }
    }
}
