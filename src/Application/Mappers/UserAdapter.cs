using Mapster;
using Archable.Application.Helpers.Security;
using Archable.Application.Enums.Account;
using Archable.Application.Models.Account;
using Archable.Domain.Entities.Account;

namespace Archable.Application.Mappers
{
    public static class UserAdapter
    {
        public static User AdaptToUser(this NewUser newUser)
        {
            var adapter = new TypeAdapterConfig()
                .NewConfig<NewUser, User>()
                .Map(dst => dst.Role, src => Role.CastFrom<Role>(src.RoleSelect).Name)
                .Map(dst => dst.Flag, src => AccountFlag.CastFrom<AccountFlag>(src.FlagSelect).Name)
                .Map(dst => dst.Password, src => Hasher.GetHash(src.Password, src.Salt));

            var user = newUser.Adapt<User>(adapter.Config);

            return user;
        }
    }
}