using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AgegueIndiceCompuestoEnMpioEstadoCLave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clave",
                table: "Municipio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Clave unica de municipio por estado");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoIdEstadoIdMuni",
                table: "Municipio",
                columns: new[] { "IdEstado", "Clave" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoIdEstadoIdMuni",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "Clave",
                table: "Municipio");
        }
    }
}
