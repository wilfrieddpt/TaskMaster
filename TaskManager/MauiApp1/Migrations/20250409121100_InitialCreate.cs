using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Etiquettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquettes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Echeance = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Statut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Priorite = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categorie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuteurId = table.Column<int>(type: "int", nullable: false),
                    RealisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taches_Utilisateurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taches_Utilisateurs_RealisateurId",
                        column: x => x.RealisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TacheId = table.Column<int>(type: "int", nullable: false),
                    AuteurId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Contenu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Taches_TacheId",
                        column: x => x.TacheId,
                        principalTable: "Taches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Utilisateurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EtiquetteTache",
                columns: table => new
                {
                    EtiquettesId = table.Column<int>(type: "int", nullable: false),
                    TachesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetteTache", x => new { x.EtiquettesId, x.TachesId });
                    table.ForeignKey(
                        name: "FK_EtiquetteTache_Etiquettes_EtiquettesId",
                        column: x => x.EtiquettesId,
                        principalTable: "Etiquettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetteTache_Taches_TachesId",
                        column: x => x.TachesId,
                        principalTable: "Taches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SousTaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TacheId = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Statut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Echeance = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousTaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousTaches_Taches_TacheId",
                        column: x => x.TacheId,
                        principalTable: "Taches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_AuteurId",
                table: "Commentaires",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_TacheId",
                table: "Commentaires",
                column: "TacheId");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetteTache_TachesId",
                table: "EtiquetteTache",
                column: "TachesId");

            migrationBuilder.CreateIndex(
                name: "IX_SousTaches_TacheId",
                table: "SousTaches",
                column: "TacheId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_AuteurId",
                table: "Taches",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_RealisateurId",
                table: "Taches",
                column: "RealisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "EtiquetteTache");

            migrationBuilder.DropTable(
                name: "SousTaches");

            migrationBuilder.DropTable(
                name: "Etiquettes");

            migrationBuilder.DropTable(
                name: "Taches");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
