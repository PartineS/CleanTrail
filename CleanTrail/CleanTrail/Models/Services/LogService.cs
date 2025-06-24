using System;
using System.IO;

namespace CleanTrail.Services
{
    public static class LogService
    {
        private static string logFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "cleantrail.log");
        public static void Log(string message)
        {
            File.AppendAllText(logFile, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n");
        }
    }
}