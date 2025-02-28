using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
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
        public Utilisateur GetByEmail(string email)
        {
            return _utilisateurRepository.GetByEmail(email);
        }

        public Utilisateur RegisterUser(RegisterVM vm)
        {
            var newUser = new Client // Always create a Client
            {
                Nom = vm.Nom,
                Prenom = vm.Prenom,
                Email = vm.Email,
                MotDePasse = vm.MotDePasse, // Should be hashed before storing
                Type = "Client"
            };

            _utilisateurRepository.Add(newUser);
            return newUser;
        }
    }
}
