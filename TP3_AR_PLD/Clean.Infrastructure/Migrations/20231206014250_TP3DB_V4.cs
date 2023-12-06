using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Migrations
{
    public partial class TP3DB_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemandeAideFinanciereId",
                table: "CalculVersements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DemandeAideFinanciereId",
                table: "CalculVersements",
                type: "int",
                nullable: true);
        }
    }
}
