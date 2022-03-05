using Archable.Infrastructure.Persistence.Contexts;
using Archable.Application.Exceptions;
using Archable.Application.Interfaces.Persistence.Repositories;
using Archable.Application.Models.Results;
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

            return result is null
                ? Result.Fail<User>(ExceptionMessage.FAIL)
                : Result.Ok<User>(result!);
        }
    }
}