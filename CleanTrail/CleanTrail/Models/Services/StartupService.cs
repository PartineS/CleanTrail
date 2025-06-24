using Microsoft.Win32;

namespace CleanTrail.Services
{
    public static class StartupService
    {
        private static string appName = "CleanTrail";
        public static void EnableAutostart()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            using(var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                key.SetValue(appName, path);
            }
        }
        public static void DisableAutostart()
        {
            using(var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                key.DeleteValue(appName, false);
            }
        }
    }
}