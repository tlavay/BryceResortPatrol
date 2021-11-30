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

            return new CosmosClient("AccountEndpoint=https://bryce-mountain-patrol-prod1.documents.azure.com:443/;AccountKey=8kZTkRAqkGJpr1TCQOnreHe3ND9NA0NAJodf7WzVwDQk7iq8gvEIRkVkRLWPk8AwAYOwy7AdPGSsFY4Zpvo87Q==;", clientOptions);
        }
    }
}
