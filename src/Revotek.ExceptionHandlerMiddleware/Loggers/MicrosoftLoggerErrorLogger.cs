using Revotek.ExceptionHandlerMiddleware.Cores;
using System;
using Microsoft.Extensions.Logging;
using Serilog.Configuration;

namespace Revotek.ExceptionHandlerMiddleware.Loggers
{
    public class MicrosoftLoggerErrorLogger : IErrorLogger
    {
        private readonly ILogger _logger;

        public MicrosoftLoggerErrorLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string errorMessage, Exception ex = null)
        {
            _logger.Log(LogLevel.Debug, errorMessage, ex);
        }

        public void Error(string errorMessage, Exception ex = null)
        {
            _logger.Log(LogLevel.Error, errorMessage, ex);
        }

        public void Fatal(string errorMessage, Exception ex = null)
        {
            _logger.Log(LogLevel.Critical, errorMessage, ex);
        }

        public void Info(string errorMessage, Exception ex = null)
        {
            _logger.Log(LogLevel.Information, errorMessage, ex);
        }

        public void Warning(string errorMessage, Exception ex = null)
        {
            _logger.Log(LogLevel.Warning, errorMessage, ex);
        }
    }
}