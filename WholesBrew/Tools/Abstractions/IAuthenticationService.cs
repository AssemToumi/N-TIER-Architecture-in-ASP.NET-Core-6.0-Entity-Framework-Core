
namespace Helper
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}
