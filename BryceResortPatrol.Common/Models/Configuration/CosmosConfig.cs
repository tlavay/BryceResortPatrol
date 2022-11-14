namespace BryceResortPatrol.Common.Models.Configuration;

internal record CosmosConfig
{
    public string DocumentEndpoint { get; init; }
    public string PrimaryMasterKey { get; init; }
}
