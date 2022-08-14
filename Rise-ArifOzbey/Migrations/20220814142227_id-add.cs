using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise_ArifOzbey.Migrations
{
    public partial class idadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KisiDetayID",
                table: "KisiModels");

            migrationBuilder.AddColumn<Guid>(
                name: "KisiID",
                table: "KisiDetayModels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KisiID",
                table: "KisiDetayModels");

            migrationBuilder.AddColumn<Guid>(
                name: "KisiDetayID",
                table: "KisiModels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
