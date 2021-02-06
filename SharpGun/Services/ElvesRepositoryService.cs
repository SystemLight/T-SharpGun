using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharpGun.Models;
using SharpGun.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ElvesRepositoryServiceExtensions
    {
        public static IServiceCollection AddElvesRepository(this IServiceCollection services, int maxAge) {
            services.Configure<ElvesRepositoryServiceOptions>(options => { options.MaxAge = maxAge; });
            services.AddTransient<IElvesRepositoryService, ElvesRepositoryService>();
            return services;
        }
    }
}

namespace SharpGun.Services
{
    public interface IElvesRepositoryService
    {
        public IEnumerable<Elves> GetAllElves();
        public Elves GetElvesById(int id);
        public int GetMaxAge();
    }

    public class ElvesRepositoryService : IElvesRepositoryService, IDisposable
    {
        private List<Elves> _elves;
        private readonly IOptions<ElvesRepositoryServiceOptions> _options;
        private readonly ILogger<ElvesRepositoryService> _logger;

        public ElvesRepositoryService(
            IOptions<ElvesRepositoryServiceOptions> options,
            ILogger<ElvesRepositoryService> logger
        ) {
            _logger = logger;
            _options = options;
            InitializeNoodle();
        }

        private void InitializeNoodle() {
            _elves = new List<Elves>
            {
                new Elves {Id = 1, Name = "a", Age = 12},
                new Elves {Id = 2, Name = "b", Age = 13},
                new Elves {Id = 3, Name = "c", Age = 14}
            };
        }

        public IEnumerable<Elves> GetAllElves() {
            return _elves;
        }

        public Elves GetElvesById(int id) {
            return _elves.FirstOrDefault(n => n.Id == id);
        }

        public int GetMaxAge() {
            return _options.Value.MaxAge;
        }

        /// <summary>
        /// 如果需要容器释放服务，请实现IDisposable接口执行释放逻辑
        /// </summary>
        public void Dispose() {
            _logger.LogInformation("[{time}] Dispose ElvesRepositoryService", DateTime.Now);
            using (_logger.BeginScope("ScopeID:{scopeID}", Guid.NewGuid())) {
                _logger.LogInformation("Scope logger-1");
                _logger.LogInformation("Scope logger-2");
                _logger.LogInformation("Scope logger-3");
            }
        }
    }

    public class ElvesRepositoryServiceOptions
    {
        public int MaxAge = 100;
    }

    public class ElvesRepositoryServiceValidateOptions : IValidateOptions<ElvesRepositoryServiceOptions>
    {
        public ValidateOptionsResult Validate(string name, ElvesRepositoryServiceOptions options) {
            return options.MaxAge > 100 ? ValidateOptionsResult.Fail("MaxAge不能大于100") : ValidateOptionsResult.Success;
        }
    }
}
