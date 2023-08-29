﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230815173246_addTypeHabitat")]
    partial class addTypeHabitat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EnfantParrain", b =>
                {
                    b.Property<int>("EnfantsId")
                        .HasColumnType("int");

                    b.Property<int>("ParrainsId")
                        .HasColumnType("int");

                    b.HasKey("EnfantsId", "ParrainsId");

                    b.HasIndex("ParrainsId");

                    b.ToTable("EnfantParrain");
                });

            modelBuilder.Entity("WebApi.Models.Enfant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateDebutKafala")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateInscription")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FamilleId")
                        .HasColumnType("int");

                    b.Property<string>("LieuNaissance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NiveauScolaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Remarque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FamilleId");

                    b.ToTable("Enfants");
                });

            modelBuilder.Entity("WebApi.Models.Famille", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeFamille")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateDebutKafala")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateInscription")
                        .HasColumnType("datetime2");

                    b.Property<string>("LieuResidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomFamille")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomMere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomPere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NombreFilles")
                        .HasColumnType("int");

                    b.Property<int?>("NombreGarcons")
                        .HasColumnType("int");

                    b.Property<string>("TelMere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TravailMere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeHabitat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Familles");
                });

            modelBuilder.Entity("WebApi.Models.Parrain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CotisationMensuelle")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePremiereCotisation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DebutKafala")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fonction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GSM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parrains");
                });

            modelBuilder.Entity("WebApi.Models.Parrainage", b =>
                {
                    b.Property<int>("EnfantId")
                        .HasColumnType("int");

                    b.Property<int>("ParrainId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateDebutKafala")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MontantKafala")
                        .HasColumnType("int");

                    b.HasKey("EnfantId", "ParrainId");

                    b.HasIndex("ParrainId");

                    b.ToTable("Parrainages");
                });

            modelBuilder.Entity("EnfantParrain", b =>
                {
                    b.HasOne("WebApi.Models.Enfant", null)
                        .WithMany()
                        .HasForeignKey("EnfantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Parrain", null)
                        .WithMany()
                        .HasForeignKey("ParrainsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Models.Enfant", b =>
                {
                    b.HasOne("WebApi.Models.Famille", "Famille")
                        .WithMany("Enfants")
                        .HasForeignKey("FamilleId");

                    b.Navigation("Famille");
                });

            modelBuilder.Entity("WebApi.Models.Parrainage", b =>
                {
                    b.HasOne("WebApi.Models.Enfant", "Enfant")
                        .WithMany("Parrainages")
                        .HasForeignKey("EnfantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Parrain", "Parrain")
                        .WithMany("Parrainages")
                        .HasForeignKey("ParrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enfant");

                    b.Navigation("Parrain");
                });

            modelBuilder.Entity("WebApi.Models.Enfant", b =>
                {
                    b.Navigation("Parrainages");
                });

            modelBuilder.Entity("WebApi.Models.Famille", b =>
                {
                    b.Navigation("Enfants");
                });

            modelBuilder.Entity("WebApi.Models.Parrain", b =>
                {
                    b.Navigation("Parrainages");
                });
#pragma warning restore 612, 618
        }
    }
}
