using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CambioDeGeometryAPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AsentamientoId",
                table: "Direccion",
                newName: "IdAsentamiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAsentamiento",
                table: "Direccion",
                newName: "AsentamientoId");
        }
    }
}
