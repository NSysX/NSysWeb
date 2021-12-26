using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Persistence.Migrations
{
    public partial class UltimoTrabajando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsentamientoTipo",
                columns: table => new
                {
                    IdAsentamientoTipo = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico ")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre del tipo de Asentamiento "),
                    Abreviatura = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false, comment: "Abreviatura de la descripcion de tipo de asentamiento"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Ultima Fecha de Modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si esta disponible el registro ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsentamientoTipo", x => x.IdAsentamientoTipo);
                },
                comment: "Los tipos de Asentamientos como Ejido, Colonia , Poblado");

            migrationBuilder.CreateTable(
                name: "CorreoElectronico",
                columns: table => new
                {
                    IdCorreoElectronico = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El Email o Correo electroinico"),
                    TipoCorreo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Tipo de email personal trabajo "),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario Creacion del registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado para trabajar con el, borrado logico")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorreoElectronico", x => x.IdCorreoElectronico);
                },
                comment: "Todos lo Correos Electronicos de personas y Empresas");

            migrationBuilder.CreateTable(
                name: "DocumentoTipo",
                columns: table => new
                {
                    IdDocumentoTipo = table.Column<int>(type: "int", nullable: false, comment: "El identificador unico de registro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus del registro"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre completo del documento "),
                    Abreviatura = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "Abreviatura del documento"),
                    Longitud = table.Column<int>(type: "int", nullable: false, comment: "La longitud de caracteres permitido para la Cadena Unica"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha en que se creo el registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion del registro"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El usuario de la ultima modificacion"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta disponible para trabajar con el")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoTipo", x => x.IdDocumentoTipo);
                },
                comment: "Se capturan los tipos de documentos para que esten disponibles");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false, comment: "id del estado")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "Nombre del estado del pais"),
                    Abreviatura = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false, comment: "Abreviatura de nombre del estado de la republica"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario de la ultima modificacion"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "si esta disponible el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.IdEstado);
                },
                comment: "Estado de paises");

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false, comment: "Id consecutivo ")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus del estado civil"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Descripcion del estado civil"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.IdEstadoCivil);
                },
                comment: "Los Estados Civiles de las Personas");

            migrationBuilder.CreateTable(
                name: "Nacionalidad",
                columns: table => new
                {
                    IdNacionalidad = table.Column<int>(type: "int", nullable: false, comment: "Id unico para el registro")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "El Estatus del Registro"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "concepto de nacionalidad de la persona"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha en que se creo el registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "fecha de la ultima modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "El ultimo Usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "si esta disponible el registro ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidad", x => x.IdNacionalidad);
                },
                comment: "Catalogo de Nacionalidades con su bandera");

            migrationBuilder.CreateTable(
                name: "SysDominioCorreo",
                columns: table => new
                {
                    IdSysDominioCorreo = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico ")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "estatus del registro"),
                    Dominio = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, comment: "Dominio Hotmail.com, Gmail.com, etc.."),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que hizo la ultima modificacion"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro estra disponible, borrado Logico")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysDominioCorreo", x => x.IdSysDominioCorreo);
                },
                comment: "Dominios precapturados para los correos");

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    IdTelefono = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico de la tabla telefono")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus del registro"),
                    TipoTelefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Celular o Fijo"),
                    CodigoPais = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false, comment: "Codigo Telefonico del Pais"),
                    Numero = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false, comment: "Numero telefonico"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Ultima fecha de Modificacion del registro"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado para trabajar")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.IdTelefono);
                },
                comment: "Todos los Telefonos de personas y empresas");

            migrationBuilder.CreateTable(
                name: "Asentamiento",
                columns: table => new
                {
                    IdAsentamiento = table.Column<int>(type: "int", nullable: false, comment: "Consecutivo de Asentamiento")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAsentamientoTipo = table.Column<int>(type: "int", nullable: false, comment: "El id de la tabla TipoAsentamiento "),
                    IdMunicipio = table.Column<int>(type: "int", nullable: false, comment: "id del municipio al que pertenece"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus del registro"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Nombre del asentamiento"),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false, comment: "Codigo Postal"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del Registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario de Creacion del registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Ultima Modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asentamiento", x => x.IdAsentamiento);
                    table.ForeignKey(
                        name: "FK_Asentamiento_AsentamientoTipo",
                        column: x => x.IdAsentamientoTipo,
                        principalTable: "AsentamientoTipo",
                        principalColumn: "IdAsentamientoTipo",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Nombre del asentamiento");

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "int", nullable: false, comment: "El id de la tabla Documento")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDocumentoTipo = table.Column<int>(type: "int", nullable: false, comment: "El identificador unico de la tabla DocumentoTipo"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "algun estatus para el registro"),
                    CodigoUnico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "La cadena unica del documento"),
                    Imagen = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "Imagen del documento"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion de registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Ultima Fecha de modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta disponible para usarlo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.IdDocumento);
                    table.ForeignKey(
                        name: "FK_Documento_DocumentoTipo",
                        column: x => x.IdDocumentoTipo,
                        principalTable: "DocumentoTipo",
                        principalColumn: "IdDocumentoTipo",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Se incluyen todos los documentos que las personas fisicas y morales pueden tener");

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    IdMunicipio = table.Column<int>(type: "int", nullable: false, comment: "id consecutivo de municipio")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstado = table.Column<int>(type: "int", nullable: false, comment: "id que pertenece al estado"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre del Municipio"),
                    Abreviatura = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de Creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el Registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la utlima modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico el registro"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta disponible")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.IdMunicipio);
                    table.ForeignKey(
                        name: "FK_Municipio_Estado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Municipios de Mexico");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false, comment: "id consecutivo de la tabla personas")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNacionalidad = table.Column<int>(type: "int", nullable: false, comment: "id Nacionalidad de la persona"),
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false, comment: "El estado civil de la persona Casado, Divorciado, Soltero, union libre"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus de la Persona "),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Apellido paterno de la persona"),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Apellido materno de la persona"),
                    Nombres = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre o Nombres de la persona"),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false, comment: "Fecha de nacimiento de la persona"),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "M = Masculino , F = Femenino"),
                    Foto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "El path de la foto de la persona"),
                    Notas = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, comment: "Notas importantes de la persona"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la ultima modificacion "),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Ultimo usuario que modifico "),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si el registro esta habilitado ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Persona_EstadoCivil",
                        column: x => x.IdEstadoCivil,
                        principalTable: "EstadoCivil",
                        principalColumn: "IdEstadoCivil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Nacionalidad",
                        column: x => x.IdNacionalidad,
                        principalTable: "Nacionalidad",
                        principalColumn: "IdNacionalidad",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Almacena la informacion de todas las personas");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false, comment: "Id Numerico Consecutivo de direcciones")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAsentamiento = table.Column<int>(type: "int", nullable: false, comment: "el id de la tabla Asentamiento"),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, comment: "Estatus de la direccion"),
                    Calle = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    EntreLaCalle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    YLaCalle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NumeroExterior = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NumeroInterior = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CoordenadasGeo = table.Column<Geometry>(type: "geography", nullable: true, comment: "Coordenadas geograficas , Acepta nulos"),
                    Referencia = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "Referencias para identificar la direccion"),
                    Foto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Foto de la ubicacion"),
                    EsFiscal = table.Column<bool>(type: "bit", nullable: false, comment: "Si la direccion es fiscal para la emision de facturas"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de creacion del registro"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que creo el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la Ultima Modificacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Usuario que hizo la ultima modificacion"),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false, comment: "Si esta disponible el registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Asentamiento",
                        column: x => x.IdAsentamiento,
                        principalTable: "Asentamiento",
                        principalColumn: "IdAsentamiento",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Registra todas las direcciones");

            migrationBuilder.CreateTable(
                name: "PersonaCorreoElectronico",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico del registro de persona "),
                    IdCorreoElectronico = table.Column<int>(type: "int", nullable: false, comment: "Identificador unico de la tabla de Correo Electronico"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PersonaCorreoElectronico_CorreoElectronico",
                        column: x => x.IdCorreoElectronico,
                        principalTable: "CorreoElectronico",
                        principalColumn: "IdCorreoElectronico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaCorreoElectronico_Persona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Los Correos electronicos que tiene una persona");

            migrationBuilder.CreateTable(
                name: "PersonaDocumento",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false, comment: "El idPersona de la tabla Personas"),
                    IdDocumento = table.Column<int>(type: "int", nullable: false, comment: "IdDocumento de la Tabla Documento"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PersonaDocumento_Documento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaDocumento_Persona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "La relacion de los documentos que puede tener una persona");

            migrationBuilder.CreateTable(
                name: "PersonaTelefono",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false, comment: "El identificador de la tabla persona"),
                    IdTelefono = table.Column<int>(type: "int", nullable: false, comment: "El identificador de la tabla telefono"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PersonaTelefono_Persona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaTelefono_Telefono",
                        column: x => x.IdTelefono,
                        principalTable: "Telefono",
                        principalColumn: "IdTelefono",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Los numeros de telefono de las personas");

            migrationBuilder.CreateTable(
                name: "PersonaDireccion",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false, comment: "El id de la tabla de Personas"),
                    IdDireccion = table.Column<int>(type: "int", nullable: false, comment: "El id de la Tabla Direccion"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsHabilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
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
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Las direcciones que tiene una persona");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado",
                table: "Asentamiento",
                columns: new[] { "IdMunicipio", "IdAsentamientoTipo", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Asentamiento_AsentamientoTipo",
                table: "Asentamiento",
                column: "IdAsentamientoTipo");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbre",
                table: "AsentamientoTipo",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAsen",
                table: "AsentamientoTipo",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado1",
                table: "CorreoElectronico",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Direccion_Asentamiento",
                table: "Direccion",
                column: "IdAsentamiento");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado2",
                table: "Documento",
                column: "CodigoUnico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Documento_DocumentoTipo",
                table: "Documento",
                column: "IdDocumentoTipo");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbre1",
                table: "DocumentoTipo",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNom",
                table: "DocumentoTipo",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbre2",
                table: "Estado",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoEsta",
                table: "Estado",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado3",
                table: "EstadoCivil",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoAbre3",
                table: "Municipio",
                column: "Abreviatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNom1",
                table: "Municipio",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Municipio_Estado",
                table: "Municipio",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado4",
                table: "Nacionalidad",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado5",
                table: "Persona",
                columns: new[] { "ApellidoPaterno", "ApellidoMaterno", "Nombres" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Persona_EstadoCivil",
                table: "Persona",
                column: "IdEstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IXFK_Persona_Nacionalidad",
                table: "Persona",
                column: "IdNacionalidad");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado",
                table: "PersonaCorreoElectronico",
                columns: new[] { "IdPersona", "IdCorreoElectronico" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaCorreoElectronico_CorreoElectronico",
                table: "PersonaCorreoElectronico",
                column: "IdCorreoElectronico");

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaCorreoElectronico_Persona",
                table: "PersonaCorreoElectronico",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado",
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
                name: "IX_NoDuplicado",
                table: "PersonaDocumento",
                columns: new[] { "IdPersona", "IdDocumento" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaDocumento_Documento",
                table: "PersonaDocumento",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaDocumento_Persona",
                table: "PersonaDocumento",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado",
                table: "PersonaTelefono",
                columns: new[] { "IdPersona", "IdTelefono" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaTelefono_Persona",
                table: "PersonaTelefono",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IXFK_PersonaTelefono_Telefono",
                table: "PersonaTelefono",
                column: "IdTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado6",
                table: "SysDominioCorreo",
                column: "Dominio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicado7",
                table: "Telefono",
                columns: new[] { "CodigoPais", "Numero" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "PersonaCorreoElectronico");

            migrationBuilder.DropTable(
                name: "PersonaDireccion");

            migrationBuilder.DropTable(
                name: "PersonaDocumento");

            migrationBuilder.DropTable(
                name: "PersonaTelefono");

            migrationBuilder.DropTable(
                name: "SysDominioCorreo");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "CorreoElectronico");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Asentamiento");

            migrationBuilder.DropTable(
                name: "DocumentoTipo");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropTable(
                name: "AsentamientoTipo");
        }
    }
}
