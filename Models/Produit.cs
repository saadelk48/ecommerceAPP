namespace EFpfa.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int StockQuantites { get; set; }

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public ICollection<LigneCommande> LigneCommandes { get; set; }
        public ICollection<Commentaire> Commentaires { get; set; }
    }
}
