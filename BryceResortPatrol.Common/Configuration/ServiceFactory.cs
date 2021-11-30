using BryceResortPatrol.Common.Models.Configuration;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;

namespace BryceResortPatrol.Common.Configuration
{
    internal static class ServiceFactory
    {
        public static Config CreateConfig(IConfiguration configuration)
        {
            return configuration.GetSection("Config").Get<Config>();
        }

        public static CosmosClient CreateCosmosClient(Config config)
        {
            var clientOptions = new CosmosClientOptions()
            {
                SerializerOptions = new CosmosSerializationOptions { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase },
                AllowBulkExecution = true
            };

            return new CosmosClient(config.Cosmos.DocumentEndpoint, config.Cosmos.PrimaryMasterKey, clientOptions);
        }
    }
}
