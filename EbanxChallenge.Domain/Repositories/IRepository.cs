using System.Linq.Expressions;

namespace EbanxChallenge.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(Predicate<TEntity> predicate);
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
        
    }
}