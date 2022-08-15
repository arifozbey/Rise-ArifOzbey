using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise_ArifOzbey.Migrations
{
    public partial class rapor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaporModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TalepTarihi = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Konum = table.Column<string>(type: "text", nullable: true),
                    Durumu = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaporSonucModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Konum = table.Column<string>(type: "text", nullable: true),
                    RehberdekiKayitliKisiSayisi = table.Column<int>(type: "integer", nullable: false),
                    RehberdeKayitliTelefonSayisi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporSonucModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaporModels");

            migrationBuilder.DropTable(
                name: "RaporSonucModels");
        }
    }
}
