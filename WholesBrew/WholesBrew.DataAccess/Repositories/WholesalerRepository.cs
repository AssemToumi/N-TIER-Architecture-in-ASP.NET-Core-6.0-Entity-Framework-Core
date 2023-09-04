using Helper;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Repositories;

[RegisterAsRepository]
public class WholesalerRepository : AbstractIdentifiableRepository<WholesalerEntity, int>, IWholesalerRepository
{
    public WholesalerRepository(WholesBrewDbContext medbacDbContext)
    : base(medbacDbContext)
    {
    }
}
