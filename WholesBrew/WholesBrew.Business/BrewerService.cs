using Helper;
using WholesBrew.Business.Abstractions;
using WholesBrew.DataAccess.Abstractions;
using WholesBrew.Model.Entities;

namespace WholesBrew.Business;

[RegisterAsService]
public class BrewerService : AbstractService, IBrewerService
{
    public BrewerService(IWholesBrewUnitOfWork wholesBrewUnitOfWork)
        : base(wholesBrewUnitOfWork)
    {
    }

    public async Task<IEnumerable<BrewerEntity>> GetAllBrewersAsync()
    {
        return await WholesBrewUnitOfWork.BrewerRepository.GetAllAsync();
    }

    public async Task<BeerEntity> GetBeerByIdAsync(int BrewerId, int beerId)
    {
        BeerEntity beer = await WholesBrewUnitOfWork.BeerRepository.GetByIdAsync(beerId);

        // Check if the beer belongs to the specified Brewer
        if (beer.BrewerId != BrewerId)
        {
            // Beer does not belong to the specified Brewer, you can throw an exception or return null
            throw new InvalidOperationException($"Beer with ID {beerId} does not belong to Brewer with ID {BrewerId}.");
        }

        return beer;
    }

    public async Task<IEnumerable<BeerEntity>> GetBeersByBrewerIdAsync(int BrewerId)
    {
        return await WholesBrewUnitOfWork.BeerRepository.FindAsync(b => b.BrewerId == BrewerId);
    }

    public async Task<SaleEntity> AddSaleToWholesalerAsync(int BrewerId, int beerId, int wholesalerId, int quantity)
    {
        // Recherchez le grossiste par son ID.
        WholesalerEntity wholesaler = await WholesBrewUnitOfWork.WholesalerRepository.GetByIdAsync(wholesalerId);

        if (wholesaler == null)
        {
            throw new InvalidOperationException("Le grossiste spécifié n'existe pas.");
        }

        // Recherchez la bière par son ID.
        BeerEntity beer = await WholesBrewUnitOfWork.BeerRepository.GetByIdAsync(beerId);

        if (beer == null)
        {
            throw new InvalidOperationException("La bière spécifiée n'existe pas.");
        }

        //Check if the beer belongs to the specified Brewer
        if (beer.BrewerId != BrewerId)
        {
            // Beer does not belong to the specified Brewer, you can throw an exception or return null
            throw new InvalidOperationException($"Beer with ID {beerId} does not belong to Brewer with ID {BrewerId}.");
        }

        RestrictionEntity? restriction = await WholesBrewUnitOfWork.RestrictionRepository.FirstOrDefaultAsync(c => c.WholesalerId == wholesalerId && c.BeerId == beerId);

        if (restriction == null)
        {
            throw new InvalidOperationException($"Wholesaler with ID {wholesalerId} cannot sell Beer with ID {beerId}.");
        }

        if (quantity > restriction.MaxQuantity)
        {
            throw new InvalidOperationException($"Wholesaler with ID {wholesalerId} cannot sell more than {restriction.MaxQuantity} Beer with ID {beerId}.");
        }

        WholesalerStockEntity? wholesalerStockEntity = await WholesBrewUnitOfWork.WholesalerStockRepository.FirstOrDefaultAsync(c => c.WholesalerId == wholesalerId && c.BeerId == beerId);

        if (wholesalerStockEntity == null)
        {
            throw new InvalidOperationException("La bière spécifiée n'existe pas dans le stock du grossiste.");
        }

        // Vérifiez si le grossiste a suffisamment de stock pour la vente.
        if (quantity > wholesalerStockEntity.Quantity)
        {
            throw new InvalidOperationException("Stock insuffisant pour la vente.");
        }

        // Mettez à jour le stock du grossiste.
        wholesalerStockEntity.Quantity -= quantity;

        // Créez une nouvelle vente.
        SaleEntity sale = new SaleEntity
        {
            WholesalerId = wholesalerId,
            BeerId = beerId,
            Quantity = quantity,
        };

        // Ajoutez la vente à la base de données.
        await WholesBrewUnitOfWork.SaleRepository.AddAsync(sale);
        await WholesBrewUnitOfWork.SaveChangesAsync();
        
        // Vous pouvez retourner une réponse OK avec des détails sur la vente, si nécessaire.
        return sale;
    }

    public async Task<BrewerEntity> CreateBrewerAsync(BrewerEntity newBrewer)
    {
        if (newBrewer == null)
        {
            throw new ArgumentNullException(nameof(newBrewer));
        }
        // Add the new Brewer to the database
        await WholesBrewUnitOfWork.BrewerRepository.AddAsync(newBrewer);
        await WholesBrewUnitOfWork.SaveChangesAsync(); // Save changes to the database

        return newBrewer;
    }

    public async Task<BeerEntity> CreateBeerAsync(int BrewerId, BeerEntity newBeer)
    {
        if (newBeer == null)
        {
            throw new ArgumentNullException(nameof(newBeer));
        }

        // Get the Brewer 
        BrewerEntity Brewer = await WholesBrewUnitOfWork.BrewerRepository.GetByIdAsync(BrewerId);

        if (Brewer == null)
        {
            // Brewer not found, you can throw an exception or return null
            throw new InvalidOperationException($"Brewer with ID {BrewerId} not found.");
        }

        newBeer.BrewerId = Brewer.Id;
        
        // Add the new Beer to the database
        await WholesBrewUnitOfWork.BeerRepository.AddAsync(newBeer);
        await WholesBrewUnitOfWork.SaveChangesAsync(); // Save changes to the database

        return newBeer;
    }

    public async Task<BeerEntity> DeleteBeerAsync(int BrewerId, int beerId)
    {
        // Get the beer to be deleted
        BeerEntity beerToDelete = await WholesBrewUnitOfWork.BeerRepository.GetByIdAsync(beerId);

        if (beerToDelete == null)
        {
            // Beer not found, you can throw an exception or return null
            throw new InvalidOperationException($"Beer with ID {beerId} not found.");
        }

        // Check if the beer belongs to the specified Brewer
        if (beerToDelete.BrewerId != BrewerId)
        {
            // Beer does not belong to the specified Brewer, you can throw an exception or return null
            throw new InvalidOperationException($"Beer with ID {beerId} does not belong to Brewer with ID {BrewerId}.");
        }

        // Remove the beer from the repository
        await WholesBrewUnitOfWork.BeerRepository.DeleteByIdAsync(beerId);
        await WholesBrewUnitOfWork.SaveChangesAsync(); // Save changes to the database

        return beerToDelete;
    }
}
