using Azure.Identity;
using BryceResortPatrol.Common.Models.Configuration;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using SendGrid;

namespace BryceResortPatrol.Common.Configuration;

internal static class ServiceFactory
{
    public static Config CreateConfig(IConfiguration configuration)
    {
        return configuration.GetSection("Config").Get<Config>();
    }

    public static CosmosClient CreateCosmosClient(DefaultAzureCredential defaultAzureCredential, CosmosConfig cosmosConfig)
    {
        var clientOptions = new CosmosClientOptions()
        {
            SerializerOptions = new CosmosSerializationOptions { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase },
            AllowBulkExecution = true
        };

        return new CosmosClient(cosmosConfig.DocumentEndpoint, defaultAzureCredential, clientOptions);
    }

    public static SendGridClient CreateSendGridClient(SendGridConfig sendGridConfig)
    {
        return new SendGridClient(sendGridConfig.ApiKey);
    }

    public static DefaultAzureCredential CreateDefaultAzureCredential()
    {
        return new DefaultAzureCredential();
    }
}
