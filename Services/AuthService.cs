using ecommerceAPP.Interfaces;

using EFpfa.Models;

namespace ecommerceAPP.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        public AuthService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public Utilisateur Authenticate(string email, string password)
        {
            return _utilisateurRepository.GetByEmailAndPassword(email, password);
        }

        public string GetUserRole(Utilisateur user)
        {
            return user?.Type; // Assuming `Type` is a property indicating role (Admin/Client)
        }
    }
}
