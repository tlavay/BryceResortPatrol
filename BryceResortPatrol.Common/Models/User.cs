namespace BryceResortPatrol.Common.Models
{
    public sealed class User
    {
        public string Id { get { return this.Username; } }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Hash { get; set; }
    }
}
