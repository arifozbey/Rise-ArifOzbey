using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise_ArifOzbey.Migrations
{
    public partial class dbadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaporSonucModels");

            migrationBuilder.RenameColumn(
                name: "dosyapath",
                table: "RaporModels",
                newName: "Dosyapath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dosyapath",
                table: "RaporModels",
                newName: "dosyapath");

            migrationBuilder.CreateTable(
                name: "RaporSonucModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Konum = table.Column<string>(type: "text", nullable: true),
                    RehberdeKayitliTelefonSayisi = table.Column<int>(type: "integer", nullable: false),
                    RehberdekiKayitliKisiSayisi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporSonucModels", x => x.Id);
                });
        }
    }
}
