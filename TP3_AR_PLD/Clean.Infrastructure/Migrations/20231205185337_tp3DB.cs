using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Migrations
{
    public partial class tp3DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroAssuranceSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodePermanent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandeAideFinanciere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEtablissementEnseignement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeEtablissementEnseignement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDuProgramme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreDeCredits = table.Column<int>(type: "int", nullable: true),
                    EtatMatrimonial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebutEtatMatrimonial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevenusEmploie = table.Column<int>(type: "int", nullable: true),
                    AutresRevenus = table.Column<int>(type: "int", nullable: true),
                    RevenusPotentiels = table.Column<int>(type: "int", nullable: true),
                    EtudiantsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeAideFinanciere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeAideFinanciere_Etudiants_EtudiantsId",
                        column: x => x.EtudiantsId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DossierEtudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudiantsId = table.Column<int>(type: "int", nullable: false),
                    AdresseDeCorrespondance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeTelephonePrincipale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeTelephoneSecondaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseCourriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citoyennte = table.Column<bool>(type: "bit", nullable: true),
                    CodeImmigration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateObtentionStatusResidentPermanent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LangueCorrespondance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierEtudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierEtudiants_Etudiants_EtudiantsId",
                        column: x => x.EtudiantsId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculVersements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandeAideFinanciereId = table.Column<int>(type: "int", nullable: false),
                    DemandeAideFinancieresId = table.Column<int>(type: "int", nullable: true),
                    AnneeEnCours = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculVersements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculVersements_DemandeAideFinanciere_DemandeAideFinancieresId",
                        column: x => x.DemandeAideFinancieresId,
                        principalTable: "DemandeAideFinanciere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculVersements_DemandeAideFinancieresId",
                table: "CalculVersements",
                column: "DemandeAideFinancieresId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeAideFinanciere_EtudiantsId",
                table: "DemandeAideFinanciere",
                column: "EtudiantsId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierEtudiants_EtudiantsId",
                table: "DossierEtudiants",
                column: "EtudiantsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculVersements");

            migrationBuilder.DropTable(
                name: "DossierEtudiants");

            migrationBuilder.DropTable(
                name: "DemandeAideFinanciere");

            migrationBuilder.DropTable(
                name: "Etudiants");
        }
    }
}
