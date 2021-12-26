using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class modificacionDeDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento");

            migrationBuilder.DropIndex(
                name: "IXFK_Documento_DocumentoTipo",
                table: "Documento");

            migrationBuilder.DropColumn(
                name: "IdDocumentoTipo",
                table: "Documento");

            migrationBuilder.AddColumn<int>(
                name: "DocumentoTipoId",
                table: "Documento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "El Identificador unico de la tabla DocumentoTipo");

            migrationBuilder.CreateIndex(
                name: "IXFK_Documento_DocumentoTipo",
                table: "Documento",
                column: "DocumentoTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento",
                column: "DocumentoTipoId",
                principalTable: "DocumentoTipo",
                principalColumn: "IdDocumentoTipo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento");

            migrationBuilder.DropIndex(
                name: "IXFK_Documento_DocumentoTipo",
                table: "Documento");

            migrationBuilder.DropColumn(
                name: "DocumentoTipoId",
                table: "Documento");

            migrationBuilder.AddColumn<int>(
                name: "IdDocumentoTipo",
                table: "Documento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "El identificador unico de la tabla DocumentoTipo");

            migrationBuilder.CreateIndex(
                name: "IXFK_Documento_DocumentoTipo",
                table: "Documento",
                column: "IdDocumentoTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento",
                column: "IdDocumentoTipo",
                principalTable: "DocumentoTipo",
                principalColumn: "IdDocumentoTipo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
