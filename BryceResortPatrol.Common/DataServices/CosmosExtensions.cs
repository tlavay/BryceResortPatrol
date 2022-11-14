using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace BryceResortPatrol.Common.DataServices;
internal static class CosmosExtensions
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
