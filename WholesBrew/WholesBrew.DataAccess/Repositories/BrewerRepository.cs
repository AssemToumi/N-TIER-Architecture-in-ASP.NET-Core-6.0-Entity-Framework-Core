using Helper;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Repositories;

[RegisterAsRepository]
public class BrewerRepository : AbstractIdentifiableRepository<BrewerEntity, int>, IBrewerRepository
{
    public BrewerRepository(WholesBrewDbContext medbacDbContext)
    : base(medbacDbContext)
    {
    }
}
