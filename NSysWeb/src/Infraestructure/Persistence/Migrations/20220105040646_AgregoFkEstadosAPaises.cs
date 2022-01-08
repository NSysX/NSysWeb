using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AgregoFkEstadosAPaises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Pais_PaisIdPais",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Estado_PaisIdPais",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "PaisIdPais",
                table: "Estado");

            migrationBuilder.AddColumn<int>(
                name: "IdPais",
                table: "Estado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Id al pais que pertenece");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_IdPais",
                table: "Estado",
                column: "IdPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Pais",
                table: "Estado",
                column: "IdPais",
                principalTable: "Pais",
                principalColumn: "IdPais",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Pais",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Estado_IdPais",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "Estado");

            migrationBuilder.AddColumn<int>(
                name: "PaisIdPais",
                table: "Estado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisIdPais",
                table: "Estado",
                column: "PaisIdPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Pais_PaisIdPais",
                table: "Estado",
                column: "PaisIdPais",
                principalTable: "Pais",
                principalColumn: "IdPais",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
