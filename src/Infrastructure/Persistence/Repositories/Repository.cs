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
            var entity = Context.Set<TEntity>().Find(id);

            return entity is null
                ? NotFound()
                : Found(entity);

            #region LOCAL FUNCTION
            Result<TEntity> NotFound()
            {
                string type = typeof(TEntity).Name.ToUpper();
                string message = $"Not Found: {type} of ID '{id}' exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<TEntity>(exception);
            }

            Result<TEntity> Found(TEntity entity)
            {
                return Result.Ok<TEntity>(entity);
            }
            #endregion
        }

        public virtual Result<IEnumerable<TEntity>> GetAll()
        {
            var entities = Context.Set<TEntity>();

            return entities.Count<TEntity>() == 0
                ? NotFound()
                : Found(entities);

            #region LOCAL FUNCTION
            Result<IEnumerable<TEntity>> NotFound()
            {
                string type = typeof(TEntity).Name.ToUpper();
                string message = $"Not Found: {type} table is empty exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<IEnumerable<TEntity>>(exception);
            }

            Result<IEnumerable<TEntity>> Found(IEnumerable<TEntity> entities)
            {
                return Result.Ok<IEnumerable<TEntity>>(entities);
            }
            #endregion
        }

        public virtual Result<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Context.Set<TEntity>().Where(predicate);

            return entities.Count<TEntity>() == 0
                ? NotFound()
                : Found(entities);

            #region LOCAL FUNCTION
            Result<IEnumerable<TEntity>> NotFound()
            {
                string type = typeof(TEntity).Name.ToUpper();
                string message = $"Not Found: any {type} of predicate '{predicate.Body}' exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<IEnumerable<TEntity>>(exception);
            }

            Result<IEnumerable<TEntity>> Found(IEnumerable<TEntity> entities)
            {
                return Result.Ok<IEnumerable<TEntity>>(entities);
            }
            #endregion
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