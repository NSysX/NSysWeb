using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ConfiguracionDocumento : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> entity)
        {
            entity.HasKey(e => e.IdDocumento);

            entity.ToTable("Documento");

            entity.HasComment("Se incluyen todos los documentos que las personas fisicas y morales pueden tener");

            entity.HasIndex(e => e.IdTipoDocumento, "IXFK_Documento_TipoDocumento");

            entity.HasIndex(e => e.CadenaUnica, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdDocumento).HasComment("El id de la tabla Documento");

            entity.Property(e => e.CadenaUnica)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("La cadena unica del documento");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta disponible para usarlo");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("algun estatus para el registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion de registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Ultima Fecha de modificacion");

            entity.Property(e => e.IdTipoDocumento).HasComment("El identificador unico de la tabla TipoDocumento");

            entity.Property(e => e.Imagen)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Imagen del documento");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");

            entity.HasOne(d => d.IdTipoDocumentoNavigation)
                .WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_TipoDocumento");
        }
    }
}
