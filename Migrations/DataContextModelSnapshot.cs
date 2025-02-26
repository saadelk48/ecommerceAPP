﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerceAPP.Data;

#nullable disable

namespace ecommerceAPP.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFpfa.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EFpfa.Models.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<double>("MontantTotal")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("EFpfa.Models.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommentaire")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdProduit")
                        .HasColumnType("int");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProduitId");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("EFpfa.Models.Facture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEmission")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCommande")
                        .HasColumnType("int");

                    b.Property<int>("IdPaiement")
                        .HasColumnType("int");

                    b.Property<double>("MontantTotal")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdCommande");

                    b.HasIndex("IdPaiement");

                    b.ToTable("Factures");
                });

            modelBuilder.Entity("EFpfa.Models.LigneCommande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<int>("IdCommande")
                        .HasColumnType("int");

                    b.Property<int>("IdProduit")
                        .HasColumnType("int");

                    b.Property<float>("PrixTotal")
                        .HasColumnType("real");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.HasIndex("ProduitId");

                    b.ToTable("LigneCommandes");
                });

            modelBuilder.Entity("EFpfa.Models.Livraison", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdresseLivraison")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EstimationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCommande")
                        .HasColumnType("int");

                    b.Property<string>("StatusLivraison")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.ToTable("Livraisons");
                });

            modelBuilder.Entity("EFpfa.Models.Paiement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePaiement")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdCommande")
                        .HasColumnType("int");

                    b.Property<string>("MethodePaiement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Totale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId");

                    b.HasIndex("IdClient");

                    b.ToTable("Paiements");
                });

            modelBuilder.Entity("EFpfa.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("StockQuantites")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("EFpfa.Models.PromoCode", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateExpiration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EstActive")
                        .HasColumnType("bit");

                    b.Property<float>("Reduction")
                        .HasColumnType("real");

                    b.HasKey("Code");

                    b.ToTable("PromoCodes");
                });

            modelBuilder.Entity("EFpfa.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");

                    b.HasDiscriminator<string>("Type").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EFpfa.Models.Admin", b =>
                {
                    b.HasBaseType("EFpfa.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("EFpfa.Models.Client", b =>
                {
                    b.HasBaseType("EFpfa.Models.Utilisateur");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("EFpfa.Models.Commande", b =>
                {
                    b.HasOne("EFpfa.Models.Client", "Client")
                        .WithMany("Commandes")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EFpfa.Models.Commentaire", b =>
                {
                    b.HasOne("EFpfa.Models.Client", "Client")
                        .WithMany("Commentaires")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFpfa.Models.Produit", "Produit")
                        .WithMany("Commentaires")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("EFpfa.Models.Facture", b =>
                {
                    b.HasOne("EFpfa.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EFpfa.Models.Commande", "Commande")
                        .WithMany()
                        .HasForeignKey("IdCommande")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EFpfa.Models.Paiement", "Paiement")
                        .WithMany()
                        .HasForeignKey("IdPaiement")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Commande");

                    b.Navigation("Paiement");
                });

            modelBuilder.Entity("EFpfa.Models.LigneCommande", b =>
                {
                    b.HasOne("EFpfa.Models.Commande", "Commande")
                        .WithMany("LigneCommandes")
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFpfa.Models.Produit", "Produit")
                        .WithMany("LigneCommandes")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("EFpfa.Models.Livraison", b =>
                {
                    b.HasOne("EFpfa.Models.Commande", "Commande")
                        .WithMany("Livraisons")
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");
                });

            modelBuilder.Entity("EFpfa.Models.Paiement", b =>
                {
                    b.HasOne("EFpfa.Models.Commande", "Commande")
                        .WithMany("Paiements")
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFpfa.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Commande");
                });

            modelBuilder.Entity("EFpfa.Models.Produit", b =>
                {
                    b.HasOne("EFpfa.Models.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("EFpfa.Models.Categorie", b =>
                {
                    b.Navigation("Produits");
                });

            modelBuilder.Entity("EFpfa.Models.Commande", b =>
                {
                    b.Navigation("LigneCommandes");

                    b.Navigation("Livraisons");

                    b.Navigation("Paiements");
                });

            modelBuilder.Entity("EFpfa.Models.Produit", b =>
                {
                    b.Navigation("Commentaires");

                    b.Navigation("LigneCommandes");
                });

            modelBuilder.Entity("EFpfa.Models.Client", b =>
                {
                    b.Navigation("Commandes");

                    b.Navigation("Commentaires");
                });
#pragma warning restore 612, 618
        }
    }
}
