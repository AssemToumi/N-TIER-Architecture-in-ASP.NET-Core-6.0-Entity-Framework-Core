using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Abstractions;

public interface IBrewerService
{
    Task<IEnumerable<BrewerEntity>> GetAllBrewersAsync();
    Task<BeerEntity> GetBeerByIdAsync(int BrewerId, int beerId);
    Task<IEnumerable<BeerEntity>> GetBeersByBrewerIdAsync(int BrewerId);
    Task<BrewerEntity> CreateBrewerAsync(BrewerEntity newBrewer);
    Task<BeerEntity> CreateBeerAsync(int BrewerId, BeerEntity newBeer);
    Task<SaleEntity> AddSaleToWholesalerAsync(int BrewerId, int beerId, int wholesalerId, int quantity);
    Task<BeerEntity> DeleteBeerAsync(int BrewerId, int beerId);
}
