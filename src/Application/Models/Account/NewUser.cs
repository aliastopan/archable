#nullable disable

namespace Archable.Application.Models.Account
{
    public sealed class NewUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Flag { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt => Id.ToString();

        public NewUser()
        {
            Id = Guid.NewGuid();
            Role = "none";
            Flag = "unverified";
        }
    }
}