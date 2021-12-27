namespace BryceResortPatrol.Common.Models.Configuration;

internal record Cosmos
{
    public string DocumentEndpoint { get; init; }
    public string PrimaryMasterKey { get; init; }
}
