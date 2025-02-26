using EFpfa.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceAPP.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<LigneCommande> LigneCommandes { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>()
                .HasDiscriminator<string>("Type")
                .HasValue<Utilisateur>("User")
                .HasValue<Admin>("Admin")
                .HasValue<Client>("Client");

            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Commandes)
                .HasForeignKey(c => c.IdClient)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Paiement>()
             .HasOne(p => p.Client)
             .WithMany() // No navigation property needed if it's one-way
             .HasForeignKey(p => p.IdClient)
             .OnDelete(DeleteBehavior.NoAction); // Prevents cascading delete

            // Facture → Commande
            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Commande)
                .WithMany()
                .HasForeignKey(f => f.IdCommande)
                .OnDelete(DeleteBehavior.NoAction); // Prevents multiple cascade paths

            // Facture → Client
            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Client)
                .WithMany()
                .HasForeignKey(f => f.IdClient)
                .OnDelete(DeleteBehavior.NoAction);

            // Facture → Paiement
            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Paiement)
                .WithMany()
                .HasForeignKey(f => f.IdPaiement)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
