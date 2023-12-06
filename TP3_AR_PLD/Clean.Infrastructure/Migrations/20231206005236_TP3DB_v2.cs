using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Migrations
{
    public partial class TP3DB_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DemandeAideFinanciereId",
                table: "CalculVersements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateVersement",
                table: "CalculVersements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Montants",
                table: "CalculVersements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeVersement",
                table: "CalculVersements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateVersement",
                table: "CalculVersements");

            migrationBuilder.DropColumn(
                name: "Montants",
                table: "CalculVersements");

            migrationBuilder.DropColumn(
                name: "TypeVersement",
                table: "CalculVersements");

            migrationBuilder.AlterColumn<int>(
                name: "DemandeAideFinanciereId",
                table: "CalculVersements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
