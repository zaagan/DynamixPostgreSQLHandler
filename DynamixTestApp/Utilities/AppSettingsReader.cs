using System;
using System.Configuration;

namespace DynamixTestApp.Utilities
{
    public static class AppSettingsReader
    {

        public static void Initialize()
        {
            try
            {
                AppData.ConnectionString = ConfigurationManager.AppSettings[StaticConstants.AppSettingsKey_ConnectionString];
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }
    }
}
