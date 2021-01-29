using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SharpGun.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ReadJsonServiceExtensions
    {
        public static IServiceCollection AddReadJson(this IServiceCollection services, string jsonFilePath) {
            services.Configure<ReadJsonServiceOptions>(options => { options.JsonFilePath = jsonFilePath; });
            services.AddSingleton<IReadJsonService, ReadJsonService>();
            return services;
        }

        public static IServiceCollection AddReadJson(
            this IServiceCollection services,
            Action<ReadJsonServiceOptions> configureOptions
        ) {
            services.Configure(configureOptions);
            services.AddSingleton<IReadJsonService, ReadJsonService>();
            return services;
        }
    }
}

namespace SharpGun.Services
{
    public interface IReadJsonService
    {
        public void Bind(object instance);
        public IConfiguration GetConfig();
    }

    public class ReadJsonService : IReadJsonService
    {
        private readonly IConfiguration _config;

        public ReadJsonService(IOptions<ReadJsonServiceOptions> options) {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(options.Value.JsonFilePath);
            _config = builder.Build();
        }

        public void Bind(object instance) {
            _config.Bind(instance);
        }

        public IConfiguration GetConfig() {
            return _config;
        }
    }

    public class ReadJsonServiceOptions
    {
        public string JsonFilePath { get; set; }
    }
}
