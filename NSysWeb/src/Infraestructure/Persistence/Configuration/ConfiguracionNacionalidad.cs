using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionNacionalidad : IEntityTypeConfiguration<Nacionalidad>
    {
        public void Configure(EntityTypeBuilder<Nacionalidad> entity)
        {
            entity.HasKey(e => e.IdNacionalidad);

            entity.ToTable("Nacionalidad");

            entity.HasComment("Catalogo de Nacionalidades con su bandera");

            entity.HasIndex(e => e.Nacionalidad1, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdNacionalidad).HasComment("Id unico para el registro");

            entity.Property(e => e.EsHabilitado).HasComment("si esta disponible el registro ");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("El Estatus del Registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha en que se creo el registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("fecha de la ultima modificacion");

            entity.Property(e => e.Nacionalidad1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nacionalidad")
                .HasComment("concepto de nacionalidad de la persona");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("El ultimo Usuario que modifico el registro");
        }
    }
}
