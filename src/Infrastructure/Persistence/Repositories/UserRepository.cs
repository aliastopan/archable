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
            var user = _context.Users.SingleOrDefault(search => search.Username == username);

            return user is null
                ? NotFound()
                : Found(user);

            #region LOCAL FUNCTION
            Result<User> NotFound()
            {
                string message = $"Not Found: USER of USERNAME '{username}' exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<User>(exception);
            }

            Result<User> Found(User user)
            {
                return Result.Ok<User>(user);
            }
            #endregion
        }
    }
}