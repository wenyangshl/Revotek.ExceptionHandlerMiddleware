using System;

namespace Revotek.ExceptionHandlerMiddleware.Cores
{
    public interface IErrorLogger
    {
        public void Debug(string errorMessage, Exception ex = null);
        public void Info(string errorMessage, Exception ex = null);
        public void Warning(string errorMessage, Exception ex = null);
        public void Error(string errorMessage, Exception ex = null);
        public void Fatal(string errorMessage, Exception ex = null);
    }
}