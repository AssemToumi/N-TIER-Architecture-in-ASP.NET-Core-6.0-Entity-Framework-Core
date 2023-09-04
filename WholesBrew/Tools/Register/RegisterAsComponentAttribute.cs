using Microsoft.Extensions.DependencyInjection;

namespace Helper
{
    public class RegisterAsComponentAttribute : RegisterAttribute
    {
        public RegisterAsComponentAttribute()
        {
        }

        public RegisterAsComponentAttribute(ServiceLifetime serviceLifetime)
            : base(serviceLifetime)
        {
        }
    }
}
