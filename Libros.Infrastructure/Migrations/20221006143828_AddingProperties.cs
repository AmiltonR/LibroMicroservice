using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libros.Infrastructure.Migrations
{
    public partial class AddingProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "LibrosDetalle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Editorial",
                table: "LibrosDetalle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "LibrosDetalle");

            migrationBuilder.DropColumn(
                name: "Editorial",
                table: "LibrosDetalle");
        }
    }
}
