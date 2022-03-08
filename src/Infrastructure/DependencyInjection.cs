using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Archable.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IStorageProvider, MockStorageService>();

            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();

            return services;
        }
    }
}