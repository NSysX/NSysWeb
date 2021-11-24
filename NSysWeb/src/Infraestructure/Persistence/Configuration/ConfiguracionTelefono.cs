using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configuration
{
    public class ConfiguracionTelefono : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> entity)
        {
            entity.HasKey(e => e.IdTelefono);

            entity.ToTable("Telefono");

            entity.HasComment("Todos los Telefonos de personas y empresas");

            entity.Property(e => e.IdTelefono).HasComment("Identificador unico de la tabla telefono");

            entity.Property(e => e.CodigoPais)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasComment("Codigo Telefonico del Pais");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado para trabajar");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Estatus del registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Ultima fecha de Modificacion del registro");

            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Numero telefonico");

            entity.Property(e => e.TipoTelefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Celular o Fijo");

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
