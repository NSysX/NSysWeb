using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionEstadoCivil : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> entity)
        {
            entity.HasKey(e => e.IdEstadoCivil);

            entity.ToTable("EstadoCivil");

            entity.HasComment("Los estados Civiles de las Personas");

            entity.HasIndex(e => e.Descripcion, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdEstadoCivil).HasComment("Id consecutivo ");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Descripcion del estado civil");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Estatus del estado civil");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("El usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
