using BryceResortPatrol.Common.Models.Configuration;
using BryceResortPatrol.Common.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BryceResortPatrol.Common.Configuration
{
    public static class ConfigurationExtension
    {
        public static void ConfigureBryceResortPatrolCommon(this IServiceCollection services)
        {
            services.AddSingleton(s => ServiceFactory.CreateConfig(s.GetService<IConfiguration>()));
            services.AddTransient(c => ServiceFactory.CreateCosmosClient(c.GetService<Config>()));
            services.AddSingleton<DatabaseContext>();
            services.AddLogging();
        }
    }
}
