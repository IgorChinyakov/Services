using Infrastructure.DBContexts;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(sp =>
            {
                var connectionString = configuration.GetConnectionString(DbOptions.CONNECTION_STRING);
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(connectionString);

                return new ApplicationDbContext(optionsBuilder.Options);
            });

            return services;
        }
    }
}
