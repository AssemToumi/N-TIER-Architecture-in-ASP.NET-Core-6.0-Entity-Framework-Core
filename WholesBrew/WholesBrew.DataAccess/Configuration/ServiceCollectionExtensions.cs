using WholesBrew.DataAccess.Contexts;
using WholesBrew.Model.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Helper;

namespace WholesBrew.DataAccess.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddModelsConfiguration();
        services.RegisterDataAccessOptions(configuration);
        services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

        var provider = configuration.GetSection("DatabaseSettings").GetValue<Providers>("Provider");

        switch (provider)
        {
            case Providers.Oracle:
                services.AddDbContext<WholesBrewDbContext, WholesBrewOracleDbContext>();
                break;
            case Providers.MsSqlServer:
                services.AddDbContext<WholesBrewDbContext, WholesBrewSqlServerDbContext>();
                break;
            case Providers.InMemory:
                services.AddDbContext<WholesBrewDbContext, WholesBrewInMemoryDbContext>();
                break;
            default:
                throw new NotImplementedException($"Provider <{provider}> is not supported!");
        }

        return services;
    }

    private static IServiceCollection RegisterDataAccessOptions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<OracleSettings>(opts =>
            configuration.GetSection("DatabaseSettings:OracleSettings").Bind(opts));

        return services;
    }
}
