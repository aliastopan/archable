using Archable.Application.Interfaces.Factories;
using Archable.Application.Interfaces.Persistence;
using Archable.Infrastructure.Persistence;

namespace Archable.Infrastructure.Factories
{
    internal sealed class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}