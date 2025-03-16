using ecommerceAPP.ViewModels;
using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface IAuthService
    {
        Utilisateur GetByEmail(string email);
        Utilisateur Authenticate(string email, string password);
        string GetUserRole(Utilisateur user);
        Utilisateur RegisterUser(RegisterVM vm);
    }
}
