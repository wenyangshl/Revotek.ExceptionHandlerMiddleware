using System;

namespace Revotek.ExceptionHandlerMiddleware.Cores
{
    /// <summary>
    /// Error Response Message that will be returned
    /// </summary>
    public record ErrorResponse(int ErrorCode, string ErrorMessage, string StackTrace, Exception InnerException);
}
