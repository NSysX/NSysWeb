using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionPersona : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.IdPersona);

            builder.ToTable("Persona");

            builder.HasComment("Almacena la informacion de todas las personas");

            builder.HasIndex(e => e.IdEstadoCivil, "IXFK_Persona_EstadoCivil");

            builder.HasIndex(e => e.IdNacionalidad, "IXFK_Persona_Nacionalidad");

            builder.HasIndex(e => new { e.Apellido_Paterno, e.Apellido_Materno, e.Nombres }, "IX_NoDuplicado")
                .IsUnique();

            builder.Property(e => e.IdPersona)
                .HasColumnName("idPersona")
                .HasComment("id consecutivo de la tabla personas");

            builder.Property(e => e.Apellido_Materno)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Apellido materno de la persona");

            builder.Property(e => e.Apellido_Paterno)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Apellido paterno de la persona");

            builder.Property(e => e.Curp)
                .IsRequired()
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasComment("Clave Unica de Resgitro de Poblacion contiene 18 caracteres");

            builder.Property(e => e.Es_Habilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("Si el registro esta habilitado ");

            builder.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus de la Persona ");

            builder.Property(e => e.Fecha_Creacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de la Creacion del registro");

            builder.Property(e => e.Fecha_Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion")
                .HasComment("Fecha de la ultima modificacion ");

            builder.Property(e => e.Fecha_Nacimiento)
                .HasColumnType("date")
                .HasComment("Fecha de nacimiento de la persona");

            builder.Property(e => e.Foto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("El path de la foto de la persona");

            builder.Property(e => e.IdEstadoCivil)
                .HasColumnName("idEstadoCivil")
                .HasComment("El estado civil de la persona Casado, Divorciado, Soltero, union libre");

            builder.Property(e => e.IdNacionalidad)
                .HasColumnName("idNacionalidad")
                .HasComment("id Nacionalidad de la persona");

            builder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre o Nombres de la persona");

            builder.Property(e => e.Nss)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComment("Numero de Seguro Social tiene 11 caracteres");

            builder.Property(e => e.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("M = Masculino , F = Femenino");

            builder.Property(e => e.Usuario_Creacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion")
                .HasComment("Usuario que creo el registro");

            builder.Property(e => e.Usuario_Modificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion")
                .HasComment("Ultimo usuario que modifico ");

            builder.HasOne(d => d.IdEstadoCivilNavigation)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdEstadoCivil)
                .HasConstraintName("FK_Persona_EstadoCivil");

            builder.HasOne(d => d.IdNacionalidadNavigation)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Nacionalidad");
        }
    }
}
