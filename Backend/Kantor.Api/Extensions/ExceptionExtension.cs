using Kantor.Infrastructure.Middleware;

namespace Kantor.Api.Extensions
{
    public static class ExceptionExtension
    {
        public static IApplicationBuilder UseExceptionExtension(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
