using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class agregoFKEnAsentamiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento");

            migrationBuilder.DropIndex(
                name: "IX_Asentamiento_MunicipioIdMunicipio",
                table: "Asentamiento");

            migrationBuilder.DropColumn(
                name: "MunicipioIdMunicipio",
                table: "Asentamiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento",
                column: "IdMunicipio",
                principalTable: "Municipio",
                principalColumn: "IdMunicipio",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioIdMunicipio",
                table: "Asentamiento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asentamiento_MunicipioIdMunicipio",
                table: "Asentamiento",
                column: "MunicipioIdMunicipio");

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento",
                column: "MunicipioIdMunicipio",
                principalTable: "Municipio",
                principalColumn: "IdMunicipio",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
