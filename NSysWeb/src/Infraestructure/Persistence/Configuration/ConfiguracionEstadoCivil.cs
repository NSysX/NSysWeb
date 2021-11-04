using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionEstadoCivil : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.HasKey(e => e.IdEstadoCivil);

            builder.ToTable("EstadoCivil");

            builder.HasComment("Los estados Civiles de las Personas");

            builder.HasIndex(e => e.Descripcion, "IX_NoDuplicado")
                .IsUnique();

            builder.Property(e => e.IdEstadoCivil).HasComment("Id consecutivo");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Descripcion del estado civil");

            builder.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus del estado civil");
        }
    }
}
