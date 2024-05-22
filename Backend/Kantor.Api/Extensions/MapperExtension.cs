using System.Runtime.Loader;

namespace Kantor.Api.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                AssemblyLoadContext.Default.LoadFromAssemblyPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Kantor.Core.dll")));

            return services;
        }
    }
}
