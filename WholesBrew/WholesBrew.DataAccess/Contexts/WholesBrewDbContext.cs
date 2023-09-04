using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using WholesBrew.Model.Abstractions;
using WholesBrew.Model.Entities;

namespace WholesBrew.DataAccess.Contexts;

public abstract class WholesBrewDbContext : DbContext
{
    private readonly IConnectedUser _connectedUser;

    protected readonly IConfiguration Configuration;

    protected WholesBrewDbContext(IConfiguration configuration, IConnectedUser connectedUser)
    {
        _connectedUser = connectedUser;
        Configuration = configuration;
    }

    protected WholesBrewDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options)
    {
        _connectedUser = connectedUser;
        Configuration = configuration;
    }

    protected WholesBrewDbContext(DbContextOptions<WholesBrewDbContext> options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options)
    {
        _connectedUser = connectedUser;
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        List<EntityEntry<AbstractWholesBrewBaseEntity>> entries = ChangeTracker.Entries<AbstractWholesBrewBaseEntity>().ToList();

        entries.ForEach(e =>
        {
            if (e.State == EntityState.Added)
            {
                e.Entity.CreatorId = _connectedUser.Id;
                e.Entity.CreatorId = 1;
                e.Entity.CreationDate = DateTime.UtcNow;
                e.Entity.RowVersion = 1;
            }
            else if (e.State == EntityState.Modified)
            {
                e.Property(p => p.CreatorId).IsModified = false;
                e.Property(p => p.CreationDate).IsModified = false;
                e.Property(p => p.RowVersion).CurrentValue++;
            }

            e.Entity.ModificatorId = _connectedUser.Id;
            e.Entity.ModificatorId = 1;
            e.Entity.ModificationDate = DateTime.Now;
        });

        return await base.SaveChangesAsync(cancellationToken);
    }

    #region DbSets
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<BrewerEntity> Brewers { get; set; } = null!;
    public DbSet<BeerEntity> Beers { get; set; } = null!;
    public DbSet<WholesalerEntity> Wholesalers { get; set; } = null!;
    public DbSet<WholesalerStockEntity> WholesalerStock { get; set; } = null!;
    public DbSet<RestrictionEntity> Restriction { get; set; } = null!;
    public DbSet<SaleEntity> Sale { get; set; } = null!;
    
    #endregion
}