using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguraTipoAsentamiento : IEntityTypeConfiguration<TipoAsentamiento>
    {
        public void Configure(EntityTypeBuilder<TipoAsentamiento> entity)
        {
            entity.HasKey(e => e.IdTipoAsentamiento);

            entity.ToTable("TipoAsentamiento");

            entity.HasComment("Los tipos de Asentamientos como Ejido, Colonia , Poblado");

            entity.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrevia")
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

            entity.Property(e => e.EsHabilitado).HasComment("Si esta disponible el registro ");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultima Fecha de Modificacion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del tipo de Asentamiento ");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
