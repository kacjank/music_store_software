using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sklep_muzyczny.Migrations
{
    public partial class DrugaMigracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klient_Wojewodztwo_WojewodztwaWojewodztwoId",
                table: "Klient");

            migrationBuilder.RenameColumn(
                name: "WojewodztwaWojewodztwoId",
                table: "Klient",
                newName: "WojewodztwoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Klient_WojewodztwaWojewodztwoId",
                table: "Klient",
                newName: "IX_Klient_WojewodztwoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Klient_Wojewodztwo_WojewodztwoId1",
                table: "Klient",
                column: "WojewodztwoId1",
                principalTable: "Wojewodztwo",
                principalColumn: "WojewodztwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klient_Wojewodztwo_WojewodztwoId1",
                table: "Klient");

            migrationBuilder.RenameColumn(
                name: "WojewodztwoId1",
                table: "Klient",
                newName: "WojewodztwaWojewodztwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Klient_WojewodztwoId1",
                table: "Klient",
                newName: "IX_Klient_WojewodztwaWojewodztwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klient_Wojewodztwo_WojewodztwaWojewodztwoId",
                table: "Klient",
                column: "WojewodztwaWojewodztwoId",
                principalTable: "Wojewodztwo",
                principalColumn: "WojewodztwoId");
        }
    }
}
