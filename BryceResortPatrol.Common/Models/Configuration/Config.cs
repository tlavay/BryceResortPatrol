namespace BryceResortPatrol.Common.Models.Configuration
{
    public sealed class Config
    {
        public Cosmos Cosmos { get; set; }
        public string BaseUrl { get; set; }
        public string Salt { get; set; }
        public int TokenTimeOutMinutes { get; set; }
    }
}
