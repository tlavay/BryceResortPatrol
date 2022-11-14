using Azure.Identity;
using BryceResortPatrol.Common.Extensions;
using BryceResortPatrol.Common.Models.Configuration;
using BryceResortPatrol.Common.Repositories;
using BryceResortPatrol.Common.Services;
using BryceResortPatrol.Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BryceResortPatrol.Common.Configuration;

public static class ConfigurationExtension
{
    public static void ConfigureBryceResortPatrolCommon(this IServiceCollection services)
    {
        services.ConfigureCoreServices();
        services.ConfigureConfig();
    }

    private static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddSingleton(p => ServiceFactory.CreateCosmosClient(p.GetAndValidateService<DefaultAzureCredential>(), p.GetAndValidateService<CosmosConfig>()));
        services.AddSingleton(p => ServiceFactory.CreateSendGridClient(p.GetService<SendGridConfig>()));
        services.AddTransient(p => ServiceFactory.CreateDefaultAzureCredential());
        services.AddSingleton<DatabaseContext>();
        services.AddSingleton<IEmailClient, EmailClient>();
        services.AddLogging();
    }

    private static void ConfigureConfig(this IServiceCollection services)
    {
        services.AddSingleton(s => ServiceFactory.CreateConfig(s.GetService<IConfiguration>()));
        services.AddSingleton(p => p.GetAndValidateServiceProperty<Config, CosmosConfig>());
        services.AddSingleton(p => p.GetAndValidateServiceProperty<Config, SendGridConfig>());
    }
}
