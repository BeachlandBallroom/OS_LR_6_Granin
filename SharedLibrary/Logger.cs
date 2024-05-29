using System;
using System.IO;

namespace SharedLibrary
{
    public static class Logger
    {
        private static readonly string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string logFilePath = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

        static Logger()
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        public static void Log(string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllLines(logFilePath, new[] { logMessage });
        }

        public static string[] GetLogFiles()
        {
            if (!Directory.Exists(logDirectory))
            {
                return Array.Empty<string>();
            }
            return Directory.GetFiles(logDirectory, "log_*.txt");
        }

        public static string ReadLogFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return string.Empty;
        }
    }
}
