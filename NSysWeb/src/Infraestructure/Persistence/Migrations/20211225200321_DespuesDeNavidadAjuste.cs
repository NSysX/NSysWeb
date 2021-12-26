using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class DespuesDeNavidadAjuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTelefono_Persona_PersonaIdPersona",
                table: "PersonaTelefono");

            migrationBuilder.DropIndex(
                name: "IX_PersonaTelefono_PersonaIdPersona",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "PersonaIdPersona",
                table: "PersonaTelefono");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioModificacion",
                table: "Persona",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                comment: "Ultimo usuario que modifico",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldComment: "Ultimo usuario que modifico ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonaIdPersona",
                table: "PersonaTelefono",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioModificacion",
                table: "Persona",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                comment: "Ultimo usuario que modifico ",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldComment: "Ultimo usuario que modifico");

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
    }
}
