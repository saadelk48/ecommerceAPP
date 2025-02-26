namespace EFpfa.Models
{
    public class Paiement
    {
        public int Id { get; set; }

        public int IdClient { get; set; }
        public Client Client { get; set; }

        public int IdCommande { get; set; }
        public Commande Commande { get; set; }

        public double Totale { get; set; }
        public string MethodePaiement { get; set; }
        public string Status { get; set; } // Enum: Paid, Pending, Failed
        public DateTime DatePaiement { get; set; }
    }
}
