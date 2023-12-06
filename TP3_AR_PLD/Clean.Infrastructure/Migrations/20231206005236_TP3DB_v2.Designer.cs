﻿// <auto-generated />
using System;
using Clean.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clean.Infrastructure.Migrations
{
    [DbContext(typeof(CleanContext))]
    [Migration("20231206005236_TP3DB_v2")]
    partial class TP3DB_v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Clean.Core.Entities.CalculVersements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnneeEnCours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateVersement")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DemandeAideFinanciereId")
                        .HasColumnType("int");

                    b.Property<int?>("DemandeAideFinancieresId")
                        .HasColumnType("int");

                    b.Property<int?>("Montants")
                        .HasColumnType("int");

                    b.Property<string>("TypeVersement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DemandeAideFinancieresId");

                    b.ToTable("CalculVersements");
                });

            modelBuilder.Entity("Clean.Core.Entities.DemandeAideFinancieres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AutresRevenus")
                        .HasColumnType("int");

                    b.Property<string>("CodeDuProgramme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeEtablissementEnseignement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateDebutEtatMatrimonial")
                        .HasColumnType("datetime2");

                    b.Property<string>("EtatMatrimonial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EtudiantsId")
                        .HasColumnType("int");

                    b.Property<string>("NomEtablissementEnseignement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NombreDeCredits")
                        .HasColumnType("int");

                    b.Property<int?>("RevenusEmploie")
                        .HasColumnType("int");

                    b.Property<int?>("RevenusPotentiels")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EtudiantsId");

                    b.ToTable("DemandeAideFinanciere");
                });

            modelBuilder.Entity("Clean.Core.Entities.DossierEtudiants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdresseCourriel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdresseDeCorrespondance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Citoyennte")
                        .HasColumnType("bit");

                    b.Property<string>("CodeImmigration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateObtentionStatusResidentPermanent")
                        .HasColumnType("datetime2");

                    b.Property<int>("EtudiantsId")
                        .HasColumnType("int");

                    b.Property<string>("LangueCorrespondance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDeTelephonePrincipale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDeTelephoneSecondaire")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EtudiantsId")
                        .IsUnique();

                    b.ToTable("DossierEtudiants");
                });

            modelBuilder.Entity("Clean.Core.Entities.Etudiants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CodePermanent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotDePasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroAssuranceSociale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("Clean.Core.Entities.CalculVersements", b =>
                {
                    b.HasOne("Clean.Core.Entities.DemandeAideFinancieres", "DemandeAideFinancieres")
                        .WithMany("CalculVersements")
                        .HasForeignKey("DemandeAideFinancieresId");

                    b.Navigation("DemandeAideFinancieres");
                });

            modelBuilder.Entity("Clean.Core.Entities.DemandeAideFinancieres", b =>
                {
                    b.HasOne("Clean.Core.Entities.Etudiants", "Etudiants")
                        .WithMany("DemandeAideFinancieres")
                        .HasForeignKey("EtudiantsId");

                    b.Navigation("Etudiants");
                });

            modelBuilder.Entity("Clean.Core.Entities.DossierEtudiants", b =>
                {
                    b.HasOne("Clean.Core.Entities.Etudiants", "Etudiants")
                        .WithOne("DossierEtudiants")
                        .HasForeignKey("Clean.Core.Entities.DossierEtudiants", "EtudiantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiants");
                });

            modelBuilder.Entity("Clean.Core.Entities.DemandeAideFinancieres", b =>
                {
                    b.Navigation("CalculVersements");
                });

            modelBuilder.Entity("Clean.Core.Entities.Etudiants", b =>
                {
                    b.Navigation("DemandeAideFinancieres");

                    b.Navigation("DossierEtudiants");
                });
#pragma warning restore 612, 618
        }
    }
}
