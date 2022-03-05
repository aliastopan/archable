using Archable.Infrastructure.Persistence.Contexts;
using Archable.Infrastructure.Persistence.Repositories;
using Archable.Application.Interfaces.Persistence;
using Archable.Application.Interfaces.Persistence.Repositories;
using Archable.Application.Models.Results;

namespace Archable.Infrastructure.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _context;

        public IUserRepository UserRepository { get; init; }

        public UnitOfWork()
        {
            _context = new MainDbContext();

            UserRepository = new UserRepository(_context);
        }

        public Result<int> Complete()
        {
            int changes = _context.SaveChanges();

            return Result.Ok<int>(changes);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}