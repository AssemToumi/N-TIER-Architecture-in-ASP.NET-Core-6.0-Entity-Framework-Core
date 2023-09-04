using WholesBrew.Contracts.DataTransferObjects;
using WholesBrew.Contracts.Dtos;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business.Facades.Abstractions;

public interface IWholesalerFacade
{
    Task<IEnumerable<WholesalerStockDTO>> GetAllWholesalersAsync();
    Task<WholesalerDTO> CreateWholesalerAsync(WholesalerDTO newWholesaler);
    Task<RestrictionDTO> CreateRestrictionAsync(int wholesalerId, int beerId, int maxQuantity);
    Task<WholesalerStockDTO> UpdateBeerQuantityAsync(int wholesalerId, int beerId, int newQuantity);
    Task<QuoteResponseDTO> RequestQuoteAsync(int wholesalerId, QuoteRequestDTO quote);
}