using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace Helper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLayers(this IServiceCollection services, params string[] layersName)
        {
            if (layersName.Length == 0)
            {
                throw new ArgumentException("At least one layer name is required!", "layersName");
            }

            foreach (string assemblyString in layersName)
            {
                AppDomain.CurrentDomain.Load(assemblyString);
            }

            return services;
        }

        public static IServiceCollection RegisterAssemblyServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            IServiceCollection services2 = services;
            foreach (Type type in GetServiceTypesToRegister(assemblies))
            {
                List<Type> list = type.GetInterfaces().ToList();
                ServiceLifetime serviceLifeTime = ((RegisterAttribute)type.GetCustomAttribute(typeof(RegisterAttribute))).ServiceLifetime;
                if (list != null && list.Count < 1 && serviceLifeTime != 0)
                {
                    throw new InvalidAttributeUsageException("Service type : <" + type.FullName + "> has to be registered as singleton!");
                }

                if (list.Count == 0)
                {
                    services2.Add(new ServiceDescriptor(type, Activator.CreateInstance(type) ?? throw new ArgumentNullException("type")));
                    continue;
                }

                list.ForEach(delegate (Type iType)
                {
                    services2.Add(new ServiceDescriptor(iType, type, serviceLifeTime));
                });
            }

            return services2;
        }

        private static IEnumerable<Type> GetServiceTypesToRegister(IEnumerable<Assembly> assemblies)
        {
            List<Assembly> list = assemblies.ToList();
            List<Type> list2;
            if (list.Any())
            {
                list2 = new List<Type>();
                foreach (Assembly item in list)
                {
                    list2.AddRange(item.GetMembersWithAttributeOfType<RegisterAsComponentAttribute>());
                    list2.AddRange(item.GetMembersWithAttributeOfType<RegisterAsRepositoryAttribute>());
                    list2.AddRange(item.GetMembersWithAttributeOfType<RegisterAsServiceAttribute>());
                    list2.AddRange(item.GetMembersWithAttributeOfType<RegisterAsFacadeAttribute>());
                }
            }
            else
            {
                list2 = AppDomain.CurrentDomain.GetAssemblies().SelectMany((assembly) => assembly.GetMembersWithAttributeOfType<RegisterAsServiceAttribute>()).ToList();
            }

            return list2;
        }

        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
            return services.AddLogging(delegate (ILoggingBuilder loggingBuilder)
            {
                loggingBuilder.AddSerilog();
            });
        }
    }
}
