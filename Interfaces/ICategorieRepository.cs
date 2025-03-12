using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> GetAll();
        Categorie GetById(int id);
        void Add(Categorie categorie);
        void Update(Categorie categorie);
        void Delete(int id);
    }
}
