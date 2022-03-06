using Microsoft.Extensions.DependencyInjection;
using Archable.Application.Controllers;

namespace Archable.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<UserController>();

            return services;
        }
    }
}