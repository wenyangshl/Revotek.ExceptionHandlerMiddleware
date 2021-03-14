using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;

namespace Revotek.ExceptionHandlerMiddleware.Cores
{
    public static class ErrorHandler
    {
        public static ErrorResponse Handle(Exception ex) =>
            ex switch
            {
                ArgumentException
                    or ValidationException => new ErrorResponse(400,
                        ex.Message,
                        ex.StackTrace,
                        ex.InnerException),
                AuthenticationException => new ErrorResponse(401,
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException),
                _ => new ErrorResponse(500,
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException)
            };
    }
}
