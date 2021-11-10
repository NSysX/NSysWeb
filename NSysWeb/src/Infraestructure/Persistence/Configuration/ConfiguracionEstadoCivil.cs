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

            builder.Property(e => e.Fecha_Creacion)
              .HasColumnType("datetime")
              .HasColumnName("Fecha_Creacion")
              .HasComment("Fecha de creacion del registro");

            builder.Property(e => e.Fecha_Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion")
                .HasComment("Fecha de la ultima modificacion");

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
                .HasComment("Usuario de la ultima modificacion");

            builder.Property(e => e.Es_Habilitado)
                 .HasColumnName("Es_Habilitado")
                 .HasComment("si esta disponible el registro");

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
