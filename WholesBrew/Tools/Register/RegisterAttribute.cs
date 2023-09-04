using Microsoft.Extensions.DependencyInjection;

namespace Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class RegisterAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; init; }

        internal RegisterAttribute()
            : this(ServiceLifetime.Scoped)
        {
        }

        internal RegisterAttribute(ServiceLifetime serviceLifeTime)
        {
            ServiceLifetime = serviceLifeTime;
        }
    }
}
