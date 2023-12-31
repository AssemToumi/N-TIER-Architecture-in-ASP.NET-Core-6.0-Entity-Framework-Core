﻿using Helper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WholesBrew.Model.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModelsConfiguration(this IServiceCollection services)
    {
        services.RegisterAssemblyServices(Assembly.GetExecutingAssembly());

        return services;
    }
}
