using Kantor.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Kantor.Infrastructure.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string body = await GetRequestBodyAsync(context);

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                LogError(body, context, ex);
                string response = string.Empty;

                switch (ex)
                {
                    case AuthException:
                    {
                        response = ex.Message;
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    }

                    case DomainException:
                    { 
                        response = ex.Message;
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break; 
                    }

                    default:
                    {
                        response = "Wystąpił wewnętrzny błąd systemu.";
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        _logger.LogError($"Error: {ex}");
                        break;
                    }
                }
                    
                
                await context.Response.WriteAsJsonAsync(response);
            }
        }

        private async Task<string> GetRequestBodyAsync(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            var body = await new StreamReader(httpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();

            httpContext.Request.Body.Position = 0;

            return body;
        }

        private void LogError(string body, HttpContext context, Exception ex)
        {
            _logger.LogError($"Path: {context.Request.Path}" +
                $"\nBody: {body}" +
                $"\nError: {ex.Message}" +
                $"\nErrorType: {ex.GetType()}");
        }
    }
}
