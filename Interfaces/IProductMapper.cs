using ecommerceAPP.ViewModels;
using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface IProductMapper
    {
        ProductVM MapToViewModel(Produit produit);
        Produit MapToEntity(ProductVM productVM);
        List<ProductVM> MapToViewModelList(IEnumerable<Produit> produits);
    }
}
