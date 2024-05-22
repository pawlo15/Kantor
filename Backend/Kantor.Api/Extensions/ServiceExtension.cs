using Kantor.Core.Services;
using Kantor.Core.Services.Interfaces;
using Kantor.Infrastructure.Middleware;
using Kantor.Infrastructure.Repositories;
using Kantor.Infrastructure.Repositories.Interfaces;
using Kantor.Shared.Policy;
using Microsoft.AspNetCore.Authorization;

namespace Kantor.Api.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenGenerator, TokenGenerator>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddHttpClient();
            services.AddScoped<ICurrencyService, CurrencyService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IAuthorizationHandler, RoleHandler>();

            services.AddSingleton<ExceptionMiddleware>();

            return services;
        }
    }
}
