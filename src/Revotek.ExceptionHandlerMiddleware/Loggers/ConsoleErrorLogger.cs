using Revotek.ExceptionHandlerMiddleware.Cores;
using System;

namespace Revotek.ExceptionHandlerMiddleware.Loggers
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void Debug(string errorMessage, Exception ex = null)
        {
            ConsoleLog("Debug", errorMessage, ex);
        }

        public void Error(string errorMessage, Exception ex = null)
        {
            ConsoleLog("Error", errorMessage, ex);
        }

        public void Fatal(string errorMessage, Exception ex = null)
        {
            ConsoleLog("Fatal", errorMessage, ex);
        }

        public void Info(string errorMessage, Exception ex = null)
        {
            ConsoleLog("Info", errorMessage, ex);
        }

        public void Warning(string errorMessage, Exception ex = null)
        {
            ConsoleLog("Warning", errorMessage, ex);
        }

        private void ConsoleLog(string logLevel, string errorMessage, Exception innerException)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.fff")}][{logLevel}] - {errorMessage}");
            if (innerException is not null)
            {
                ConsoleLog(logLevel, $"[Inner Exception]{innerException.Message}", null);
            }
        }
    }
}