using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libros.Infrastructure.Migrations
{
    public partial class AddingStateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "LibrosDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "LibrosDetalle");
        }
    }
}
