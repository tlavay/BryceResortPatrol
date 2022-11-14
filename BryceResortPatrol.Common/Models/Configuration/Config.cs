namespace BryceResortPatrol.Common.Models.Configuration;
internal record Config
{
    public CosmosConfig Cosmos { get; init; }
    public SendGridConfig SendGridConfig { get; init; }
}
