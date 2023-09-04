using System.Linq;
using Helper;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Repositories;

[RegisterAsRepository]
public class BeerRepository : AbstractIdentifiableRepository<BeerEntity, int>, IBeerRepository
{
    public BeerRepository(WholesBrewDbContext medbacDbContext)
    : base(medbacDbContext)
    {
    }
}
