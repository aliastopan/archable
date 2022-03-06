using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Archable.Application.Controllers;
using Archable.Application.Validators;

namespace Archable.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<UserController>();

            services.AddValidatorsFromAssemblyContaining<NewUserValidator>(ServiceLifetime.Transient);

            return services;
        }
    }
}