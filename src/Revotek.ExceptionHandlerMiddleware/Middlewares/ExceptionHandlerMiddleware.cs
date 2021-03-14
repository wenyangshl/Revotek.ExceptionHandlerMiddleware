using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Revotek.ExceptionHandlerMiddleware.Cores;
using Revotek.ExceptionHandlerMiddleware.Loggers;

namespace Revotek.ExceptionHandlerMiddleware.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, Serilog.ILogger serilog = null, Microsoft.Extensions.Logging.ILogger microsoftLogger = null)
        {

            _next = next;
            if (serilog is not null)
            {
                _logger = new SerilogErrorLogger(serilog);
            }
            else if (microsoftLogger is not null)
            {
                _logger = new MicrosoftLoggerErrorLogger(microsoftLogger);
            }
            else
            {
                _logger = new ConsoleErrorLogger();
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    _logger.Error(e.Message);
                else
                    _logger.Error(e.Message, e);
                ErrorResponse errorResponse = ErrorHandler.Handle(e);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = errorResponse.ErrorCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
