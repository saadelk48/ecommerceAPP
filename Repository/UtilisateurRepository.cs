using ecommerceAPP.Data;
using ecommerceAPP.Interfaces;


using EFpfa.Models;

namespace ecommerceAPP.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        public UtilisateurRepository(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;
        public Utilisateur GetByEmailAndPassword(string email, string password)
        {
            return _context.Utilisateurs
                .FirstOrDefault(u => u.Email == email && u.MotDePasse == password);
        }

        public Utilisateur GetByID(int id)
        {
            return _context.Utilisateurs.Find(id);
        }
        public Utilisateur GetByEmail(string email) // ✅ New method to check for duplicate emails
        {
            return _context.Utilisateurs.FirstOrDefault(u => u.Email == email);
        }
        public void Add(Utilisateur user)
        {
            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
        }
    }
}
