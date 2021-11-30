using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BryceResortPatrol.Common.Repositories
{
    public sealed class DatabaseContext
    {
        private readonly string databaseName = "BryceMountainPatrol";
        public DatabaseContext(CosmosClient cosmosClient)
        {
            this.Candidate = cosmosClient.GetContainer(databaseName, "candidate");
            this.Members = cosmosClient.GetContainer(databaseName, "members");
        }

        public Container Candidate { get; }
        public Container Members { get; }
    }
    public static class CosmosExtensions
    {
        public static async Task<IEnumerable<T>> Query<T>(this Container container, string sql)
        {
            var collection = new List<T>();
            var queryDefinition = new QueryDefinition(sql);
            var feedIterator = container.GetItemQueryIterator<T>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                foreach (var item in await feedIterator.ReadNextAsync())
                {
                    collection.Add(item);
                }
            }

            return collection;
        }
    }
}
