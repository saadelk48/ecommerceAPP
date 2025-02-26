using ecommerceAPP.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFpfa.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        [Column("Type")]  // This column will store "Admin" or "Client" in the DB
        public string Type { get; set; }

    }
}
