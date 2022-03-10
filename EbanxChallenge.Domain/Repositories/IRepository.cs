using System.Linq.Expressions;

namespace EbanxChallenge.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);

        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}