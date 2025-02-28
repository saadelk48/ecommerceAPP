using EFpfa.Models;

namespace ecommerceAPP.Interfaces
{
    public interface IUtilisateurRepository
    {
        Utilisateur GetByID(int id);
        Utilisateur GetByEmailAndPassword(string email, string password);
        Utilisateur GetByEmail(string email);
        void Add(Utilisateur user);
    }
}
