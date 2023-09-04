
using Microsoft.Extensions.DependencyInjection;
using Helper;
using WholesBrew.DataAccess.Abstractions;
using WholesBrew.DataAccess.Abstractions.Repositories;
using WholesBrew.DataAccess.Contexts;
using WholesBrew.DataAccess.Repositories;

namespace WholesBrew.DataAccess;

[RegisterAsService(ServiceLifetime.Scoped)]
public class WholesBrewUnitOfWork : IWholesBrewUnitOfWork, IDisposable
{
    private readonly WholesBrewDbContext _medbacDbContext;
    private bool _disposed;
    
    public WholesBrewUnitOfWork(WholesBrewDbContext medbacDbContext, IServiceProvider serviceProvider)
    {
        _medbacDbContext = medbacDbContext;

        BrewerRepository = serviceProvider.GetRequiredService<IBrewerRepository>();
        BeerRepository = serviceProvider.GetRequiredService<IBeerRepository>();
        WholesalerRepository = serviceProvider.GetRequiredService<IWholesalerRepository>();
        WholesalerStockRepository = serviceProvider.GetRequiredService<IWholesalerStockRepository>();
        RestrictionRepository = serviceProvider.GetRequiredService<IRestrictionRepository>();
        SaleRepository = serviceProvider.GetRequiredService<ISaleRepository>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public IBrewerRepository BrewerRepository { get; }
    public IBeerRepository BeerRepository { get; }
    public IWholesalerRepository WholesalerRepository { get; }
    public IWholesalerStockRepository WholesalerStockRepository { get; }
    public IRestrictionRepository RestrictionRepository { get; }
    public ISaleRepository SaleRepository { get; }

    public async Task<int> SaveChangesAsync()
        => await _medbacDbContext.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _medbacDbContext.Dispose();
            }
        }

        _disposed = true;
    }
    
}
