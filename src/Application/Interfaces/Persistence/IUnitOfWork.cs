using Archable.Application.Interfaces.Persistence.Repositories;

namespace Archable.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Result<int> Complete();
    }
}