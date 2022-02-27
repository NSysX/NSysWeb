using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionDocumento : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> entity)
        {
            entity.HasKey(e => e.IdDocumento);

            entity.ToTable("Documento");

            entity.HasComment("Se incluyen todos los documentos que las personas fisicas y morales pueden tener");

            entity.HasIndex(e => e.IdDocumentoTipo, "IXFK_Documento_DocumentoTipo");

            entity.HasIndex(e => e.CodigoUnico, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdDocumento).HasComment("El id de la tabla Documento");

            entity.Property(e => e.CodigoUnico)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("La cadena unica del documento");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta disponible para usarlo");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("algun estatus para el registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion de registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Ultima Fecha de modificacion");

            entity.Property(e => e.IdDocumentoTipo).HasComment("El Identificador unico de la tabla DocumentoTipo");

            entity.Property(e => e.Foto)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Foto del documento");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");

            entity.HasOne(d => d.DocumentoTipo)
                .WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdDocumentoTipo)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Documento_DocumentoTipo");
        }
    }
}
