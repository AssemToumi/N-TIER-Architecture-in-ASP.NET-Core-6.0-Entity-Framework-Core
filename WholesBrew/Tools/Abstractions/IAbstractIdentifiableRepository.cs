using System.Security.Principal;

namespace Helper
{
    public interface IAbstractIdentifiableRepository<TEntity, TEntityKey> : IAbstractRepository<TEntity> where TEntity : class, IIdentifiable<TEntityKey>, new()
    {
        Task<TEntity> GetByIdAsync(TEntityKey id);

        Task DeleteByIdAsync(TEntityKey id);
    }
}


