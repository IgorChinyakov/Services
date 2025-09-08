using Application.Database;
using Application.LocationsFeatures.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(
            this IServiceCollection services)
        {
            services.AddScoped<CreateLocationHandler>();

            return services;
        }
    }
}
