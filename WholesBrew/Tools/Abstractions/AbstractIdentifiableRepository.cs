using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Helper
{
    public abstract class AbstractIdentifiableRepository<TEntity, TEntityKey> : AbstractRepository<TEntity>, IAbstractIdentifiableRepository<TEntity, TEntityKey>, IAbstractRepository<TEntity> where TEntity : class, IIdentifiable<TEntityKey>, new()
    {
        protected AbstractIdentifiableRepository(DbContext context)
            : base(context)
        {
        }

        public async Task<TEntity> GetByIdAsync(TEntityKey id)
        {
            TEntity entity = await Get((t) => t.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity != null)
            {
                return entity;
            }

            throw new EntityNotFoundException($"The entity identified by the ID <{id}> was not found!");
        }


        public async Task DeleteByIdAsync(TEntityKey id)
        {
            Delete(await GetByIdAsync(id));
        }

        public override Task<Page<TEntity>> GetAsync<TSortKey>(Expression<Func<TEntity, bool>>? predicate, Expression<Func<TEntity, TSortKey>>? sortKeySelector, bool? sortAscending, int? limit, int? offset)
        {
            return sortKeySelector == null ? base.GetAsync(predicate, (e) => e.Id, sortAscending, limit, offset) : base.GetAsync(predicate, sortKeySelector, sortAscending, limit, offset);
        }
    }
}
