using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class modificacionMuchosAMuchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPersona",
                table: "PersonaDocumento",
                type: "int",
                nullable: false,
                comment: "El IdPersona de la tabla Personas",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "El idPersona de la tabla Personas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPersona",
                table: "PersonaDocumento",
                type: "int",
                nullable: false,
                comment: "El idPersona de la tabla Personas",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "El IdPersona de la tabla Personas");
        }
    }
}
