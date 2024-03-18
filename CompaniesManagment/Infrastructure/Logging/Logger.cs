
using CompaniesManagment.Infrastructure.Logging.LogLevels;

namespace CompaniesManagment.Infrastructure.Logging
{
    internal class Logger
    {
        private readonly string _filePath;

        public Logger(string filePath)
        {
            _filePath = filePath;
        }

        private void Log(LogLevel level, string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(_filePath, true))
            {
                streamWriter.WriteLine($"{level}: {DateTime.Now} - {message}");
            }
        }

        public void Info(string message)
        {
            Log(LogLevel.INFO, message);
        }
        public void Warn(string message)
        {
            Log(LogLevel.WARN, message);
        }

        public void Error(string message)
        {
            Log(LogLevel.ERROR, message);
        }        
    }
}
