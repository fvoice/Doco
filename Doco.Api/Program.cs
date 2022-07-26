using Doco.Application;
using Doco.Infrastructure;
using Doco.Infrastructure.Persistence;

namespace Doco.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);

            // Add services to the container
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            Configure(app, builder.Environment);

            if (app.Environment.IsDevelopment())
            {
                // Initialise and seed database
                using (var scope = app.Services.CreateScope())
                {
                    var initializer = scope.ServiceProvider.GetRequiredService<DocoDbContextInitializer>();
                    await initializer.MigrateDb();
                    await initializer.Seed();
                }
            }

            await app.RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddAppServices();
            services.AddInfrastructureServices();
            services.AddApiServices();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}