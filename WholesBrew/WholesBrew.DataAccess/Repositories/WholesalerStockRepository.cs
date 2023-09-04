using Helper;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Repositories;

[RegisterAsRepository]
public class WholesalerStockRepository : AbstractIdentifiableRepository<WholesalerStockEntity, int>, IWholesalerStockRepository
{
    public WholesalerStockRepository(WholesBrewDbContext medbacDbContext)
    : base(medbacDbContext)
    {
    }
}
