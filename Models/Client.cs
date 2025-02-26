using ecommerceAPP.Data;

namespace EFpfa.Models
{
    public class Client : Utilisateur
    {

        public Client()
        {
            Type = "Client"; // Automatically set type
        }

        public string Adresse { get; set; }
        public string Telephone { get; set; }

        public ICollection<Commande> Commandes { get; set; }
        public ICollection<Commentaire> Commentaires { get; set; }
    }
}
