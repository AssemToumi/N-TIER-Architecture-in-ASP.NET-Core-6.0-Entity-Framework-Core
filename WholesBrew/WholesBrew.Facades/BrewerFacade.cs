using AutoMapper;
using WholesBrew.Business.Abstractions;
using WholesBrew.Business.Facades.Abstractions;
using WholesBrew.Business.Facades.Base;
using WholesBrew.Model.Entities;
using WholesBrew.Contracts.Dtos;
using Helper;

namespace WholesBrew.Business.Facades;

[RegisterAsFacade]
public class BrewerFacade : AbstractFacade, IBrewerFacade
{
    private readonly IBrewerService _brewerService;

    public BrewerFacade(IMapper mapper, IBrewerService brewerservice)
        : base(mapper)
        => _brewerService = brewerservice;

    public async Task<IEnumerable<BrewerDTO>> GetAllBrewersAsync()
    {
        var brewers = await _brewerService.GetAllBrewersAsync();
        return Mapper.Map<IEnumerable<BrewerDTO>>(brewers);
    }
    public async Task<BeerDTO> GetBeerByIdAsync(int BrewerId, int beerId)
    {
        var beer = await _brewerService.GetBeerByIdAsync(BrewerId, beerId);
        return Mapper.Map<BeerDTO>(beer);
    }
    public async Task<IEnumerable<BeerDTO>> GetBeersByBrewerIdAsync(int BrewerId)
    {
        var beer = await _brewerService.GetBeersByBrewerIdAsync(BrewerId);
        return Mapper.Map<IEnumerable<BeerDTO>>(beer);
    }
    public async Task<BrewerDTO> CreateBrewerAsync(BrewerDTO newBrewer)
    {
        var _brewer = Mapper.Map<BrewerEntity>(newBrewer);
        var brewer = await _brewerService.CreateBrewerAsync(_brewer);
        return Mapper.Map<BrewerDTO>(brewer);
    }
    public async Task<BeerDTO> CreateBeerAsync(int BrewerId, BeerDTO newBeer)
    {
        var _newBeer = Mapper.Map<BeerEntity>(newBeer);
        var beer = await _brewerService.CreateBeerAsync(BrewerId, _newBeer);
        return Mapper.Map<BeerDTO>(beer);
    }
    public async Task<SaleDTO> AddSaleToWholesalerAsync(int BrewerId, int beerId, int wholesalerId, int quantity)
    {
        var sale = await _brewerService.AddSaleToWholesalerAsync(BrewerId, beerId , wholesalerId, quantity);
        return Mapper.Map<SaleDTO>(sale);
    }
    public async Task<BeerDTO> DeleteBeerAsync(int BrewerId, int beerId)
    {
        var beer = await _brewerService.DeleteBeerAsync(BrewerId, beerId);
        return Mapper.Map<BeerDTO>(beer);
    }
}
