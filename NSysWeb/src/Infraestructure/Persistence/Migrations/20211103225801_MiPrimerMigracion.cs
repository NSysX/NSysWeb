using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Persistence.Migrations
{
    public partial class MiPrimerMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false, comment: "id del estado")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario de la ultima modificacion"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "si esta disponible el registro"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "Nombre del estado del pais"),
                    Abreviatura = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false, comment: "Abreviatura de nombre del estado de la republica")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idEstado);
                },
                comment: "Estado de paises");

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false, comment: "Id consecutivo")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El usuario que creo el registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus del estado civil"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Descripcion del estado civil"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Fecha_Creacion1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario_Creacion1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario_Modificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Es_Habilitado1 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.IdEstadoCivil);
                },
                comment: "Los estados Civiles de las Personas");

            migrationBuilder.CreateTable(
                name: "Nacionalidad",
                columns: table => new
                {
                    IdNacionalidad = table.Column<int>(type: "int", nullable: false, comment: "Id unico para el registro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha en que se creo el registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "fecha de la ultima modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El ultimo Usuario que modifico el registro"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "si esta disponible el registro "),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "El Estatus del Registro"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "concepto de nacionalidad de la persona")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidad", x => x.IdNacionalidad);
                },
                comment: "Catalogo de Nacionalidades con su bandera");

            migrationBuilder.CreateTable(
                name: "TipoAsentamiento",
                columns: table => new
                {
                    idTipoAsentamiento = table.Column<int>(type: "int", nullable: false, comment: "Id Consecutivo")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    Fecha_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Ultima Fecha de Modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si esta disponible el registro "),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre del tipo de Asentamiento "),
                    Abreviatura = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, comment: "Abreviatura de la descripcion de tipo de asentamiento")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAsentamiento", x => x.idTipoAsentamiento);
                },
                comment: "Los tipos de Asentamientos como Ejido, Colonia , Poblado");

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    idMunicipio = table.Column<int>(type: "int", nullable: false, comment: "id consecutivo de municipio")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el Registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la utlima modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta disponible"),
                    idEstado = table.Column<int>(type: "int", nullable: false, comment: "id que pertenece al estado"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre del Municipio"),
                    Abreviatura = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.idMunicipio);
                    table.ForeignKey(
                        name: "FK_Municipio_Estado",
                        column: x => x.idEstado,
                        principalTable: "Estado",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Municipios de Mexico");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false, comment: "id consecutivo de la tabla personas")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Creacion del registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion "),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico "),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado "),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus de la Persona "),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Apellido paterno de la persona"),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Apellido materno de la persona"),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre o Nombres de la persona"),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false, comment: "Fecha de nacimiento de la persona"),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "M = Masculino , F = Femenino"),
                    Foto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "El path de la foto de la persona"),
                    idNacionalidad = table.Column<int>(type: "int", nullable: false, comment: "id Nacionalidad de la persona"),
                    Curp = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: false, comment: "Clave Unica de Resgitro de Poblacion contiene 18 caracteres"),
                    Nss = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false, comment: "Numero de Seguro Social tiene 11 caracteres"),
                    idEstadoCivil = table.Column<int>(type: "int", nullable: true, comment: "El estado civil de la persona Casado, Divorciado, Soltero, union libre")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idPersona);
                    table.ForeignKey(
                        name: "FK_Persona_EstadoCivil",
                        column: x => x.idEstadoCivil,
                        principalTable: "EstadoCivil",
                        principalColumn: "IdEstadoCivil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Nacionalidad",
                        column: x => x.idNacionalidad,
                        principalTable: "Nacionalidad",
                        principalColumn: "IdNacionalidad",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Almacena la informacion de todas las personas");

            migrationBuilder.CreateTable(
                name: "Asentamiento",
                columns: table => new
                {
                    idAsentamiento = table.Column<int>(type: "int", nullable: false, comment: "Consecutivo de Asentamiento")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del Registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario de Creacion del registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Ultima Modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado "),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    idTipoAsentamiento = table.Column<int>(type: "int", nullable: false, comment: "El id de la tabla TipoAsentamiento "),
                    idMunicipio = table.Column<int>(type: "int", nullable: false, comment: "id del municipio al que pertenece"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Nombre del asentamiento"),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false, comment: "Codigo Postal")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asentamiento", x => x.idAsentamiento);
                    table.ForeignKey(
                        name: "FK_Asentamiento_Municipio",
                        column: x => x.idMunicipio,
                        principalTable: "Municipio",
                        principalColumn: "idMunicipio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asentamiento_TipoAsentamiento",
                        column: x => x.idTipoAsentamiento,
                        principalTable: "TipoAsentamiento",
                        principalColumn: "idTipoAsentamiento",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Nombre del asentamiento");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false, comment: "Id Numerico Consecutivo de direcciones")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    Usuario_Creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    Fecha_Mod = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Ultima Modificacion"),
                    Usuario_Mod = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que hizo la ultima modificacion"),
                    Es_Habilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si esta disponible el registro"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus de la direccion"),
                    Calle = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    NumeroExterior = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NumeroInterior = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    idAsentamiento = table.Column<int>(type: "int", nullable: false, comment: "el id de la tabla Asentamiento"),
                    CoordenadasGeo = table.Column<Geometry>(type: "geography", nullable: false, comment: "Coordenadas geograficas "),
                    Referencia = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "Referencias para identificar la direccion"),
                    Foto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Foto de la ubicacion"),
                    EsFiscal = table.Column<bool>(type: "bit", nullable: false, comment: "Si la direccion es fiscal para la emision de facturas")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Asentamiento",
                        column: x => x.idAsentamiento,
                        principalTable: "Asentamiento",
                        principalColumn: "idAsentamiento",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Registra todas las direcciones");

            migrationBuilder.CreateTable(
                name: "PersonaDireccion",
                columns: table => new
                {
                    idPersonaDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersona = table.Column<int>(type: "int", nullable: false, comment: "El id de la Tabla de Personas"),
                    IdDireccion = table.Column<int>(type: "int", nullable: false, comment: "El id de la Tabla Direccion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaDireccion", x => x.idPersonaDireccion);
                    table.ForeignKey(
                        name: "FK_PersonaDireccion_Direccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaDireccion_Persona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Las direcciones que tiene una persona");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado",
                table: "Asentamiento",
                columns: new[] { "idMunicipio", "idTipoAsentamiento", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Asentamiento_Municipio",
                table: "Asentamiento",
                column: "idMunicipio");

            migrationBuilder.CreateIndex(
                name: "IXFK_Asentamiento_TipoAsentamiento",
                table: "Asentamiento",
                column: "idTipoAsentamiento");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicados",
                table: "Direccion",
                columns: new[] { "Calle", "NumeroExterior", "NumeroInterior", "idAsentamiento" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Direccion_Asentamiento",
                table: "Direccion",
                column: "idAsentamiento");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbrev",
                table: "Estado",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNombre",
                table: "Estado",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado1",
                table: "EstadoCivil",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbrevi",
                table: "Municipio",
                column: "Abreviatura",
                unique: true,
                filter: "[Abreviatura] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNomXEdo",
                table: "Municipio",
                columns: new[] { "idEstado", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Municipio_Estado",
                table: "Municipio",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado2",
                table: "Persona",
                columns: new[] { "ApellidoPaterno", "ApellidoMaterno", "Nombres" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Persona_EstadoCivil",
                table: "Persona",
                column: "idEstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IXFK_Persona_Nacionalidad",
                table: "Persona",
                column: "idNacionalidad");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado3",
                table: "PersonaDireccion",
                columns: new[] { "IdPersona", "IdDireccion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaDireccion_Direccion",
                table: "PersonaDireccion",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaDireccion_Persona",
                table: "PersonaDireccion",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbrevia",
                table: "TipoAsentamiento",
                column: "Abreviatura",
                unique: true,
                filter: "[Abreviatura] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNombre1",
                table: "TipoAsentamiento",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaDireccion");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Asentamiento");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "TipoAsentamiento");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
