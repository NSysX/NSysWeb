using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class devolvi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentoTipoId",
                table: "Documento",
                newName: "IdDocumentoTipo");

            migrationBuilder.RenameColumn(
                name: "AsentamientoTipoId",
                table: "Asentamiento",
                newName: "IdAsentamientoTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDocumentoTipo",
                table: "Documento",
                newName: "DocumentoTipoId");

            migrationBuilder.RenameColumn(
                name: "IdAsentamientoTipo",
                table: "Asentamiento",
                newName: "AsentamientoTipoId");
        }
    }
}
