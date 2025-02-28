using System.ComponentModel.DataAnnotations;

namespace ecommerceAPP.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Le prénom est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le nom de famille est requis")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "L'adresse e-mail est requise")]
        [EmailAddress(ErrorMessage = "Format d'e-mail invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer votre mot de passe")]
        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
