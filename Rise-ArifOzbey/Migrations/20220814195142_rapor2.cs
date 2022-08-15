using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise_ArifOzbey.Migrations
{
    public partial class rapor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dosyapath",
                table: "RaporModels",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dosyapath",
                table: "RaporModels");
        }
    }
}
