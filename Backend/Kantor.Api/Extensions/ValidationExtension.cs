using FluentValidation;
using System.Reflection;
using System.Runtime.Loader;

namespace Kantor.Api.Extensions
{
    public static class ValidationExtension
    {
        private static Assembly assembly =
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"Kantor.Infrastructure.dll"));

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
