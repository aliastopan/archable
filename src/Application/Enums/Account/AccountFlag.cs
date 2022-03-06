namespace Archable.Application.Enums.Account
{
    public sealed class AccountFlag : Enumeration
    {
        public static readonly AccountFlag Unverified = new AccountFlag(0, "unverified");
        public static readonly AccountFlag Verified = new AccountFlag(1, "verified");
        public static readonly AccountFlag Suspended = new AccountFlag(10, "suspended");

        public AccountFlag(int value, string name)
            :base(value, name)
        { }
    }
}