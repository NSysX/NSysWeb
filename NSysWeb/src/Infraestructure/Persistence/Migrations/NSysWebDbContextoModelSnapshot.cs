﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Persistence.Contexts;

namespace Persistence.Migrations
{
    [DbContext(typeof(NSysWebDbContexto))]
    partial class NSysWebDbContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Asentamiento", b =>
                {
                    b.Property<int>("IdAsentamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idAsentamiento")
                        .HasComment("Consecutivo de Asentamiento")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo_Postal")
                        .HasColumnType("int")
                        .HasComment("Codigo Postal");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("Si el registro esta habilitado ");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de Creacion del Registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Fecha de la Ultima Modificacion");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int")
                        .HasColumnName("idMunicipio")
                        .HasComment("id del municipio al que pertenece");

                    b.Property<int>("IdTipoAsentamiento")
                        .HasColumnType("int")
                        .HasColumnName("idTipoAsentamiento")
                        .HasComment("El id de la tabla TipoAsentamiento ");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasComment("Nombre del asentamiento");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario de Creacion del registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Ultimo usuario que modifico el registro");

                    b.HasKey("IdAsentamiento");

                    b.HasIndex(new[] { "IdMunicipio" }, "IXFK_Asentamiento_Municipio");

                    b.HasIndex(new[] { "IdTipoAsentamiento" }, "IXFK_Asentamiento_TipoAsentamiento");

                    b.HasIndex(new[] { "IdMunicipio", "IdTipoAsentamiento", "Nombre" }, "IX_NoDuplicado")
                        .IsUnique();

                    b.ToTable("Asentamiento");

                    b
                        .HasComment("Nombre del asentamiento");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Property<int>("IdDireccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Id Numerico Consecutivo de direcciones")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<Geometry>("Coordenadas_Geo")
                        .IsRequired()
                        .HasColumnType("geography")
                        .HasComment("Coordenadas geograficas ");

                    b.Property<bool>("Es_Fiscal")
                        .HasColumnType("bit")
                        .HasComment("Si la direccion es fiscal para la emision de facturas");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("Si esta disponible el registro");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasComment("Estatus de la direccion");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Fecha de la Ultima Modificacion");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasComment("Foto de la ubicacion");

                    b.Property<int>("IdAsentamiento")
                        .HasColumnType("int")
                        .HasColumnName("idAsentamiento")
                        .HasComment("el id de la tabla Asentamiento");

