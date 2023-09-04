using System.Linq.Expressions;

namespace Helper
{
    public interface IAbstractRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}

