using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WholesBrew.Contracts.Dtos;

namespace WholesBrew.Business.Facades.Abstractions;

public interface IBrewerFacade
{
    Task<IEnumerable<BrewerDTO>> GetAllBrewersAsync();
    Task<BeerDTO> GetBeerByIdAsync(int BrewerId, int beerId);
    Task<IEnumerable<BeerDTO>> GetBeersByBrewerIdAsync(int BrewerId);
    Task<BrewerDTO> CreateBrewerAsync(BrewerDTO newBrewer);
    Task<BeerDTO> CreateBeerAsync(int BrewerId, BeerDTO newBeer);
    Task<SaleDTO> AddSaleToWholesalerAsync(int BrewerId, int beerId, int wholesalerId, int quantity);
    Task<BeerDTO> DeleteBeerAsync(int BrewerId, int beerId);
}
