using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class DeCharAVarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Pais",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                comment: "Nombre del Pais",
                oldClrType: typeof(string),
                oldType: "char(50)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 50,
                oldComment: "Nombre del Pais");

            migrationBuilder.AlterColumn<string>(
                name: "Abreviatura",
                table: "Pais",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                comment: "Abreviatura del nombre del Pais",
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 5,
                oldComment: "Abreviatura del nombre del Pais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Pais",
                type: "char(50)",
                unicode: false,
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                comment: "Nombre del Pais",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldComment: "Nombre del Pais");

            migrationBuilder.AlterColumn<string>(
                name: "Abreviatura",
                table: "Pais",
                type: "char(5)",
                unicode: false,
                fixedLength: true,
                maxLength: 5,
                nullable: false,
                comment: "Abreviatura del nombre del Pais",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldComment: "Abreviatura del nombre del Pais");
        }
    }
}
