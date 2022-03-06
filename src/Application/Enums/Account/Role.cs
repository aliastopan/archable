namespace Archable.Application.Enums.Account
{
    public sealed class Role : Enumeration
    {
        public static readonly Role None = new Role(0, "none");
        public static readonly Role Developer = new Role(99, "developer");

        public Role(int value, string name)
            :base(value, name)
        { }
    }
}