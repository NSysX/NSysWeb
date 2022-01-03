using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EstadoSeAgregoClave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clave",
                table: "Estado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Clave del Estado");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoClave",
                table: "Estado",
                column: "Clave",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NoDuplicadoClave",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "Clave",
                table: "Estado");
        }
    }
}
