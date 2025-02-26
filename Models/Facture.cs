namespace EFpfa.Models
{
    public class Facture
    {
        public int Id { get; set; }

        public int IdCommande { get; set; }
        public Commande Commande { get; set; }

        public int IdClient { get; set; }
        public Client Client { get; set; }

        public DateTime DateEmission { get; set; }
        public double MontantTotal { get; set; }

        public int IdPaiement { get; set; }
        public Paiement Paiement { get; set; }

        public string Status { get; set; } // Enum: Paid, Unpaid
    }
}
