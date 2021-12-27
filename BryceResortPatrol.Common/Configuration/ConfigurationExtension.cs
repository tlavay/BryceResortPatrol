using BryceResortPatrol.Common.Models.Configuration;
using BryceResortPatrol.Common.Repositories;
using BryceResortPatrol.Common.Services;
using BryceResortPatrol.Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BryceResortPatrol.Common.Configuration
{
    public static class ConfigurationExtension
    {
        public static void ConfigureBryceResortPatrolCommon(this IServiceCollection services)
        {
            services.AddSingleton(s => ServiceFactory.CreateConfig(s.GetService<IConfiguration>()));
            services.AddTransient(s => ServiceFactory.CreateCosmosClient(s.GetService<Config>()));
            services.AddSingleton(s => ServiceFactory.CreateSendGridClient(s.GetService<Config>()));
            services.AddSingleton<DatabaseContext>();
            services.AddSingleton<IEmailClient, EmailClient>();
            services.AddLogging();
        }
    }
}
