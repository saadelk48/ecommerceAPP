using ecommerceAPP.Data;
using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
using EFpfa.Models;
using Microsoft.AspNetCore.Identity;

namespace ecommerceAPP.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUtilisateurRepository _utilisateurRepository;
		private readonly PasswordHasher<Utilisateur> _passwordHasher = new PasswordHasher<Utilisateur>();

		public AuthService(IUtilisateurRepository utilisateurRepository)
		{
			_utilisateurRepository = utilisateurRepository;
		}

		public Utilisateur Authenticate(string email, string password)
		{
			//return _utilisateurRepository.GetByEmailAndPassword(email, password);

			var utilisateur = _utilisateurRepository.GetByEmail(email);

			if (utilisateur != null)
			{
				var verification = _passwordHasher.VerifyHashedPassword(utilisateur, utilisateur.MotDePasse, password);

				if (verification == PasswordVerificationResult.Success)
				{
					return utilisateur;
				}
			}

			return null;
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
				MotDePasse = _passwordHasher.HashPassword(null, vm.MotDePasse), // Hachage du mot de passe
				Type = "Client"
			};

			_utilisateurRepository.Add(newUser);
			return newUser;
		}
	}
}
