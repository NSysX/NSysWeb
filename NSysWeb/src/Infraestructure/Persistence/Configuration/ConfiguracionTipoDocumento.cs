using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configuration
{
    public class ConfiguracionTipoDocumento : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> entity)
        {
            entity.HasKey(e => e.IdTipoDocumento);

            entity.ToTable("TipoDocumento");

            entity.HasComment("Se capturan los tipos de documentos para que esten disponibles");

            entity.HasIndex(e => e.Abreviacion, "IX_NoDuplicado_Abrev")
                .IsUnique();

            entity.HasIndex(e => e.Nombre, "IX_NoDuplicado_Nom")
                .IsUnique();

            entity.Property(e => e.IdTipoDocumento).HasComment("El identificador unico de registro");

            entity.Property(e => e.Abreviacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Abreviacion del documento");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta disponible para trabajar con el");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Estatus del registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha en que se creo el registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion del registro");

            entity.Property(e => e.Longitud)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasComment("La longitud de caracteres permitido para la Cadena Unica");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre completo del documento ");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnType("datetime")
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasColumnType("datetime")
                .HasComment("El usuario de la ultima modificacion");
        }
    }
}
