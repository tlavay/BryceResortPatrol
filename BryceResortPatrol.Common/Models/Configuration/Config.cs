namespace BryceResortPatrol.Common.Models.Configuration;
internal record Config
{
    public Cosmos Cosmos { get; init; }
    public SendGridConfig SendGridConfig { get; init; }
}
