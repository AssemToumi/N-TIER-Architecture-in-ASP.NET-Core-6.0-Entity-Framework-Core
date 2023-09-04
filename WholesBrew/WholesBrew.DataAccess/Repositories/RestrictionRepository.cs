using Helper;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Repositories;

[RegisterAsRepository]
public class RestrictionRepository : AbstractIdentifiableRepository<RestrictionEntity, int>, IRestrictionRepository
{
    public RestrictionRepository(WholesBrewDbContext medbacDbContext)
    : base(medbacDbContext)
    {
    }
}
