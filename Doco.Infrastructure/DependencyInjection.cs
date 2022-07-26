using Doco.Application.Interfaces.Repositories;
using Doco.Infrastructure.Persistence;
using Doco.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doco.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<DocoDbContext>(options =>
                    options.UseInMemoryDatabase("Doco"));
            }
            else
            {
                services.AddDbContext<DocoDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(DocoDbContext).Assembly.FullName)));
            }

            services.AddScoped<DocoDbContext>();
            services.AddScoped<DocoDbContextInitializer>();

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
