using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libros.Infrastructure.Migrations
{
    public partial class FixingProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha_Ingreso",
                table: "LibrosDetalle",
                newName: "FechaIngreso");

            migrationBuilder.AlterColumn<string>(
                name: "Condicion",
                table: "LibrosDetalle",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaIngreso",
                table: "LibrosDetalle",
                newName: "Fecha_Ingreso");

            migrationBuilder.AlterColumn<string>(
                name: "Condicion",
                table: "LibrosDetalle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }
    }
}
