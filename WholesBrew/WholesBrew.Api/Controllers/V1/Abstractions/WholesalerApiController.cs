using Microsoft.AspNetCore.Mvc;
using Helper;
using WholesBrew.Contracts.Dtos;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WholesBrew.Model.Entities;

namespace WholesBrew.Api.Controllers.V1.Abstractions
{
    [ApiController]
    public abstract class WholesalerApiController : ControllerBase
    {
        [HttpGet]
        [Route("/api/v1/wholesalers")]
        [ProducesResponseType(typeof(List<WholesalerDTO>), StatusCodes.Status200OK)]
        public abstract Task<IActionResult> GetAllWholesalers();


        [HttpPost]
        [Route("/api/v1/wholesalers")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> CreateWholesaler([FromBody] WholesalerDTO newWholesaler);


        [HttpPost]
        [Route("/api/v1/wholesalers/{wholesalerId}/restrictions")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(typeof(RestrictionEntity), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Message), StatusCodes.Status400BadRequest)]
        public abstract Task<IActionResult> CreateRestrictionAsync(int wholesalerId, int beerId, [FromBody] int MaxQuantity);


        [HttpPost]
        [Route("/api/v1/wholesalers/{wholesalerId}/quote")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(typeof(QuoteRequestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Message), StatusCodes.Status400BadRequest)]
        public abstract Task<IActionResult> RequestQuote(int wholesalerId, [FromBody] QuoteRequestDTO request);


        [HttpPut]
        [Route("/api/v1/wholesalers/{wholesalerId}/beers/{beerId}/update-quantity")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public abstract Task<IActionResult> UpdateBeerQuantity(int wholesalerId, int beerId, [FromBody] int NewQuantity);
    }
}