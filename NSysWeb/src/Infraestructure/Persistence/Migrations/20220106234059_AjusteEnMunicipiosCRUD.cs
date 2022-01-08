using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AjusteEnMunicipiosCRUD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoNomMuni",
                table: "Municipio");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoIdEstadoIdMuni",
                table: "Municipio",
                newName: "IX_NoDuplicadoIdEstadoClave");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "Municipio",
                type: "int",
                nullable: false,
                comment: "Id que pertenece al estado",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "id que pertenece al estado");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNombreEstado",
                table: "Municipio",
                columns: new[] { "Nombre", "IdEstado" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoNombreEstado",
                table: "Municipio");

            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoIdEstadoClave",
                table: "Municipio",
                newName: "IX_NoDuplicadoIdEstadoIdMuni");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "Municipio",
                type: "int",
                nullable: false,
                comment: "id que pertenece al estado",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Id que pertenece al estado");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNomMuni",
                table: "Municipio",
                column: "Nombre",
                unique: true);
        }
    }
}
