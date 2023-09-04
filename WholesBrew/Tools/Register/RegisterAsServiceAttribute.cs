using Microsoft.Extensions.DependencyInjection;

namespace Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAsServiceAttribute : RegisterAttribute
    {
        public RegisterAsServiceAttribute()
        {
        }

        public RegisterAsServiceAttribute(ServiceLifetime serviceLifetime)
            : base(serviceLifetime)
        {
        }
    }
}
