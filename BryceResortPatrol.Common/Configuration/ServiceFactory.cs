using BryceResortPatrol.Common.Models.Configuration;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace BryceResortPatrol.Common.Configuration
{
    public sealed class ServiceFactory
    {
        private readonly Config config;
        public ServiceFactory(IConfiguration configuration)
        {
            this.config = new Config();
            var configSection = configuration.GetSection("Config");
            configSection.Bind(this.config);
        }

        public DocumentClient CreateDocumentClient()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            var connectionPolicy = new ConnectionPolicy
            {
                ConnectionMode = ConnectionMode.Direct,
                ConnectionProtocol = Protocol.Tcp
            };

            var documentEndpoint = new Uri(this.config.Cosmos.DocumentEndpoint);
            return new DocumentClient(documentEndpoint, this.config.Cosmos.PrimaryMasterKey, serializerSettings, connectionPolicy);
        }
    }
}
