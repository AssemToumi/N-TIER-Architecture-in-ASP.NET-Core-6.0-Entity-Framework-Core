using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Abstractions;

public interface IWholesalerService
{
    Task<IEnumerable<WholesalerStockEntity>> GetAllWholesalersAsync();
    Task<WholesalerEntity> CreateWholesalerAsync(WholesalerEntity newWholesaler);
    Task<RestrictionEntity> CreateRestrictionAsync(int wholesalerId, int beerId, int maxQuantity);
    Task<WholesalerStockEntity> UpdateBeerQuantityAsync(int wholesalerId, int beerId, int newQuantity);
    Task<QuoteResponseEntity> RequestQuoteAsync(int wholesalerId, QuoteRequestEntity quote);
}