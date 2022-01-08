using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AsentamientoAbreviaturaA8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Abreviatura",
                table: "AsentamientoTipo",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                comment: "Abreviatura de la descripcion de tipo de asentamiento",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldComment: "Abreviatura de la descripcion de tipo de asentamiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Abreviatura",
                table: "AsentamientoTipo",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                comment: "Abreviatura de la descripcion de tipo de asentamiento",
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldUnicode: false,
                oldMaxLength: 8,
                oldComment: "Abreviatura de la descripcion de tipo de asentamiento");
        }
    }
}
