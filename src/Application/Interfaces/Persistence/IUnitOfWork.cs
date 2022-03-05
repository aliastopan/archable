using Archable.Application.Interfaces.Persistence.Repositories;
using Archable.Application.Models.Results;

namespace Archable.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Result<int> Complete();
    }
}