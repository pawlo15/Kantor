using Kantor.Shared.Policy;
using Kantor.Shared.Settings;

namespace Kantor.Api.Extensions
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddAuthorizationExtension(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Settings.Policy.LoggedClient, policy => 
                    policy.Requirements.Add( new RoleRequirement( new List<RoleEnum> { 
                            RoleEnum.Client 
                        }
                    ))
                );
            });

            return services;
        }
    }
}
