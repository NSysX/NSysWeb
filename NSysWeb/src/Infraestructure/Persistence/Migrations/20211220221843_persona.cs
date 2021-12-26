using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class persona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsHabilitado",
                table: "PersonaDireccion");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "PersonaDireccion");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "PersonaDireccion");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "PersonaDireccion");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "PersonaDireccion");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado7",
                table: "Telefono",
                newName: "IX_NoDuplicado8");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado6",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado7");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado",
                table: "PersonaDireccion",
                newName: "IX_NoDuplicado6");

            migrationBuilder.RenameColumn(
                name: "IdNacionalidad",
                table: "Persona",
                newName: "NacionalidadId");

            migrationBuilder.RenameColumn(
                name: "IdEstadoCivil",
                table: "Persona",
                newName: "EstadoCivilId");

            migrationBuilder.AddColumn<int>(
                name: "IdPersonaDireccion",
                table: "PersonaDireccion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaDireccion",
                table: "PersonaDireccion",
                column: "IdPersonaDireccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaDireccion",
                table: "PersonaDireccion");

            migrationBuilder.DropColumn(
                name: "IdPersonaDireccion",
                table: "PersonaDireccion");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado8",
                table: "Telefono",
                newName: "IX_NoDuplicado7");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado7",
                table: "SysDominioCorreo",
                newName: "IX_NoDuplicado6");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado6",
                table: "PersonaDireccion",
                newName: "IX_NoDuplicado");

            migrationBuilder.RenameColumn(
                name: "NacionalidadId",
                table: "Persona",
                newName: "IdNacionalidad");

            migrationBuilder.RenameColumn(
                name: "EstadoCivilId",
                table: "Persona",
                newName: "IdEstadoCivil");

            migrationBuilder.AddColumn<bool>(
                name: "EsHabilitado",
                table: "PersonaDireccion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "PersonaDireccion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "PersonaDireccion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "PersonaDireccion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "PersonaDireccion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
