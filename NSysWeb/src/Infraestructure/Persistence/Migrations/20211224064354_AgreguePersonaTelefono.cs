using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AgreguePersonaTelefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado9",
                table: "Telefono",
                newName: "IX_NoDuplicado10");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado9");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado",
                table: "PersonaTelefono",
                newName: "IX_NoDuplicado8");

            migrationBuilder.AddColumn<int>(
                name: "IdPersonaTelefono",
                table: "PersonaTelefono",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonaIdPersona",
                table: "PersonaTelefono",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaTelefono",
                table: "PersonaTelefono",
                column: "IdPersonaTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaTelefono_PersonaIdPersona",
                table: "PersonaTelefono",
                column: "PersonaIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTelefono_Persona_PersonaIdPersona",
                table: "PersonaTelefono",
                column: "PersonaIdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTelefono_Persona_PersonaIdPersona",
                table: "PersonaTelefono");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaTelefono",
                table: "PersonaTelefono");

            migrationBuilder.DropIndex(
                name: "IX_PersonaTelefono_PersonaIdPersona",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "IdPersonaTelefono",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "PersonaIdPersona",
                table: "PersonaTelefono");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado10",
                table: "Telefono",
                newName: "IX_NoDuplicado9");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado9",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado8");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "PersonaTelefono",
                newName: "IX_NoDuplicado");
        }
    }
}
