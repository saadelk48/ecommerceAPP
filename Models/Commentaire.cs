namespace EFpfa.Models
{
    public class Commentaire
    {
        public int Id { get; set; }

        public int IdClient { get; set; }
        public Client Client { get; set; }

        public int IdProduit { get; set; }
        public Produit Produit { get; set; }

        public string Description { get; set; }
        public DateTime DateCommentaire { get; set; }
    }
}
