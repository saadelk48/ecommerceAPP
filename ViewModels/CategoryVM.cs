using System.ComponentModel.DataAnnotations;

namespace ecommerceAPP.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la catégorie est requis")]
        public string Nom { get; set; }

    }
}
