using Archable.Domain.Entities.Account;

namespace Archable.Infrastructure.Persistence.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        private MainDbContext _context => (MainDbContext) base.Context;

        public UserRepository(MainDbContext context)
            :base(context)
        { }

        public Result<User> LookUp(string username)
        {
            var result = _context.Users.SingleOrDefault(search => search.Username == username);
            var notFound = result is null;

            if(notFound)
            {
                return Result.Fail<User>(new Exception());
            }
            else
            {
                return Result.Ok<User>(result!);
            }
        }
    }
}