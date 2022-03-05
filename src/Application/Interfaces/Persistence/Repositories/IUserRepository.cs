using Archable.Domain.Entities.Account;

namespace Archable.Application.Interfaces.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Result<User> LookUp(string username);
    }
}