using BryceResortPatrol.Common.Repositories;
using BryceResortPatrol.Common.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BryceResortPatrol.Common.Configuration
{
    public static class ConfigurationExtension
    {
        public static void ConfigureBryceResortPatrolCommon(this IServiceCollection services)
        {
            services.AddSingleton<ServiceFactory>();
            services.AddTransient(c => c.GetService<ServiceFactory>().CreateDocumentClient());
            services.AddTransient<IJoinRepository, JoinRepository>();
            services.AddLogging();
        }
    }
}
