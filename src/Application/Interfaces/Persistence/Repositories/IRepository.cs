using System.Linq.Expressions;

namespace Archable.Application.Interfaces.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Result<TEntity> Get(Guid id);
        Result<IEnumerable<TEntity>> GetAll();
        Result<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Result Add(TEntity entity);
        Result AddRange(IEnumerable<TEntity> entities);
        Result Remove(TEntity entity);
        Result RemoveRange(IEnumerable<TEntity> entities);
    }
}