using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class MiPrimerFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdMunicipio",
                table: "Asentamiento",
                newName: "MunicipioId");

            migrationBuilder.RenameColumn(
                name: "IdAsentamientoTipo",
                table: "Asentamiento",
                newName: "AsentamientoTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MunicipioId",
                table: "Asentamiento",
                newName: "IdMunicipio");

            migrationBuilder.RenameColumn(
                name: "AsentamientoTipoId",
                table: "Asentamiento",
                newName: "IdAsentamientoTipo");
        }
    }
}
