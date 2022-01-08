using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CreacionDeTablaPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaisIdPais",
                table: "Estado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus del registro"),
                    Nombre = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false, comment: "Nombre del Pais"),
                    Abreviatura = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false, comment: "Abreviatura del nombre del Pais"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha en que se creo el registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion del registro"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El usuario de la ultima modificacion"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta disponible para trabajar con el")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.IdPais);
                },
                comment: "Catalogo de Paises");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisIdPais",
                table: "Estado",
                column: "PaisIdPais");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbrevPais",
                table: "Pais",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNombrePais",
                table: "Pais",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Pais_PaisIdPais",
                table: "Estado",
                column: "PaisIdPais",
                principalTable: "Pais",
                principalColumn: "IdPais",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Pais_PaisIdPais",
                table: "Estado");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_Estado_PaisIdPais",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "PaisIdPais",
                table: "Estado");
        }
    }
}
