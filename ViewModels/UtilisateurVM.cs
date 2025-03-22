using System.ComponentModel.DataAnnotations;

namespace ecommerceAPP.ViewModels
{
    public class UtilisateurVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "Format d'email invalide.")]
        public string Email { get; set; }

        public string MotDePasseActuel { get; set; }

        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
        public string NouveauMotDePasse { get; set; }

        [Compare("NouveauMotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmerMotDePasse { get; set; }

    }
}
