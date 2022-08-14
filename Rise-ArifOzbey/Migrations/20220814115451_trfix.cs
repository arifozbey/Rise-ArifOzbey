using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise_ArifOzbey.Migrations
{
    public partial class trfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Soyadı",
                table: "KisiModels",
                newName: "Soyadi");

            migrationBuilder.RenameColumn(
                name: "Adı",
                table: "KisiModels",
                newName: "Adi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Soyadi",
                table: "KisiModels",
                newName: "Soyadı");

            migrationBuilder.RenameColumn(
                name: "Adi",
                table: "KisiModels",
                newName: "Adı");
        }
    }
}
