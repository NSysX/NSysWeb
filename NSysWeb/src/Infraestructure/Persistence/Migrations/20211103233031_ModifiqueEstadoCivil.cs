using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ModifiqueEstadoCivil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Es_Habilitado1",
                table: "EstadoCivil");

            migrationBuilder.DropColumn(
                name: "Fecha_Creacion1",
                table: "EstadoCivil");

            migrationBuilder.DropColumn(
                name: "Fecha_Mod",
                table: "EstadoCivil");

            migrationBuilder.DropColumn(
                name: "Usuario_Creacion1",
                table: "EstadoCivil");

            migrationBuilder.DropColumn(
                name: "Usuario_Mod",
                table: "EstadoCivil");

            migrationBuilder.AlterColumn<string>(
                name: "Usuario_Creacion",
                table: "EstadoCivil",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldComment: "El usuario que creo el registro");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Creacion",
                table: "EstadoCivil",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "Fecha de creacion del registro");

            migrationBuilder.AlterColumn<bool>(
                name: "Es_Habilitado",
                table: "EstadoCivil",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Si el registro esta habilitado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Usuario_Creacion",
                table: "EstadoCivil",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "El usuario que creo el registro",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Creacion",
                table: "EstadoCivil",
                type: "datetime",
                nullable: false,
                comment: "Fecha de creacion del registro",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Es_Habilitado",
                table: "EstadoCivil",
                type: "bit",
                nullable: false,
                comment: "Si el registro esta habilitado",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "Es_Habilitado1",
                table: "EstadoCivil",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Creacion1",
                table: "EstadoCivil",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Mod",
                table: "EstadoCivil",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Fecha de la ultima modificacion");

            migrationBuilder.AddColumn<string>(
                name: "Usuario_Creacion1",
                table: "EstadoCivil",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario_Mod",
                table: "EstadoCivil",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Ultimo usuario que modifico el registro");
        }
    }
}
