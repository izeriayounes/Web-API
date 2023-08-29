using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeFamille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomFamille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomPere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomMere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravailMere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelMere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LieuResidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreGarcons = table.Column<int>(type: "int", nullable: true),
                    NombreFilles = table.Column<int>(type: "int", nullable: true),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDebutKafala = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeHabitatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fonction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebutKafala = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatePremiereCotisation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CotisationMensuelle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parrains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LieuNaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDebutKafala = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FamilleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfants_Familles_FamilleId",
                        column: x => x.FamilleId,
                        principalTable: "Familles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parrainages",
                columns: table => new
                {
                    EnfantId = table.Column<int>(type: "int", nullable: false),
                    ParrainId = table.Column<int>(type: "int", nullable: false),
                    DateDebutKafala = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MontantKafala = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parrainages", x => new { x.EnfantId, x.ParrainId });
                    table.ForeignKey(
                        name: "FK_Parrainages_Enfants_EnfantId",
                        column: x => x.EnfantId,
                        principalTable: "Enfants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parrainages_Parrains_ParrainId",
                        column: x => x.ParrainId,
                        principalTable: "Parrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_FamilleId",
                table: "Enfants",
                column: "FamilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Parrainages_ParrainId",
                table: "Parrainages",
                column: "ParrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parrainages");

            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Parrains");

            migrationBuilder.DropTable(
                name: "Familles");
        }
    }
}
