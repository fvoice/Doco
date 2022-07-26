using Doco.Api.Dto.Commands;

namespace Doco.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CreateUserCommandDto).Assembly);
            
            return services;
        }
    }
}
