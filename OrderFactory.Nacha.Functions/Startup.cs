using System.Reflection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderFactory.Nacha.Functions;
using OrderFactory.Nacha.Parser.Core;
using OrderFactory.Nacha.Parser.Data;

[assembly: FunctionsStartup(typeof(Startup))]

namespace OrderFactory.Nacha.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config.GetConnectionString("NachaDbConnectionString");
            builder.Services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(connectionString));

            builder.Services.AddSingleton<IGuidGenerator, GuidGenerator>();
            builder.Services.AddSingleton<IAchParser, AchParser>();
            builder.Services.AddSingleton<IAchRepository, AchRepository>();
            builder.Services.AddSingleton<IAchService, AchService>();
        }
    }
}