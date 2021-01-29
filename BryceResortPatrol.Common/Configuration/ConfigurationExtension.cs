using BryceResortPatrol.Common.Repositories;
using BryceResortPatrol.Common.Repositories.Interfaces;
using BryceResortPatrol.Common.Services;
using BryceResortPatrol.Common.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BryceResortPatrol.Common.Configuration
{
    public static class ConfigurationExtension
    {
        public static void ConfigureBryceResortPatrolCommon(this IServiceCollection services)
        {
            services.AddSingleton<ServiceFactory>();
            services.AddSingleton(c => c.GetService<ServiceFactory>().CreateConfig());
            services.AddLogging();
            services.ConfigureRepositories();
            services.ConfigureServices();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateService, AuthenticateService>();
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient(c => c.GetService<ServiceFactory>().CreateDocumentClient());
            services.AddTransient<IJoinRepository, JoinRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
