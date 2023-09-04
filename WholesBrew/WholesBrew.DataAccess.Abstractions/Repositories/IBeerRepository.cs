using Helper;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Abstractions.Repositories;

public interface IBeerRepository : IAbstractIdentifiableRepository<BeerEntity, int>
{
}
