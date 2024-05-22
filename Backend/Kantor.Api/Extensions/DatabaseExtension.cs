using Kantor.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Kantor.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, WebApplicationBuilder app)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseNpgsql(app.Configuration.GetConnectionString("DbConnection")));

            return services;
        }
    }
}
