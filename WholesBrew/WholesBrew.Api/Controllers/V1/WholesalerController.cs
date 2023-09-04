using Microsoft.AspNetCore.Mvc;
using WholesBrew.Api.Controllers.V1.Abstractions;
using WholesBrew.Business.Facades.Abstractions;
using WholesBrew.Contracts.Dtos;

public class WholesalerController : WholesalerApiController
{
    private readonly IWholesalerFacade _wholesalerFacade;

    public WholesalerController(IWholesalerFacade wholesalerFacade)
        => _wholesalerFacade = wholesalerFacade;

    public override async Task<IActionResult> GetAllWholesalers()
    => Ok(await _wholesalerFacade.GetAllWholesalersAsync());

    public override async Task<IActionResult> CreateWholesaler([FromBody] WholesalerDTO newWholesaler)
     => Ok(await _wholesalerFacade.CreateWholesalerAsync(newWholesaler));

    public override async Task<IActionResult> CreateRestrictionAsync(int wholesalerId, int beerId, [FromBody] int maxQuantity)
    => Ok(await _wholesalerFacade.CreateRestrictionAsync(wholesalerId, beerId, maxQuantity));

    public override async Task<IActionResult> RequestQuote(int wholesalerId, [FromBody] QuoteRequestDTO quote)
        => Ok(await _wholesalerFacade.RequestQuoteAsync(wholesalerId, quote));

    public override async Task<IActionResult> UpdateBeerQuantity(int wholesalerId, int beerId, [FromBody] int newQuantity)
        => Ok(await _wholesalerFacade.UpdateBeerQuantityAsync(wholesalerId, beerId, newQuantity));
}