                    b.Property<string>("Numero_Exterior")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Numero_Interior")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasComment("Referencias para identificar la direccion");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Usuario que hizo la ultima modificacion");

                    b.HasKey("IdDireccion");

                    b.HasIndex(new[] { "IdAsentamiento" }, "IXFK_Direccion_Asentamiento");

                    b.HasIndex(new[] { "Calle", "Numero_Exterior", "Numero_Interior", "IdAsentamiento" }, "IX_NoDuplicados")
                        .IsUnique();

                    b.ToTable("Direccion");

                    b
                        .HasComment("Registra todas las direcciones");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idEstado")
                        .HasComment("id del estado")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)")
                        .HasComment("Abreviatura de nombre del estado de la republica");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("si esta disponible el registro");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Fecha de la ultima modificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasComment("Nombre del estado del pais");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Usuario de la ultima modificacion");

                    b.HasKey("IdEstado");

                    b.HasIndex(new[] { "Abreviatura" }, "IX_NoDuplicadoAbrev")
                        .IsUnique();

                    b.HasIndex(new[] { "Nombre" }, "IX_NoDuplicadoNombre")
                        .IsUnique();

                    b.ToTable("Estado");

                    b
                        .HasComment("Estado de paises");
                });

            modelBuilder.Entity("Domain.Entities.EstadoCivil", b =>
                {
                    b.Property<int>("IdEstadoCivil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Id consecutivo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Descripcion del estado civil");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("si esta disponible el registro");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasComment("Estatus del estado civil");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de creacion del registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Fecha de la ultima modificacion");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Usuario de la ultima modificacion");

                    b.HasKey("IdEstadoCivil");

                    b.HasIndex(new[] { "Descripcion" }, "IX_NoDuplicado")
                        .IsUnique()
                        .HasDatabaseName("IX_NoDuplicado1");

                    b.ToTable("EstadoCivil");

                    b
                        .HasComment("Los estados Civiles de las Personas");
                });

            modelBuilder.Entity("Domain.Entities.Municipio", b =>
                {
                    b.Property<int>("IdMunicipio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idMunicipio")
                        .HasComment("id consecutivo de municipio")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("Si el registro esta disponible");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de Creacion del registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Fecha de la utlima modificacion");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int")
                        .HasColumnName("idEstado")
                        .HasComment("id que pertenece al estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nombre del Municipio");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el Registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Ultimo usuario que modifico el registro");

                    b.HasKey("IdMunicipio");

                    b.HasIndex(new[] { "IdEstado" }, "IXFK_Municipio_Estado");

                    b.HasIndex(new[] { "Abreviatura" }, "IX_NoDuplicadoAbrevi")
                        .IsUnique()
                        .HasFilter("[Abreviatura] IS NOT NULL");

                    b.HasIndex(new[] { "IdEstado", "Nombre" }, "IX_NoDuplicadoNomXEdo")
                        .IsUnique();

                    b.ToTable("Municipio");

                    b
                        .HasComment("Municipios de Mexico");
                });

            modelBuilder.Entity("Domain.Entities.Nacionalidad", b =>
                {
                    b.Property<int>("IdNacionalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Id unico para el registro")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("si esta disponible el registro ");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasComment("El Estatus del Registro");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha en que se creo el registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("fecha de la ultima modificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre de nacionalidad de la persona");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("El ultimo Usuario que modifico el registro");

                    b.HasKey("IdNacionalidad");

                    b.ToTable("Nacionalidad");

                    b
                        .HasComment("Catalogo de Nacionalidades con su bandera");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPersona")
                        .HasComment("id consecutivo de la tabla personas")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_Materno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Apellido materno de la persona");

                    b.Property<string>("Apellido_Paterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Apellido paterno de la persona");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasMaxLength(18)
                        .IsUnicode(false)
                        .HasColumnType("varchar(18)")
                        .HasComment("Clave Unica de Resgitro de Poblacion contiene 18 caracteres");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("Si el registro esta habilitado ");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasComment("Estatus de la Persona ");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de la Creacion del registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Fecha de la ultima modificacion ");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("date")
                        .HasComment("Fecha de nacimiento de la persona");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasComment("El path de la foto de la persona");

                    b.Property<int?>("IdEstadoCivil")
                        .HasColumnType("int")
                        .HasColumnName("idEstadoCivil")
                        .HasComment("El estado civil de la persona Casado, Divorciado, Soltero, union libre");

                    b.Property<int>("IdNacionalidad")
                        .HasColumnType("int")
                        .HasColumnName("idNacionalidad")
                        .HasComment("id Nacionalidad de la persona");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nombre o Nombres de la persona");

                    b.Property<string>("Nss")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasComment("Numero de Seguro Social tiene 11 caracteres");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasComment("M = Masculino , F = Femenino");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Ultimo usuario que modifico ");

                    b.HasKey("IdPersona");

                    b.HasIndex(new[] { "IdEstadoCivil" }, "IXFK_Persona_EstadoCivil");

                    b.HasIndex(new[] { "IdNacionalidad" }, "IXFK_Persona_Nacionalidad");

                    b.HasIndex(new[] { "Apellido_Paterno", "Apellido_Materno", "Nombres" }, "IX_NoDuplicado")
                        .IsUnique()
                        .HasDatabaseName("IX_NoDuplicado2");

                    b.ToTable("Persona");

                    b
                        .HasComment("Almacena la informacion de todas las personas");
                });

            modelBuilder.Entity("Domain.Entities.PersonaDireccion", b =>
                {
                    b.Property<int>("IdPersonaDireccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPersonaDireccion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDireccion")
                        .HasColumnType("int")
                        .HasComment("El id de la Tabla Direccion");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int")
                        .HasComment("El id de la Tabla de Personas");

                    b.HasKey("IdPersonaDireccion");

                    b.HasIndex(new[] { "IdDireccion" }, "IXFK_PersonaDireccion_Direccion");

                    b.HasIndex(new[] { "IdPersona" }, "IXFK_PersonaDireccion_Persona");

                    b.HasIndex(new[] { "IdPersona", "IdDireccion" }, "IX_NoDuplicado")
                        .IsUnique()
                        .HasDatabaseName("IX_NoDuplicado3");

                    b.ToTable("PersonaDireccion");

                    b
                        .HasComment("Las direcciones que tiene una persona");
                });

            modelBuilder.Entity("Domain.Entities.TipoAsentamiento", b =>
                {
                    b.Property<int>("IdTipoAsentamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoAsentamiento")
                        .HasComment("Id Consecutivo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Abreviatura de la descripcion de tipo de asentamiento");

                    b.Property<bool>("Es_Habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Es_Habilitado")
                        .HasComment("Si esta disponible el registro ");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Creacion")
                        .HasComment("Fecha de Creacion del registro");

                    b.Property<DateTime>("Fecha_Modificacion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha_Modificacion")
                        .HasComment("Ultima Fecha de Modificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nombre del tipo de Asentamiento ");

                    b.Property<string>("Usuario_Creacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Creacion")
                        .HasComment("Usuario que creo el registro");

                    b.Property<string>("Usuario_Modificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Usuario_Modificacion")
                        .HasComment("Ultimo usuario que modifico el registro");

                    b.HasKey("IdTipoAsentamiento");

                    b.HasIndex(new[] { "Abreviatura" }, "IX_NoDuplicadoAbrevia")
                        .IsUnique()
                        .HasFilter("[Abreviatura] IS NOT NULL");

                    b.HasIndex(new[] { "Nombre" }, "IX_NoDuplicadoNombre")
                        .IsUnique()
                        .HasDatabaseName("IX_NoDuplicadoNombre1");

                    b.ToTable("TipoAsentamiento");

                    b
                        .HasComment("Los tipos de Asentamientos como Ejido, Colonia , Poblado");
                });

            modelBuilder.Entity("Domain.Entities.Asentamiento", b =>
                {
                    b.HasOne("Domain.Entities.Municipio", "IdMunicipioNavigation")
                        .WithMany("Asentamientos")
                        .HasForeignKey("IdMunicipio")
                        .HasConstraintName("FK_Asentamiento_Municipio")
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoAsentamiento", "IdTipoAsentamientoNavigation")
                        .WithMany("Asentamientos")
                        .HasForeignKey("IdTipoAsentamiento")
                        .HasConstraintName("FK_Asentamiento_TipoAsentamiento")
                        .IsRequired();

                    b.Navigation("IdMunicipioNavigation");

                    b.Navigation("IdTipoAsentamientoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.HasOne("Domain.Entities.Asentamiento", "IdAsentamientoNavigation")
                        .WithMany("Direccions")
                        .HasForeignKey("IdAsentamiento")
                        .HasConstraintName("FK_Direccion_Asentamiento")
                        .IsRequired();

                    b.Navigation("IdAsentamientoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Municipio", b =>
                {
                    b.HasOne("Domain.Entities.Estado", "IdEstadoNavigation")
                        .WithMany("Municipios")
                        .HasForeignKey("IdEstado")
                        .HasConstraintName("FK_Municipio_Estado")
                        .IsRequired();

                    b.Navigation("IdEstadoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.HasOne("Domain.Entities.EstadoCivil", "IdEstadoCivilNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdEstadoCivil")
                        .HasConstraintName("FK_Persona_EstadoCivil");

                    b.HasOne("Domain.Entities.Nacionalidad", "IdNacionalidadNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdNacionalidad")
                        .HasConstraintName("FK_Persona_Nacionalidad")
                        .IsRequired();

                    b.Navigation("IdEstadoCivilNavigation");

                    b.Navigation("IdNacionalidadNavigation");
                });

            modelBuilder.Entity("Domain.Entities.PersonaDireccion", b =>
                {
                    b.HasOne("Domain.Entities.Direccion", "IdDireccionNavigation")
                        .WithMany("PersonaDireccions")
                        .HasForeignKey("IdDireccion")
                        .HasConstraintName("FK_PersonaDireccion_Direccion")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", "IdPersonaNavigation")
                        .WithMany("PersonaDireccions")
                        .HasForeignKey("IdPersona")
                        .HasConstraintName("FK_PersonaDireccion_Persona")
                        .IsRequired();

                    b.Navigation("IdDireccionNavigation");

                    b.Navigation("IdPersonaNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Asentamiento", b =>
                {
                    b.Navigation("Direccions");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Navigation("PersonaDireccions");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("Domain.Entities.EstadoCivil", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Municipio", b =>
                {
                    b.Navigation("Asentamientos");
                });

            modelBuilder.Entity("Domain.Entities.Nacionalidad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("PersonaDireccions");
                });

            modelBuilder.Entity("Domain.Entities.TipoAsentamiento", b =>
                {
                    b.Navigation("Asentamientos");
                });
#pragma warning restore 612, 618
        }
    }
}