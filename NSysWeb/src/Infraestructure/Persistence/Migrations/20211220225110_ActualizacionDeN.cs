using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ActualizacionDeN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsHabilitado",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "PersonaTelefono");

            migrationBuilder.DropColumn(
                name: "EsHabilitado",
                table: "PersonaDocumento");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "PersonaDocumento");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "PersonaDocumento");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "PersonaDocumento");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "PersonaDocumento");

            migrationBuilder.DropColumn(
                name: "EsHabilitado",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "PersonaCorreoElectronico");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "Telefono",
                newName: "IX_NoDuplicado9");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado7",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado8");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado",
                table: "PersonaDocumento",
                newName: "IX_NoDuplicado7");

            migrationBuilder.AddColumn<int>(
                name: "IdPersonaDocumento",
                table: "PersonaDocumento",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaDocumento",
                table: "PersonaDocumento",
                column: "IdPersonaDocumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaDocumento",
                table: "PersonaDocumento");

            migrationBuilder.DropColumn(
                name: "IdPersonaDocumento",
                table: "PersonaDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado9",
                table: "Telefono",
                newName: "IX_NoDuplicado8");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado7");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado7",
                table: "PersonaDocumento",
                newName: "IX_NoDuplicado");

            migrationBuilder.AddColumn<bool>(
                name: "EsHabilitado",
                table: "PersonaTelefono",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "PersonaTelefono",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "PersonaTelefono",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "PersonaTelefono",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "PersonaTelefono",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsHabilitado",
                table: "PersonaDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "PersonaDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "PersonaDocumento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "PersonaDocumento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "PersonaDocumento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsHabilitado",
                table: "PersonaCorreoElectronico",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "PersonaCorreoElectronico",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "PersonaCorreoElectronico",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "PersonaCorreoElectronico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "PersonaCorreoElectronico",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
