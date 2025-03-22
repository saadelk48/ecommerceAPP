using ecommerceAPP.Data;
using EFpfa.Models;
using ecommerceAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ecommerceAPP.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly DataContext _context;
        private readonly PasswordHasher<Utilisateur> _passwordHasher = new PasswordHasher<Utilisateur>();

        public UtilisateurController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ModifierProfil()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Login", "Auth");

            var utilisateur = _context.Utilisateurs.FirstOrDefault(u => u.Email == userEmail);
            if (utilisateur == null)
                return RedirectToAction("Login", "Auth");

            var model = new UtilisateurVM
            {
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult ModifierProfil(UtilisateurVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var utilisateur = _context.Utilisateurs.Find(model.Id);
            if (utilisateur == null)
                return NotFound();

            var passwordHasher = new PasswordHasher<Utilisateur>();

            // Vérifier le mot de passe actuel
            if (!string.IsNullOrEmpty(model.MotDePasseActuel))
            {
                var verification = passwordHasher.VerifyHashedPassword(utilisateur, utilisateur.MotDePasse, model.MotDePasseActuel);
                if (verification == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("MotDePasseActuel", "Mot de passe incorrect.");
                    return View(model);
                }

                // Hacher le nouveau mot de passe s'il est fourni
                if (!string.IsNullOrEmpty(model.NouveauMotDePasse))
                {
                    utilisateur.MotDePasse = passwordHasher.HashPassword(utilisateur, model.NouveauMotDePasse);
                }
            }

            utilisateur.Nom = model.Nom;
            utilisateur.Prenom = model.Prenom;
            utilisateur.Email = model.Email;

            _context.Update(utilisateur);
            _context.SaveChanges();

            TempData["Success"] = "Profil mis à jour avec succès.";
            return RedirectToAction("Index", "Layouts");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
