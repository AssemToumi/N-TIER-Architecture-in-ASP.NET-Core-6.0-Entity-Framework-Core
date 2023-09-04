using WholesBrew.DataAccess.Abstractions.Repositories;

namespace WholesBrew.DataAccess.Abstractions;

public interface IWholesBrewUnitOfWork
{
    IBrewerRepository BrewerRepository { get; }
    IBeerRepository BeerRepository { get; }
    IWholesalerRepository WholesalerRepository { get; }
    IWholesalerStockRepository WholesalerStockRepository { get; }
    IRestrictionRepository RestrictionRepository { get; }
    ISaleRepository SaleRepository { get; }
    Task<int> SaveChangesAsync();
}