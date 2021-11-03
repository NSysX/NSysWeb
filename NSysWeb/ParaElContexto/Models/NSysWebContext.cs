using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ParaElContexto.Models
{
    public partial class NSysWebContext : DbContext
    {
        public NSysWebContext()
        {
        }

        public NSysWebContext(DbContextOptions<NSysWebContext> options) // hayq ue inyectar como  dependencia el IDateTime
            : base(options)
        {
            // Se agrega esta linea para que no rastree el tracking (Comportamiento de Seguimiento)
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<Asentamiento> Asentamientos { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; }
        public virtual DbSet<TipoAsentamiento> TipoAsentamientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\DEV;DataBase=NSysWeb;UID=sa;PWD=123456", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asentamiento>(entity =>
            {
                entity.HasKey(e => e.IdAsentamiento);

                entity.ToTable("Asentamiento");

                entity.HasComment("Nombre del asentamiento");

                entity.HasIndex(e => e.IdMunicipio, "IXFK_Asentamiento_Municipio");

                entity.HasIndex(e => e.IdTipoAsentamiento, "IXFK_Asentamiento_TipoAsentamiento");

                entity.HasIndex(e => new { e.IdMunicipio, e.IdTipoAsentamiento, e.Nombre }, "IX_NoDuplicado")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
                    .IsUnique();

                entity.Property(e => e.IdAsentamiento)
                    .HasColumnName("idAsentamiento")
                    .HasComment("Consecutivo de Asentamiento");

                entity.Property(e => e.Codigo).HasComment("Codigo del registro para el usuario");

                entity.Property(e => e.CodigoPostal).HasComment("Codigo Postal");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("Si el registro esta habilitado ");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de Creacion del Registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Fecha de la Ultima Modificacion");

                entity.Property(e => e.IdMunicipio)
                    .HasColumnName("idMunicipio")
                    .HasComment("id del municipio al que pertenece");

                entity.Property(e => e.IdTipoAsentamiento)
                    .HasColumnName("idTipoAsentamiento")
                    .HasComment("El id de la tabla TipoAsentamiento ");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre del asentamiento");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario de Creacion del registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Ultimo usuario que modifico el registro");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Asentamientos)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asentamiento_Municipio");

                entity.HasOne(d => d.IdTipoAsentamientoNavigation)
                    .WithMany(p => p.Asentamientos)
                    .HasForeignKey(d => d.IdTipoAsentamiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asentamiento_TipoAsentamiento");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);

                entity.ToTable("Direccion");

                entity.HasComment("Registra todas las direcciones");

                entity.HasIndex(e => e.IdAsentamiento, "IXFK_Direccion_Asentamiento");

                entity.HasIndex(e => new { e.Calle, e.NumeroExterior, e.NumeroInterior, e.IdAsentamiento }, "IX_NoDuplicados")
                    .IsUnique();

                entity.Property(e => e.IdDireccion).HasComment("Id Numerico Consecutivo de direcciones");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CoordenadasGeo)
                    .IsRequired()
                    .HasComment("Coordenadas geograficas ");

                entity.Property(e => e.EsFiscal).HasComment("Si la direccion es fiscal para la emision de facturas");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("Si esta disponible el registro");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Estatus de la direccion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de creacion del registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Fecha de la Ultima Modificacion");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Foto de la ubicacion");

                entity.Property(e => e.IdAsentamiento)
                    .HasColumnName("idAsentamiento")
                    .HasComment("el id de la tabla Asentamiento");

                entity.Property(e => e.NumeroExterior)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroInterior)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("Referencias para identificar la direccion");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario que creo el registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Usuario que hizo la ultima modificacion");

                entity.HasOne(d => d.IdAsentamientoNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.IdAsentamiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Direccion_Asentamiento");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("Estado");

                entity.HasComment("Estado de paises");

                entity.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrev")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
                    .IsUnique();

                entity.HasIndex(e => e.Nombre, "IX_NoDuplicadoNombre")
                    .IsUnique();

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasComment("id del estado");

                entity.Property(e => e.Abreviatura)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasComment("Abreviatura de nombre del estado de la republica");

                entity.Property(e => e.Codigo).HasComment("codigo consecutivo para no mostrar el id usuario");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("si esta disponible el registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de creacion del registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Fecha de la ultima modificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Nombre del estado del pais");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario que creo el registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Usuario de la ultima modificacion");
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCivil);

                entity.ToTable("EstadoCivil");

                entity.HasComment("Los estados Civiles de las Personas");

                entity.HasIndex(e => e.Descripcion, "IX_NoDuplicado")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
                    .IsUnique();

                entity.Property(e => e.IdEstadoCivil).HasComment("Id consecutivo ");

                entity.Property(e => e.Codigo).HasComment("Codigo consecutivo visible a usuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Descripcion del estado civil");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("Si el registro esta habilitado");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Estatus del estado civil");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de creacion del registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Fecha de la ultima modificacion");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("El usuario que creo el registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Ultimo usuario que modifico el registro");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio);

                entity.ToTable("Municipio");

                entity.HasComment("Municipios de Mexico");

                entity.HasIndex(e => e.IdEstado, "IXFK_Municipio_Estado");

                entity.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrevi")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdEstado, e.Nombre }, "IX_NoDuplicadoNomXEdo")
                    .IsUnique();

                entity.Property(e => e.IdMunicipio)
                    .HasColumnName("idMunicipio")
                    .HasComment("id consecutivo de municipio");

                entity.Property(e => e.Abreviatura)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo).HasComment("Codigo visible al usuario");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("Si el registro esta disponible");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de Creacion del registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Fecha de la utlima modificacion");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasComment("id que pertenece al estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombre del Municipio");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario que creo el Registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Ultimo usuario que modifico el registro");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Estado");
            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.HasKey(e => e.IdNacionalidad);

                entity.ToTable("Nacionalidad");

                entity.HasComment("Catalogo de Nacionalidades con su bandera");

                entity.Property(e => e.IdNacionalidad).HasComment("Id unico para el registro");

                entity.Property(e => e.Codigo).HasComment("Codigo numerico consecutivo visual para el usuario");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("si esta disponible el registro ");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("El Estatus del Registro");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha en que se creo el registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("fecha de la ultima modificacion");

                entity.Property(e => e.Nacionalidad1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nacionalidad")
                    .HasComment("concepto de nacionalidad de la persona");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario que creo el registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("El ultimo Usuario que modifico el registro");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona");

                entity.HasComment("Almacena la informacion de todas las personas");

                entity.HasIndex(e => e.IdEstadoCivil, "IXFK_Persona_EstadoCivil");

                entity.HasIndex(e => e.IdNacionalidad, "IXFK_Persona_Nacionalidad");

                entity.HasIndex(e => new { e.ApellidoPaterno, e.ApellidoMaterno, e.Nombres }, "IX_NoDuplicado")
                    .IsUnique();

                entity.Property(e => e.IdPersona)
                    .HasColumnName("idPersona")
                    .HasComment("id consecutivo de la tabla personas");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Apellido materno de la persona");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Apellido paterno de la persona");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasComment("Clave Unica de Resgitro de Poblacion contiene 18 caracteres");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("Si el registro esta habilitado ");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Estatus de la Persona ");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de la Creacion del registro");

                entity.Property(e => e.FechaMod)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Fecha de la ultima modificacion ");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasComment("Fecha de nacimiento de la persona");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("El path de la foto de la persona");

                entity.Property(e => e.IdEstadoCivil)
                    .HasColumnName("idEstadoCivil")
                    .HasComment("El estado civil de la persona Casado, Divorciado, Soltero, union libre");

                entity.Property(e => e.IdNacionalidad)
                    .HasColumnName("idNacionalidad")
                    .HasComment("id Nacionalidad de la persona");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombre o Nombres de la persona");

                entity.Property(e => e.Nss)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComment("Numero de Seguro Social tiene 11 caracteres");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("M = Masculino , F = Femenino");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario que creo el registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Ultimo usuario que modifico ");

                entity.HasOne(d => d.IdEstadoCivilNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdEstadoCivil)
                    .HasConstraintName("FK_Persona_EstadoCivil");

                entity.HasOne(d => d.IdNacionalidadNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdNacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Nacionalidad");
            });

            modelBuilder.Entity<PersonaDireccion>(entity =>
            {
                entity.HasKey(e => e.IdPersonaDireccion);

                entity.ToTable("PersonaDireccion");

                entity.HasComment("Las direcciones que tiene una persona");

                entity.HasIndex(e => e.IdDireccion, "IXFK_PersonaDireccion_Direccion");

                entity.HasIndex(e => e.IdPersona, "IXFK_PersonaDireccion_Persona");

                entity.HasIndex(e => new { e.IdPersona, e.IdDireccion }, "IX_NoDuplicado")
                    .IsUnique();

                entity.Property(e => e.IdPersonaDireccion).HasColumnName("idPersonaDireccion");

                entity.Property(e => e.IdDireccion).HasComment("El id de la Tabla Direccion");

                entity.Property(e => e.IdPersona).HasComment("El id de la tabla de Personas");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.PersonaDireccions)
                    .HasForeignKey(d => d.IdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaDireccion_Direccion");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaDireccions)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaDireccion_Persona");
            });

            modelBuilder.Entity<TipoAsentamiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoAsentamiento);

                entity.ToTable("TipoAsentamiento");

                entity.HasComment("Los tipos de Asentamientos como Ejido, Colonia , Poblado");

                entity.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrevia")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
                    .IsUnique();

                entity.HasIndex(e => e.Nombre, "IX_NoDuplicadoNombre")
                    .IsUnique();

                entity.Property(e => e.IdTipoAsentamiento)
                    .HasColumnName("idTipoAsentamiento")
                    .HasComment("Id Consecutivo");

                entity.Property(e => e.Abreviatura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Abreviatura de la descripcion de tipo de asentamiento");

                entity.Property(e => e.Codigo).HasComment("Codigo numerico para identificacion del usuario");

                entity.Property(e => e.EsHabilitado)
                    .HasColumnName("Es_Habilitado")
                    .HasComment("Si esta disponible el registro ");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creacion")
                    .HasComment("Fecha de Creacion del registro");

                entity.Property(e => e.FechaMod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fecha_Mod")
                    .HasComment("Ultima Fecha de Modificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombre del tipo de Asentamiento ");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Creacion")
                    .HasComment("Usuario que creo el registro");

                entity.Property(e => e.UsuarioMod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario_Mod")
                    .HasComment("Ultimo usuario que modifico el registro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
