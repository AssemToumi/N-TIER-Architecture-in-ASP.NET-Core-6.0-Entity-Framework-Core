using WholesBrew.DataAccess.Configuration;
using WholesBrew.Model.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Helper;

namespace WholesBrew.DataAccess.Contexts;

public class WholesBrewOracleDbContext : WholesBrewDbContext
{
    private readonly OracleSettings _oracleOptions;

    public WholesBrewOracleDbContext(DbContextOptions options, IConfiguration configuration, IOptions<OracleSettings> oracleOptions, IConnectedUser connectedUser)
        : base(options, configuration, connectedUser)
        => _oracleOptions = oracleOptions.Value;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseOracleProvider(Configuration.GetConnectionString("WholesBrew")!,
            _oracleOptions.SqlCompatibilityVersion);
    }
}