using Azure.Identity;
using BryceResortPatrol.Common.DataServices;
using BryceResortPatrol.Common.Extensions;
using BryceResortPatrol.Common.Models.Configuration;
using BryceResortPatrol.Common.Services;
using BryceResortPatrol.Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BryceResortPatrol.Common.Configuration;

public static class ConfigurationExtension
{
    public static void ConfigureBryceResortPatrolCommon(this IServiceCollection services)
    {
        services.ConfigureCoreServices();
        services.ConfigureConfig();
        services.ConfigureAuthentication();
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

    private static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("default", p =>
            {
                p.RequireAuthenticatedUser();
            });
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
                {
                    var tenantId = "a53917c1-e37e-4708-b58d-c332638a194a";
                    var clientId = "fdad1697-c941-43e2-ba32-74e3916b42f4";
                    o.Authority = $"https://login.microsoftonline.com/{tenantId}";
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudiences = new string[] { clientId, $"api://{clientId}" },
                        ValidIssuer = $"https://sts.windows.net/{tenantId}/",
                    };
                });
    }
}
