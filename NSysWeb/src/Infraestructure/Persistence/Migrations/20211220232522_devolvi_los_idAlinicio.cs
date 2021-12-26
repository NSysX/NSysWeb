using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class devolvi_los_idAlinicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NacionalidadId",
                table: "Persona",
                newName: "IdNacionalidad");

            migrationBuilder.RenameColumn(
                name: "EstadoCivilId",
                table: "Persona",
                newName: "IdEstadoCivil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdNacionalidad",
                table: "Persona",
                newName: "NacionalidadId");

            migrationBuilder.RenameColumn(
                name: "IdEstadoCivil",
                table: "Persona",
                newName: "EstadoCivilId");
        }
    }
}
