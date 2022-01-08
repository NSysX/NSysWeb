using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class modificacionDelIndiceTelefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicado11",
                table: "Telefono",
                newName: "IX_NoDuplicadoCodigoPaisNumero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_NoDuplicadoCodigoPaisNumero",
                table: "Telefono",
                newName: "IX_NoDuplicado11");
        }
    }
}
