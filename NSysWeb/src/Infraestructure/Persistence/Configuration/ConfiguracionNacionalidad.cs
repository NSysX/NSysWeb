using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionNacionalidad : IEntityTypeConfiguration<Nacionalidad>
    {
        public void Configure(EntityTypeBuilder<Nacionalidad> builder)
        {
            builder.HasKey(e => e.IdNacionalidad);

            builder.ToTable("Nacionalidad");

            builder.HasComment("Catalogo de Nacionalidades con su bandera");

            builder.Property(e => e.IdNacionalidad).HasComment("Id unico para el registro");

            builder.Property(e => e.EsHabilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("si esta disponible el registro ");

            builder.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("El Estatus del Registro");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha en que se creo el registro");

            builder.Property(e => e.FechaMod)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Mod")
                .HasComment("fecha de la ultima modificacion");

            builder.Property(e => e.Nacionalidad1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nacionalidad")
                .HasComment("concepto de nacionalidad de la persona");

            builder.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion")
                .HasComment("Usuario que creo el registro");

            builder.Property(e => e.UsuarioMod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Mod")
                .HasComment("El ultimo Usuario que modifico el registro");
        }
    }
}
