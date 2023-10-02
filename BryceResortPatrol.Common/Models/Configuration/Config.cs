namespace BryceResortPatrol.Common.Models.Configuration;
internal record Config
{
    public CosmosConfig CosmosConfig { get; init; }
    public SendGridConfig SendGridConfig { get; init; }
}
