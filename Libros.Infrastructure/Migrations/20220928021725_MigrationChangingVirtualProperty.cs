using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libros.Infrastructure.Migrations
{
    public partial class MigrationChangingVirtualProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ejemplares",
                table: "LibrosEncabezado",
                newName: "Ejemplares");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ejemplares",
                table: "LibrosEncabezado",
                newName: "ejemplares");
        }
    }
}
