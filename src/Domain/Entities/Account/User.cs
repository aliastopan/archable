#nullable disable

namespace Archable.Domain.Entities.Account
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Flag { get; set; }
        public string Password { get; set; }
    }
}