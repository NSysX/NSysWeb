using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionEstado : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(e => e.IdEstado);

            builder.ToTable("Estado");

            builder.HasComment("Estado de paises");

            builder.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrev")
                .IsUnique();

            builder.HasIndex(e => e.Nombre, "IX_NoDuplicadoNombre")
                .IsUnique();

            builder.Property(e => e.IdEstado)
                .HasColumnName("idEstado")
                .HasComment("id del estado");

            builder.Property(e => e.Abreviatura)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("Abreviatura de nombre del estado de la republica");

            builder.Property(e => e.Es_Habilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("si esta disponible el registro");

            builder.Property(e => e.Fecha_Creacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de creacion del registro");

            builder.Property(e => e.Fecha_Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion")
                .HasComment("Fecha de la ultima modificacion");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Nombre del estado del pais");

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
        }
    }
}
