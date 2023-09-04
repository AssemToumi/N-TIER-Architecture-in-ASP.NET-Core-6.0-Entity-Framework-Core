using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Helper
{
    public class AbstractRepository<TEntity> : IAbstractRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        protected AbstractRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Get().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Get().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<Page<TEntity>> GetAsync<TSortKey>(Expression<Func<TEntity, bool>>? predicate, Expression<Func<TEntity, TSortKey>>? sortKeySelector, bool? sortAscending, int? limit, int? offset)
        {
            IQueryable<TEntity> query = Get(predicate);
            if (sortKeySelector != null)
            {
                query = sortAscending.GetValueOrDefault(true) ? query.OrderBy(sortKeySelector) : query.OrderByDescending(sortKeySelector);
            }

            Page<TEntity> result = new Page<TEntity>
            {
                Offset = offset,
                Limit = limit,
                Total = query.Count()
            };
            if (offset.HasValue)
            {
                query = query.Skip(offset.Value);
            }

            if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }

            Page<TEntity> page = result;
            page.Items = await query.ToListAsync();
            return result;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>();
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            return queryable;
        }
    }
}


