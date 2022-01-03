using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AgregueAbreviaturasEnEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoAbre2",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "Estado");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoAbre3",
                table: "Municipio",
                newName: "IX_NoDuplicadoAbre2");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoEsta",
                table: "Estado",
                newName: "IX_NoDuplicadoNombre");

            migrationBuilder.AddColumn<string>(
                name: "RenapoAbrev",
                table: "Estado",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                comment: "Abreviatura de nombre segun Registro de Poblacion (RENAPO)");

            migrationBuilder.AddColumn<string>(
                name: "TresDigitosAbrev",
                table: "Estado",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "Abreviatura de nombre a Tres Digitos");

            migrationBuilder.AddColumn<string>(
                name: "VariableAbrev",
                table: "Estado",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Abreviatura de nombre de tipo Variable");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoRenapoAbrev",
                table: "Estado",
                column: "RenapoAbrev",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoTresDigitosAbrev",
                table: "Estado",
                column: "TresDigitosAbrev",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoVariableAbrev",
                table: "Estado",
                column: "VariableAbrev",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoRenapoAbrev",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoTresDigitosAbrev",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoVariableAbrev",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "RenapoAbrev",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "TresDigitosAbrev",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "VariableAbrev",
                table: "Estado");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoAbre2",
                table: "Municipio",
                newName: "IX_NoDuplicadoAbre3");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoNombre",
                table: "Estado",
                newName: "IX_NoDuplicadoEsta");

            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "Estado",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                comment: "Abreviatura de nombre del estado de la republica");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbre2",
                table: "Estado",
                column: "Abreviatura",
                unique: true);
        }
    }
}
