using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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
            var result = Context.Set<TEntity>().Find(id);

            return result is null
                ? Result.Fail<TEntity>(ExceptionMessage.ENTITY_NOT_FOUND)
                : Result.Ok<TEntity>(result!);
        }

        public Result<IEnumerable<TEntity>> GetAll()
        {
            var result = Context.Set<TEntity>();

            return result.Count<TEntity>() == 0
                ? Result.Fail<IEnumerable<TEntity>>(ExceptionMessage.ENTITY_NOT_FOUND)
                : Result.Ok<IEnumerable<TEntity>>(result as IEnumerable<TEntity>);
        }

        public Result<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Context.Set<TEntity>().Where(predicate);

            return result.Count<TEntity>() == 0
                ? Result.Fail<IEnumerable<TEntity>>(ExceptionMessage.ENTITY_NOT_FOUND)
                : Result.Ok<IEnumerable<TEntity>>(result as IEnumerable<TEntity>);
        }

        public Result Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);

            return Result.Ok();
        }

        public Result AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);

            return Result.Ok();
        }

        public Result Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);

            return Result.Ok();
        }

        public Result RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return Result.Ok();
        }
    }
}