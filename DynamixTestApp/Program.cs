using System;
using System.Windows.Forms;
using DynamixTestApp.Utilities;

namespace DynamixTestApp
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
            AppSettingsReader.Initialize();
            Application.Run(new Master());
        }
    }
}
