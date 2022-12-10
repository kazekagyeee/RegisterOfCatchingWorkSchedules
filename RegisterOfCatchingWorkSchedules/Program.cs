using System;
using System.Collections.Generic;
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
            
            Application.Run(new MainForm());
        }
    }
}
