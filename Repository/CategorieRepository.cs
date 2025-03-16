using ecommerceAPP.Data;
using ecommerceAPP.Interfaces;
using EFpfa.Models;

namespace ecommerceAPP.Repository
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly DataContext _context;

        public CategorieRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Categorie> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categorie GetById(int id)
        {
            return _context.Categories.Find(id);
        }
        public void Add(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            _context.SaveChanges();
        }
        public void Update(Categorie categorie)
        {
            _context.Categories.Update(categorie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categorie = _context.Categories.Find(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
                _context.SaveChanges();
            }
        }
    }
}
