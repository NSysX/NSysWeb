using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class validadorDireccionYCambioImgAFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Persona",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                comment: "El path de la foto de la persona",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldComment: "El path de la foto de la persona");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Documento",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Foto del documento");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Direccion",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                comment: "Foto de la ubicacion",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldComment: "Foto de la ubicacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Persona",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                comment: "El path de la foto de la persona",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldComment: "El path de la foto de la persona");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Documento",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "Imagen del documento");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Direccion",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                comment: "Foto de la ubicacion",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldComment: "Foto de la ubicacion");
        }
    }
}
