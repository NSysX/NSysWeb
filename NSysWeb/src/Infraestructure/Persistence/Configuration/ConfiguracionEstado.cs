using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionEstado : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
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
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("Abreviatura de nombre del estado de la republica");

            entity.Property(e => e.Codigo).HasComment("codigo consecutivo para no mostrar el id usuario");

            entity.Property(e => e.EsHabilitado).HasComment("si esta disponible el registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Nombre del estado del pais");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario de la ultima modificacion");
        }
    }
}
