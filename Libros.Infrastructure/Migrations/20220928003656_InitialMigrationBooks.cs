using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libros.Infrastructure.Migrations
{
    public partial class InitialMigrationBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibrosEncabezado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLibro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioPub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    ejemplares = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosEncabezado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibrosEncabezado_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibrosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoPrestamo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibrosDetalle_LibrosEncabezado_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "LibrosEncabezado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosDetalle_IdLibro",
                table: "LibrosDetalle",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosEncabezado_IdCategoria",
                table: "LibrosEncabezado",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosDetalle");

            migrationBuilder.DropTable(
                name: "LibrosEncabezado");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
