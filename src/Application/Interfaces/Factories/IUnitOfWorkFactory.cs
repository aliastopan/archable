using Archable.Application.Interfaces.Persistence;

namespace Archable.Application.Interfaces.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}