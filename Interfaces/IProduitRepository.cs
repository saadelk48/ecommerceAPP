using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> GetAll();
        Produit GetById(int id);
        void Add(Produit produit);
        void Update(Produit produit);
        void Delete(int id);
    }
}
