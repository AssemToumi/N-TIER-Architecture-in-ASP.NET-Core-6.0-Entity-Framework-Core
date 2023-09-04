using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.DataAccess.Contexts;

public class WholesBrewInMemoryDbContext : WholesBrewDbContext
{
    public WholesBrewInMemoryDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options, configuration, connectedUser)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseInMemoryDatabase("WholesBrew");
    }
}