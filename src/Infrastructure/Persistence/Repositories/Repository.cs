using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Archable.Domain.Entities;

namespace Archable.Infrastructure.Persistence.Repositories
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public virtual Result<TEntity> Get(Guid id)
        {
            var result = Context.Set<TEntity>().Find(id);

            return result is null
                ? Result.Fail<TEntity>(ExceptionMessage.ENTITY_NOT_FOUND)
                : Result.Ok<TEntity>(result!);
        }

        public virtual Result<IEnumerable<TEntity>> GetAll()
        {
            var result = Context.Set<TEntity>();

            return result.Count<TEntity>() == 0
                ? Result.Fail<IEnumerable<TEntity>>(ExceptionMessage.ENTITY_NOT_FOUND)
                : Result.Ok<IEnumerable<TEntity>>(result as IEnumerable<TEntity>);
        }

        public virtual Result<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Context.Set<TEntity>().Where(predicate);

            return result.Count<TEntity>() == 0
                ? Result.Fail<IEnumerable<TEntity>>(ExceptionMessage.ENTITY_NOT_FOUND)
                : Result.Ok<IEnumerable<TEntity>>(result as IEnumerable<TEntity>);
        }

        public virtual Result Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);

            return Result.Ok();
        }

        public virtual Result AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);

            return Result.Ok();
        }

        public virtual Result Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);

            return Result.Ok();
        }

        public virtual Result RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return Result.Ok();
        }
    }
}