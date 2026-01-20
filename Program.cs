using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Managment
{
    internal static class Program
    {
        public static string DbAppName = ConfigurationManager.ConnectionStrings["Football_Managment.Properties.Settings.Soccer_Score_System"].ConnectionString;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdminDashboard());
        }
    }
}
