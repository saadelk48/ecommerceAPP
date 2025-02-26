namespace EFpfa.Models
{
    public class Livraison
    {
        public int Id { get; set; }

        public int IdCommande { get; set; }
        public Commande Commande { get; set; }

        public string AdresseLivraison { get; set; }

        public string StatusLivraison { get; set; } // Enum: InTransit, Delivered, Cancelled
        public DateTime? EstimationDate { get; set; }
    }
}
