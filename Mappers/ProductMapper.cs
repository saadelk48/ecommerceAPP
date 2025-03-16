using ecommerceAPP.Interfaces;
using ecommerceAPP.ViewModels;
using EFpfa.Models;

namespace ecommerceAPP.Mappers
{
    public class ProductMapper:IProductMapper
    {
        public ProductVM MapToViewModel(Produit produit)
        {
            if (produit == null) return null;

            return new ProductVM
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                StockQuantites = produit.StockQuantites,
                CategorieId = produit.CategorieId,
                ImagePath = produit.ImagePath
            };
        }

        public Produit MapToEntity(ProductVM productVM)
        {
            if (productVM == null) return null;

            return new Produit
            {
                Id = productVM.Id,
                Nom = productVM.Nom,
                Description = productVM.Description,
                Prix = productVM.Prix,
                StockQuantites = productVM.StockQuantites,
                CategorieId = productVM.CategorieId,
                ImagePath = productVM.ImagePath
            };
        }

        public List<ProductVM> MapToViewModelList(IEnumerable<Produit> produits)
        {
            return produits?.Select(MapToViewModel).ToList();
        }
    }
}
