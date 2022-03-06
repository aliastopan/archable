using Archable.Application.Enums.Account;

#nullable disable

namespace Archable.Application.Models.Account
{
    public sealed class NewUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int RoleSelect { get; set; }
        public int FlagSelect { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt => Id.ToString();

        public NewUser()
        {
            Id = Guid.NewGuid();
            RoleSelect = Role.None.Value;
            FlagSelect = AccountFlag.Unverified.Value;
        }
    }
}