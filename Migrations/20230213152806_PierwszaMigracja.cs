using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep_muzyczny.Migrations
{
    public partial class PierwszaMigracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.KategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Producent",
                columns: table => new
                {
                    ProducentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokZalozenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producent", x => x.ProducentId);
                });

            migrationBuilder.CreateTable(
                name: "Wojewodztwo",
                columns: table => new
                {
                    WojewodztwoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wojewodztwo", x => x.WojewodztwoId);
                });

            migrationBuilder.CreateTable(
                name: "Podkategoria",
                columns: table => new
                {
                    PodkategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriaId = table.Column<int>(type: "int", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podkategoria", x => x.PodkategoriaId);
                    table.ForeignKey(
                        name: "FK_Podkategoria_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "KategoriaId");
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    KlientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WojewodztwoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRejestracji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WojewodztwaWojewodztwoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.KlientId);
                    table.ForeignKey(
                        name: "FK_Klient_Wojewodztwo_WojewodztwaWojewodztwoId",
                        column: x => x.WojewodztwaWojewodztwoId,
                        principalTable: "Wojewodztwo",
                        principalColumn: "WojewodztwoId");
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducentId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    PodkategoriaId = table.Column<int>(type: "int", nullable: true),
                    DataProdukcji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.ProduktId);
                    table.ForeignKey(
                        name: "FK_Produkt_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "KategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkt_Podkategoria_PodkategoriaId",
                        column: x => x.PodkategoriaId,
                        principalTable: "Podkategoria",
                        principalColumn: "PodkategoriaId");
                    table.ForeignKey(
                        name: "FK_Produkt_Producent_ProducentId",
                        column: x => x.ProducentId,
                        principalTable: "Producent",
                        principalColumn: "ProducentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klient_WojewodztwaWojewodztwoId",
                table: "Klient",
                column: "WojewodztwaWojewodztwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Podkategoria_KategoriaId",
                table: "Podkategoria",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_KategoriaId",
                table: "Produkt",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_PodkategoriaId",
                table: "Produkt",
                column: "PodkategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkt_ProducentId",
                table: "Produkt",
                column: "ProducentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Wojewodztwo");

            migrationBuilder.DropTable(
                name: "Podkategoria");

            migrationBuilder.DropTable(
                name: "Producent");

            migrationBuilder.DropTable(
                name: "Kategoria");
        }
    }
}
