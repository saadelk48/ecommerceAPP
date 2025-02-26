using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface IAuthService
    {
        Utilisateur Authenticate(string email, string password);
        string GetUserRole(Utilisateur user);
    }
}
