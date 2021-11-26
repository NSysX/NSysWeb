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
    public class ConfiguracionTelefono : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> entity)
        {
            entity.HasKey(e => e.IdTelefono);

            entity.ToTable("Telefono");

            entity.HasComment("Todos los Telefonos de personas y empresas");

            entity.HasIndex(e => new { e.CodigoPais, e.Numero }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdTelefono).HasComment("Identificador unico de la tabla telefono");

            entity.Property(e => e.CodigoPais)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasComment("Codigo Telefonico del Pais");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado para trabajar");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus del registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Ultima fecha de Modificacion del registro");

            entity.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Numero telefonico");

            entity.Property(e => e.TipoTelefono)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Celular o Fijo");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
