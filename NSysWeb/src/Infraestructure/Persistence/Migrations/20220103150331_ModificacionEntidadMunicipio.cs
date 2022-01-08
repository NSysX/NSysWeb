using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ModificacionEntidadMunicipio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MunicipioId",
                table: "Asentamiento",
                newName: "IdMunicipio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdMunicipio",
                table: "Asentamiento",
                newName: "MunicipioId");
        }
    }
}
