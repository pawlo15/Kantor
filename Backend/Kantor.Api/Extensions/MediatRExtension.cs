using System.Reflection;
using System.Runtime.Loader;

namespace Kantor.Api.Extensions
{
    public static class MediatRExtension
    {
        private static Assembly assembly =
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Kantor.Core.dll"));

        public static IServiceCollection AddMediatREntension(this IServiceCollection service)
        {
            service.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
            return service;
        }
    }
}
