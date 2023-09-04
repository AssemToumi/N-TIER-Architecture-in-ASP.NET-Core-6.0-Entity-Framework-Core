using Helper;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Repositories;

[RegisterAsRepository]
public class SaleRepository : AbstractIdentifiableRepository<SaleEntity, int>, ISaleRepository
{
    public SaleRepository(WholesBrewDbContext medbacDbContext)
    : base(medbacDbContext)
    {
    }
}
