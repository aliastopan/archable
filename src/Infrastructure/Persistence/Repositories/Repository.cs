using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Archable.Application.Interfaces.Persistence.Repositories;
using Archable.Application.Models.Results;

namespace Archable.Infrastructure.Persistence.Repositories
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public Result<TEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Result Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Result AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Result Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Result RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}