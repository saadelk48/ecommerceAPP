namespace EFpfa.Models
{
    public class LigneCommande
    {
        public int Id { get; set; }

        public int IdCommande { get; set; }
        public Commande Commande { get; set; }

        public int IdProduit { get; set; }
        public Produit Produit { get; set; }

        public int Quantite { get; set; }
        public float PrixTotal { get; set; }
    }
}
