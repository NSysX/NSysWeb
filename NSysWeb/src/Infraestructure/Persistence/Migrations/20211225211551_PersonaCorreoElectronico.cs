using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PersonaCorreoElectronico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado10",
                table: "Telefono",
                newName: "IX_NoDuplicado11");

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
                name: "IX_NoDuplicado",
                table: "PersonaCorreoElectronico",
                newName: "IX_NoDuplicado6");

            migrationBuilder.AddColumn<int>(
                name: "IdPersonaCorreoElectronico",
                table: "PersonaCorreoElectronico",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaCorreoElectronico",
                table: "PersonaCorreoElectronico",
                column: "IdPersonaCorreoElectronico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaCorreoElectronico",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropColumn(
                name: "IdPersonaCorreoElectronico",
                table: "PersonaCorreoElectronico");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado11",
                table: "Telefono",
                newName: "IX_NoDuplicado10");

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
                newName: "IX_NoDuplicado");
        }
    }
}
