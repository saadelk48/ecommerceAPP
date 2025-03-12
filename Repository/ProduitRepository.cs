using ecommerceAPP.Data;
using ecommerceAPP.Interfaces;
using EFpfa.Models;

namespace ecommerceAPP.Repository
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly DataContext _context;

        public ProduitRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Produit> GetAll()
        {
            return _context.Produits.ToList();
        }

        public Produit GetById(int id)
        {
            return _context.Produits.Find(id);
        }

        public void Add(Produit produit)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
        }

        public void Update(Produit produit)
        {
            _context.Produits.Update(produit);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                _context.SaveChanges();
            }
        }
    }
}
