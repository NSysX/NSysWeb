using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ModificacionesHastaDireccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IXFK_Direccion_Asentamiento",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "IdAsentamiento",
                table: "Direccion");

            migrationBuilder.AddColumn<int>(
                name: "AsentamientoId",
                table: "Direccion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "El id de la tabla Asentamiento");

            migrationBuilder.CreateIndex(
                name: "IXFK_Direccion_Asentamiento",
                table: "Direccion",
                column: "AsentamientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion",
                column: "AsentamientoId",
                principalTable: "Asentamiento",
                principalColumn: "IdAsentamiento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion");

            migrationBuilder.DropIndex(
                name: "IXFK_Direccion_Asentamiento",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "AsentamientoId",
                table: "Direccion");

            migrationBuilder.AddColumn<int>(
                name: "IdAsentamiento",
                table: "Direccion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "el id de la tabla Asentamiento");

            migrationBuilder.CreateIndex(
                name: "IXFK_Direccion_Asentamiento",
                table: "Direccion",
                column: "IdAsentamiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion",
                column: "IdAsentamiento",
                principalTable: "Asentamiento",
                principalColumn: "IdAsentamiento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
