using System.Reflection;
using System.Runtime.CompilerServices;

namespace Helper
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetMembersWithAttributeOfType<TAttributeType>(this Assembly assembly)
        {
            return (from t in assembly.GetTypes()
                    where t.IsDefined(typeof(TAttributeType), inherit: false) && t.GetTypeInfo().IsClass && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
                    select t).ToList();
        }
    }
}
