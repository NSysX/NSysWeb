using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguraTipoAsentamiento : IEntityTypeConfiguration<TipoAsentamiento>
    {
        public void Configure(EntityTypeBuilder<TipoAsentamiento> builder)
        {
            builder.HasKey(e => e.IdTipoAsentamiento);

            builder.ToTable("TipoAsentamiento");

            builder.HasComment("Los tipos de Asentamientos como Ejido, Colonia , Poblado");

            builder.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrevia")
                .IsUnique();

            builder.HasIndex(e => e.Nombre, "IX_NoDuplicadoNombre")
                .IsUnique();

            builder.Property(e => e.IdTipoAsentamiento)
                .HasColumnName("idTipoAsentamiento")
                .HasComment("Id Consecutivo");

            builder.Property(e => e.Abreviatura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Abreviatura de la descripcion de tipo de asentamiento");

            builder.Property(e => e.EsHabilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("Si esta disponible el registro ");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de Creacion del registro");

            builder.Property(e => e.FechaMod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Fecha_Mod")
                .HasComment("Ultima Fecha de Modificacion");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del tipo de Asentamiento ");

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
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
