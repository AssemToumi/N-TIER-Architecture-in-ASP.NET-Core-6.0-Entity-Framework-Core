using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Helper;
using WholesBrew.Contracts.Dtos;

namespace WholesBrew.Api.Controllers.V1.Abstractions
{
    [ApiController]
    public abstract class BrewerApiController : ControllerBase
    {
        [HttpGet]
        [Route("/api/v1/brewers")]
        [ProducesResponseType(typeof(List<BrewerDTO>), StatusCodes.Status200OK)]
        public abstract Task<IActionResult> GetAllBrewers();


        [HttpGet]
        [Route("/api/v1/brewers/{BrewerId}/beers/{beerId}")]
        [ValidateModelState]
        [ProducesResponseType(typeof(BeerDTO), 200)]
        public abstract Task<IActionResult> GetBeerById(int BrewerId, [FromRoute][Required] int beerId);


        [HttpGet]
        [Route("/api/v1/brewers/{BrewerId}/beers")]
        [ValidateModelState]
        [ProducesResponseType(typeof(BeerDTO), 200)]
        public abstract Task<IActionResult> GetBeersByBrewerId([FromRoute][Required] int BrewerId);


        [HttpPost]
        [Route("/api/v1/brewers")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> CreateBrewer([FromBody] BrewerDTO newBrewer);


        [HttpPost]
        [Route("/api/v1/brewers/{BrewerId}/beers")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> CreateBeer(int BrewerId, [FromBody] BeerDTO newBeer);


        [HttpPost]
        [Route("/api/v1/brewers/{BrewerId}/beers/{beerId}/wholesalers/{wholesalerId}/sales")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> AddSaleToWholesaler(int BrewerId, int beerId, int wholesalerId, [FromBody] int quantity);


        [HttpDelete]
        [Route("api/v1/brewers/{BrewerId}/beers/{beerId}")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> DeleteBeer(int BrewerId, int beerId);
    }
}