using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise_ArifOzbey.Migrations
{
    public partial class dbset1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KisiDetayModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TelefonNo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    Konum = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    Icerik = table.Column<string>(type: "character varying(140)", maxLength: 140, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiDetayModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KisiModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Adı = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    Soyadı = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    Firma = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    KisiDetayID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisiDetayModels");

            migrationBuilder.DropTable(
                name: "KisiModels");
        }
    }
}
