using WholesBrew.Business.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Helper;

namespace WholesBrew.Business.Facades.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFacadesConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executingAssembly);
        services.AddServicesConfiguration(configuration);
        services.RegisterAssemblyServices(executingAssembly);

        return services;
    }
}