using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CorregiNombresdeIndicesParaEvitarnumerosenBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoNom1",
                table: "Municipio",
                newName: "IX_NoDuplicadoNomMuni");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoAbre2",
                table: "Municipio",
                newName: "IX_NoDuplicadoAbrevMuni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoNomMuni",
                table: "Municipio",
                newName: "IX_NoDuplicadoNom1");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoAbrevMuni",
                table: "Municipio",
                newName: "IX_NoDuplicadoAbre2");
        }
    }
}
