
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WholesBrew.Model.Abstractions;
using Helper;

namespace WholesBrew.DataAccess.Contexts;

public partial class WholesBrewSqlServerDbContext : WholesBrewDbContext
{
    public WholesBrewSqlServerDbContext(DbContextOptions options, IConfiguration configuration, IConnectedUser connectedUser)
        : base(options, configuration, connectedUser)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseMsSqlServerProvider(Configuration.GetConnectionString("WholesBrew")!);
    }
}