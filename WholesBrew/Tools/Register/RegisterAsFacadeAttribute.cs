using Microsoft.Extensions.DependencyInjection;

namespace Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAsFacadeAttribute : RegisterAttribute
    {
        public RegisterAsFacadeAttribute()
        {
        }

        public RegisterAsFacadeAttribute(ServiceLifetime serviceLifetime)
            : base(serviceLifetime)
        {
        }
    }
}
