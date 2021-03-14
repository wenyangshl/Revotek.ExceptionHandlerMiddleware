using Revotek.ExceptionHandlerMiddleware.Cores;
using System;
using Serilog;

namespace Revotek.ExceptionHandlerMiddleware.Loggers
{
    public class SerilogErrorLogger : IErrorLogger
    {
        private readonly ILogger _logger;

        public SerilogErrorLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string errorMessage, Exception ex = null)
        {
            _logger.Debug(errorMessage, ex);
        }

        public void Error(string errorMessage, Exception ex = null)
        {
            _logger.Error(errorMessage, ex);
        }

        public void Fatal(string errorMessage, Exception ex = null)
        {
            _logger.Fatal(errorMessage, ex);
        }

        public void Info(string errorMessage, Exception ex = null)
        {
            _logger.Information(errorMessage, ex);
        }

        public void Warning(string errorMessage, Exception ex = null)
        {
            _logger.Warning(errorMessage, ex);
        }
    }
}