using Microsoft.AspNetCore.Mvc;
using WholesBrew.Api.Controllers.V1.Abstractions;
using WholesBrew.Business.Facades;
using WholesBrew.Business.Facades.Abstractions;
using WholesBrew.Contracts.Dtos;

namespace WholesBrew.Controllers.V1
{
    public class BrewerController : BrewerApiController
    {
        private readonly IBrewerFacade _brewerFacade;

        public BrewerController(IBrewerFacade beerFacade)
            => _brewerFacade = beerFacade;

    
        public override async Task<IActionResult> GetAllBrewers()
            => Ok(await _brewerFacade.GetAllBrewersAsync());

        public override async Task<IActionResult> GetBeerById(int BrewerId, int beerId)
            => Ok(await _brewerFacade.GetBeerByIdAsync(BrewerId, beerId));

        public override async Task<IActionResult> GetBeersByBrewerId(int BrewerId)
            => Ok(await _brewerFacade.GetBeersByBrewerIdAsync(BrewerId));

        public override async Task<IActionResult> CreateBrewer([FromBody] BrewerDTO newBrewer)
        => Ok(await _brewerFacade.CreateBrewerAsync(newBrewer));

        public override async Task<IActionResult> CreateBeer(int BrewerId, [FromBody] BeerDTO newBeer)
        {
            var createdBeer = await _brewerFacade.CreateBeerAsync(BrewerId, newBeer);

            string? resourceUri =
                Url.Action(nameof(GetBeerById),
                ControllerContext.RouteData.Values["controller"]!.ToString(),
                new { BrewerId = createdBeer.Brewer.Id, beerId = createdBeer.Id}, Request.Scheme);

            return Created(uri: resourceUri!, createdBeer);
        }

        public override async Task<IActionResult> AddSaleToWholesaler(int BrewerId, int beerId, int wholesalerId, [FromBody] int quantity)
            => Ok(await _brewerFacade.AddSaleToWholesalerAsync(BrewerId, beerId, wholesalerId, quantity));

        public override async Task<IActionResult> DeleteBeer(int BrewerId, int beerId)
            => Ok(await _brewerFacade.DeleteBeerAsync(BrewerId, beerId));
    }
}
