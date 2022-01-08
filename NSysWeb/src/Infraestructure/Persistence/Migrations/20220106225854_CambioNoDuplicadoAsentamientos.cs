using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CambioNoDuplicadoAsentamientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicado",
                table: "Asentamiento");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado10",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado9");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado9",
                table: "PersonaTelefono",
                newName: "IX_NoDuplicado8");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "PersonaDocumento",
                newName: "IX_NoDuplicado7");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado7",
                table: "PersonaDireccion",
                newName: "IX_NoDuplicado6");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado6",
                table: "PersonaCorreoElectronico",
                newName: "IX_NoDuplicado5");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado5",
                table: "Persona",
                newName: "IX_NoDuplicado4");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado4",
                table: "Nacionalidad",
                newName: "IX_NoDuplicado3");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado3",
                table: "EstadoCivil",
                newName: "IX_NoDuplicado2");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado2",
                table: "Documento",
                newName: "IX_NoDuplicado1");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado1",
                table: "CorreoElectronico",
                newName: "IX_NoDuplicado");

            migrationBuilder.AlterColumn<int>(
                name: "IdAsentamientoTipo",
                table: "Asentamiento",
                type: "int",
                nullable: false,
                comment: "El id de la tabla TipoAsentamiento",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "El id de la tabla TipoAsentamiento ");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoIdMunicipioNombre",
                table: "Asentamiento",
                columns: new[] { "IdMunicipio", "Nombre" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoIdMunicipioNombre",
                table: "Asentamiento");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado9",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado10");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "PersonaTelefono",
                newName: "IX_NoDuplicado9");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado7",
                table: "PersonaDocumento",
                newName: "IX_NoDuplicado8");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado6",
                table: "PersonaDireccion",
                newName: "IX_NoDuplicado7");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado5",
                table: "PersonaCorreoElectronico",
                newName: "IX_NoDuplicado6");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado4",
                table: "Persona",
                newName: "IX_NoDuplicado5");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado3",
                table: "Nacionalidad",
                newName: "IX_NoDuplicado4");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado2",
                table: "EstadoCivil",
                newName: "IX_NoDuplicado3");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado1",
                table: "Documento",
                newName: "IX_NoDuplicado2");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado",
                table: "CorreoElectronico",
                newName: "IX_NoDuplicado1");

            migrationBuilder.AlterColumn<int>(
                name: "IdAsentamientoTipo",
                table: "Asentamiento",
                type: "int",
                nullable: false,
                comment: "El id de la tabla TipoAsentamiento ",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "El id de la tabla TipoAsentamiento");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado",
                table: "Asentamiento",
                columns: new[] { "IdMunicipio", "IdAsentamientoTipo", "Nombre" },
                unique: true);
        }
    }
}
