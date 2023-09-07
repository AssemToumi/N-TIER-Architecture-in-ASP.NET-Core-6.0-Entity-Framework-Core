using WholesBrew.Business.Facades.Abstractions;
using WholesBrew.Business.Facades.Base;
using Helper;
using WholesBrew.Contracts.Dtos;
using AutoMapper;
using WholesBrew.Business.Abstractions;
using WholesBrew.Model.Entities;
using WholesBrew.Contracts.DataTransferObjects;

namespace WholesBrew.Business.Facades;

[RegisterAsFacade]
public class WholesalerFacade : AbstractFacade, IWholesalerFacade
{
    private readonly IWholesalerService _wholesalersService;

    public WholesalerFacade(IMapper mapper, IWholesalerService wholesalerservice)
        : base(mapper)
    {
        _wholesalersService = wholesalerservice;
    }

    public async Task<IEnumerable<WholesalerStockDTO>> GetAllWholesalersAsync()
    {
        var wholesalers = await _wholesalersService.GetAllWholesalersAsync();
        return Mapper.Map<IEnumerable<WholesalerStockDTO>>(wholesalers);
    }
    public async Task<WholesalerDTO> CreateWholesalerAsync(WholesalerDTO newWholesaler)
    {
        var wholesalerEntity = Mapper.Map<WholesalerEntity>(newWholesaler);
        var createdWholesalerEntity = await _wholesalersService.CreateWholesalerAsync(wholesalerEntity);

        var wholesalerDTO = Mapper.Map<WholesalerDTO>(createdWholesalerEntity);
        return wholesalerDTO;
    }
    public async Task<RestrictionDTO> CreateRestrictionAsync(int wholesalerId, int beerId, int maxQuantity)
    {
        var beer = await _wholesalersService.CreateRestrictionAsync(wholesalerId, beerId, maxQuantity);
        return Mapper.Map<RestrictionDTO>(beer);
    }
    public async Task<WholesalerStockDTO> UpdateBeerQuantityAsync(int wholesalerId, int beerId, int newQuantity)
    {
        var beer = await _wholesalersService.UpdateBeerQuantityAsync(wholesalerId, beerId, newQuantity);
        return Mapper.Map<WholesalerStockDTO>(beer);
    }
    public async Task<QuoteResponseDTO> RequestQuoteAsync(int wholesalerId, QuoteRequestDTO quoterRequest)
    {
        var quote = Mapper.Map<QuoteRequestEntity>(quoterRequest);
        var quoterResponse = await _wholesalersService.RequestQuoteAsync(wholesalerId, quote);
        return Mapper.Map<QuoteResponseDTO>(quoterResponse);
    }
}