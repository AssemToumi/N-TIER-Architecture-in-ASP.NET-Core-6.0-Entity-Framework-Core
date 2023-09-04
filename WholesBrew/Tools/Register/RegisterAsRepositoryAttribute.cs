using Microsoft.Extensions.DependencyInjection;
namespace Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAsRepositoryAttribute : RegisterAttribute
    {
        public RegisterAsRepositoryAttribute()
        {
        }

        public RegisterAsRepositoryAttribute(ServiceLifetime serviceLifetime)
            : base(serviceLifetime)
        {
        }
    }
}
