using Microsoft.Azure.Cosmos;

namespace BryceResortPatrol.Common.DataServices;
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
