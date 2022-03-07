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
            var notFound = result is null;

            if(notFound)
            {
                var message = $"Not Found: {typeof(TEntity).Name.ToUpper()} of ID '{id}' exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<TEntity>(exception);
            }
            else
            {
                return Result.Ok<TEntity>(result!);
            }
        }

        public virtual Result<IEnumerable<TEntity>> GetAll()
        {
            var result = Context.Set<TEntity>();
            var notFound = result.Count<TEntity>() == 0;

            if(notFound)
            {
                var message = $"Not Found: {typeof(TEntity).Name.ToUpper()} table is empty exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<IEnumerable<TEntity>>(exception);
            }
            else
            {
                return Result.Ok<IEnumerable<TEntity>>(result);
            }
        }

        public virtual Result<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Context.Set<TEntity>().Where(predicate);
            var notFound = result.Count<TEntity>() == 0;

            if(notFound)
            {
                var message = $"Not Found: any {typeof(TEntity).Name.ToUpper()} of predicate '{predicate.Body}' exception.";
                var exception = new EntityNotFoundException(message);

                return Result.Fail<IEnumerable<TEntity>>(exception);
            }
            else
            {
                return Result.Ok<IEnumerable<TEntity>>(result);
            }
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