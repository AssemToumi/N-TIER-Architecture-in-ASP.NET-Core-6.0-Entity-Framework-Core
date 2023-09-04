using Helper;
using WholesBrew.Business.Abstractions;
using WholesBrew.DataAccess.Abstractions;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business;

[RegisterAsService]
public class WholesalerService : AbstractService, IWholesalerService
{
    public WholesalerService(IWholesBrewUnitOfWork wholesBrewUnitOfWork)
        : base(wholesBrewUnitOfWork)
    {
    }

    public async Task<IEnumerable<WholesalerStockEntity>> GetAllWholesalersAsync() 
        => await WholesBrewUnitOfWork.WholesalerStockRepository.GetAllAsync();

    public async Task<WholesalerEntity> CreateWholesalerAsync(WholesalerEntity newWholesaler)
    {
        if (newWholesaler == null)
        {
            throw new ArgumentNullException(nameof(newWholesaler));
        }
        // Add the new Wholesaler to the database
        await WholesBrewUnitOfWork.WholesalerRepository.AddAsync(newWholesaler);
        await WholesBrewUnitOfWork.SaveChangesAsync(); // Save changes to the database

        return newWholesaler;
    }

    public async Task<RestrictionEntity> CreateRestrictionAsync(int wholesalerId, int beerId, int maxQuantity)
    {
        // Check if the beer & wholesaler exists
        await EnsureBeerAndWholesalerExistAsync(beerId, wholesalerId);

        RestrictionEntity? restrictionEntity = await WholesBrewUnitOfWork.RestrictionRepository.FirstOrDefaultAsync(
           itm => itm.WholesalerId == wholesalerId && itm.BeerId == beerId);

        if (restrictionEntity is not null)
        {
            restrictionEntity.MaxQuantity = maxQuantity;
        }
        else
        {
            restrictionEntity = new RestrictionEntity
            {
                WholesalerId = wholesalerId,
                BeerId = beerId,
                MaxQuantity = maxQuantity
            };
        }

        await WholesBrewUnitOfWork.RestrictionRepository.AddAsync(restrictionEntity);
        await WholesBrewUnitOfWork.SaveChangesAsync();

        return restrictionEntity;
    }

    public async Task<QuoteResponseEntity> RequestQuoteAsync(int wholesalerId, QuoteRequestEntity quoteRequest)
    {
        WholesalerEntity? wholesaler = await WholesBrewUnitOfWork.WholesalerRepository.GetByIdAsync(wholesalerId);
        if (wholesaler is null)
        {
            throw new InvalidOperationException($"Wholesaler with id {wholesalerId} not found");
        }

        if (quoteRequest.OrderBeers == null || quoteRequest.OrderBeers.Count == 0)
        {
            throw new InvalidOperationException("The order cannot be empty");
        }

        var containsDuplicates = quoteRequest.OrderBeers.GroupBy(b => b.Id).Any(g => g.Count() > 1);
        if (containsDuplicates)
        {
            throw new InvalidOperationException("There can't be any duplicate in the order");
        }

        var quoteResponse = new QuoteResponseEntity
        {
            WholesalerId = wholesalerId,
            OrderResponses = await GetQuotationAsync(wholesalerId, quoteRequest.OrderBeers),
        };

        if (quoteResponse.OrderResponses is null)
        {
            throw new InvalidOperationException("Something went wrong, returned null quoteResponse");
        }

        quoteResponse.Summary = $"Quotation generated for {quoteResponse.OrderResponses.Count} beers";

        return quoteResponse;
    }

    private async Task<List<OrderResponseEntity>> GetQuotationAsync(int wholesalerId, List<BeerEntity> orderBeers)
    {
        List<OrderResponseEntity> orderResponses = new List<OrderResponseEntity>();

        foreach (var beer in orderBeers)
        {
            IEnumerable<WholesalerStockEntity> query = await WholesBrewUnitOfWork.WholesalerStockRepository.FindAsync(b => b.BeerId == beer.Id
                                                                                            && b.WholesalerId == wholesalerId
                                                                                            && beer.Quantity <= b.Quantity); //The number of beers ordered cannot be greater than the wholesaler's stock

            if (query != null && query.Any())
            {
                WholesalerStockEntity? wholesalerStock = query.FirstOrDefault();

                if (wholesalerStock != null)
                {
                    var discount = (beer.Quantity > 20) ? 20 : (beer.Quantity > 10) ? 10 : 0;
                    var originalPrice = beer.Quantity * wholesalerStock.Price;
                    var priceAfterDiscount = originalPrice;

                    if (discount != 0)
                    {
                        var discountAmount = originalPrice * (discount / 100.0m);
                        priceAfterDiscount = originalPrice - discountAmount;
                    }

                    orderResponses.Add(new OrderResponseEntity()
                    {
                        BeerId = wholesalerStock.BeerId,
                        Quantity = beer.Quantity,
                        Label = "Beer is Available",
                        UnitPrice = wholesalerStock.Price,
                        Discount = $"{discount} % applied above {beer.Quantity} drinks",
                        TotalBeforeDiscount = originalPrice,
                        TotalAfterDiscount = priceAfterDiscount
                    });
                }
            }
            else
            {
                orderResponses.Add(new OrderResponseEntity()
                {
                    BeerId = beer.Id,
                    Label = "Beer not available in stock",
                    Discount = "N/A"
                });
            }
        }

        return orderResponses;
    }

    public async Task<WholesalerStockEntity> UpdateBeerQuantityAsync(int wholesalerId, int beerId, int newQuantity)
    {
        WholesalerStockEntity? wholesalerStockEntity = await WholesBrewUnitOfWork.WholesalerStockRepository.FirstOrDefaultAsync(
           itm => itm.WholesalerId == wholesalerId && itm.BeerId == beerId);

        if (wholesalerStockEntity is not null)
        {
            wholesalerStockEntity.Quantity += newQuantity;
        }
        else
        {
            // Check if the beer & wholesaler exists
            await EnsureBeerAndWholesalerExistAsync(beerId, wholesalerId);

            wholesalerStockEntity = new WholesalerStockEntity()
            {
                BeerId = beerId,
                WholesalerId = wholesalerId,
                Quantity = newQuantity
            };

            // Add the new stock item to the repository.
            await WholesBrewUnitOfWork.WholesalerStockRepository.AddAsync(wholesalerStockEntity);
        }

        // Update the database with the changes.
        await WholesBrewUnitOfWork.SaveChangesAsync();

        return wholesalerStockEntity;
    }

    private async Task EnsureBeerAndWholesalerExistAsync(int beerId, int wholesalerId)
    {
        BeerEntity beer = await WholesBrewUnitOfWork.BeerRepository.GetByIdAsync(beerId);
        if (beer == null)
        {
            throw new InvalidOperationException($"Beer with ID {beerId} not found.");
        }

        WholesalerEntity wholesaler = await WholesBrewUnitOfWork.WholesalerRepository.GetByIdAsync(wholesalerId);
        if (wholesaler == null)
        {
            throw new InvalidOperationException($"Wholesaler with ID {wholesalerId} not found.");
        }
    }
}
