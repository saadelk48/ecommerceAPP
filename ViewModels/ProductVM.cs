using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ecommerceAPP.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du produit est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La description est requise.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le prix est requis.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0.")]
        public double Prix { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer la quantité en stock.")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif.")]
        public int StockQuantites { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une catégorie.")]
        public int CategorieId { get; set; }

        [BindNever] // Prevent validation issues
        public string CategorieNom { get; set; }

        [BindNever] // Prevent validation issues
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une image.")]
        public IFormFile Image { get; set; }
    }
}
