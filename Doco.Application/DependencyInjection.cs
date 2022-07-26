using System.Reflection;
using Doco.Application.Interfaces.Services;
using Doco.Application.Services;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddFluentValidation(new[] { Assembly.GetExecutingAssembly() });
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IUserTypeService, UserTypeService>();

            return services;
        }
    }
}
