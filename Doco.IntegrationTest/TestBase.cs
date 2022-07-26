using Doco.Api;
using Doco.Application;
using Doco.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Doco.IntegrationTest
{
    public abstract class TestBase
    {
        protected static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        protected IServiceCollection ServiceCollection = new ServiceCollection();
        protected IServiceProvider ServiceProvider;

        [SetUp]
        protected void Init()
        {
            ServiceCollection.AddSingleton(Configuration);
            ServiceCollection.AddAppServices();
            ServiceCollection.AddInfrastructureServices();
            ServiceCollection.AddApiServices();

            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        protected static T Clone<T>(T source)
        {
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializeSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings), deserializeSettings);
        }
    }
}
