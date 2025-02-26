namespace EFpfa.Models
{
    public class Commande
    {
        public int Id { get; set; }

        public int IdClient { get; set; }
        public Client Client { get; set; }

        public double MontantTotal { get; set; }
        public DateTime DateCommande { get; set; }

        public string Status { get; set; } // Enum: Pending, Confirmed, Shipped, Delivered, Cancelled

        public ICollection<LigneCommande> LigneCommandes { get; set; }
        public ICollection<Livraison> Livraisons { get; set; }
        public ICollection<Paiement> Paiements { get; set; }
    }
}
