using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CambioIndicesNoAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_AsentamientoTipo",
                table: "Asentamiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Estado",
                table: "Municipio");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_EstadoCivil",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Nacionalidad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaCorreoElectronico_CorreoElectronico",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaCorreoElectronico_Persona",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDireccion_Direccion",
                table: "PersonaDireccion");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDireccion_Persona",
                table: "PersonaDireccion");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDocumento_Documento",
                table: "PersonaDocumento");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDocumento_Persona",
                table: "PersonaDocumento");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTelefono_Persona",
                table: "PersonaTelefono");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTelefono_Telefono",
                table: "PersonaTelefono");

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_AsentamientoTipo",
                table: "Asentamiento",
                column: "IdAsentamientoTipo",
                principalTable: "AsentamientoTipo",
                principalColumn: "IdAsentamientoTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento",
                column: "IdMunicipio",
                principalTable: "Municipio",
                principalColumn: "IdMunicipio");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion",
                column: "IdAsentamiento",
                principalTable: "Asentamiento",
                principalColumn: "IdAsentamiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento",
                column: "IdDocumentoTipo",
                principalTable: "DocumentoTipo",
                principalColumn: "IdDocumentoTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Estado",
                table: "Municipio",
                column: "IdEstado",
                principalTable: "Estado",
                principalColumn: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_EstadoCivil",
                table: "Persona",
                column: "IdEstadoCivil",
                principalTable: "EstadoCivil",
                principalColumn: "IdEstadoCivil");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Nacionalidad",
                table: "Persona",
                column: "IdNacionalidad",
                principalTable: "Nacionalidad",
                principalColumn: "IdNacionalidad");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaCorreoElectronico_CorreoElectronico",
                table: "PersonaCorreoElectronico",
                column: "IdCorreoElectronico",
                principalTable: "CorreoElectronico",
                principalColumn: "IdCorreoElectronico");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaCorreoElectronico_Persona",
                table: "PersonaCorreoElectronico",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDireccion_Direccion",
                table: "PersonaDireccion",
                column: "IdDireccion",
                principalTable: "Direccion",
                principalColumn: "IdDireccion");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDireccion_Persona",
                table: "PersonaDireccion",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDocumento_Documento",
                table: "PersonaDocumento",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDocumento_Persona",
                table: "PersonaDocumento",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTelefono_Persona",
                table: "PersonaTelefono",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTelefono_Telefono",
                table: "PersonaTelefono",
                column: "IdTelefono",
                principalTable: "Telefono",
                principalColumn: "IdTelefono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_AsentamientoTipo",
                table: "Asentamiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Estado",
                table: "Municipio");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_EstadoCivil",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Nacionalidad",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaCorreoElectronico_CorreoElectronico",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaCorreoElectronico_Persona",
                table: "PersonaCorreoElectronico");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDireccion_Direccion",
                table: "PersonaDireccion");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDireccion_Persona",
                table: "PersonaDireccion");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDocumento_Documento",
                table: "PersonaDocumento");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaDocumento_Persona",
                table: "PersonaDocumento");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTelefono_Persona",
                table: "PersonaTelefono");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTelefono_Telefono",
                table: "PersonaTelefono");

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_AsentamientoTipo",
                table: "Asentamiento",
                column: "IdAsentamientoTipo",
                principalTable: "AsentamientoTipo",
                principalColumn: "IdAsentamientoTipo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asentamiento_Municipio",
                table: "Asentamiento",
                column: "IdMunicipio",
                principalTable: "Municipio",
                principalColumn: "IdMunicipio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Asentamiento",
                table: "Direccion",
                column: "IdAsentamiento",
                principalTable: "Asentamiento",
                principalColumn: "IdAsentamiento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_DocumentoTipo",
                table: "Documento",
                column: "IdDocumentoTipo",
                principalTable: "DocumentoTipo",
                principalColumn: "IdDocumentoTipo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Estado",
                table: "Municipio",
                column: "IdEstado",
                principalTable: "Estado",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_EstadoCivil",
                table: "Persona",
                column: "IdEstadoCivil",
                principalTable: "EstadoCivil",
                principalColumn: "IdEstadoCivil",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Nacionalidad",
                table: "Persona",
                column: "IdNacionalidad",
                principalTable: "Nacionalidad",
                principalColumn: "IdNacionalidad",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaCorreoElectronico_CorreoElectronico",
                table: "PersonaCorreoElectronico",
                column: "IdCorreoElectronico",
                principalTable: "CorreoElectronico",
                principalColumn: "IdCorreoElectronico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaCorreoElectronico_Persona",
                table: "PersonaCorreoElectronico",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDireccion_Direccion",
                table: "PersonaDireccion",
                column: "IdDireccion",
                principalTable: "Direccion",
                principalColumn: "IdDireccion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDireccion_Persona",
                table: "PersonaDireccion",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDocumento_Documento",
                table: "PersonaDocumento",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaDocumento_Persona",
                table: "PersonaDocumento",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTelefono_Persona",
                table: "PersonaTelefono",
                column: "IdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTelefono_Telefono",
                table: "PersonaTelefono",
                column: "IdTelefono",
                principalTable: "Telefono",
                principalColumn: "IdTelefono",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
