using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionTipoDocumento : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> entity)
        {
            entity.HasKey(e => e.IdTipoDocumento);

            entity.ToTable("TipoDocumento");

            entity.HasComment("Se capturan los tipos de documentos para que esten disponibles");

            entity.HasIndex(e => e.Abreviacion, "IX_NoDuplicadoAbre")
                .IsUnique();

            entity.HasIndex(e => e.Nombre, "IX_NoDuplicadoNom")
                .IsUnique();

            entity.Property(e => e.IdTipoDocumento).HasComment("El identificador unico de registro");

            entity.Property(e => e.Abreviacion)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Abreviacion del documento");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta disponible para trabajar con el");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus del registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha en que se creo el registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion del registro");

            entity.Property(e => e.Longitud)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasComment("La longitud de caracteres permitido para la Cadena Unica");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre completo del documento ");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("El usuario de la ultima modificacion");
        }
    }
}
