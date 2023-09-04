
using WholesBrew.Business.Facades.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Helper;

namespace WholesBrew.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog(configuration)
            .AddFacadesConfiguration(configuration);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
            .AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        services.AddSingleton<IAuthenticationService>(new LdapAuthenticationService("wholesbrew.local", null));

        return services;
    }
}

