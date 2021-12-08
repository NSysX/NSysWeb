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
    public class ConfiguracionAsentamientoTipo : IEntityTypeConfiguration<AsentamientoTipo>
    {
        public void Configure(EntityTypeBuilder<AsentamientoTipo> entity)
        {
            entity.HasKey(e => e.IdTipoAsentamiento)
                     .HasName("PK_TipoAsentamiento");

            entity.ToTable("AsentamientoTipo");

            entity.HasComment("Los tipos de Asentamientos como Ejido, Colonia , Poblado");

            entity.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbre")
                .IsUnique();

            entity.HasIndex(e => e.Nombre, "IX_NoDuplicadoAsen")
                .IsUnique();

            entity.Property(e => e.IdTipoAsentamiento).HasComment("Identificador unico ");

            entity.Property(e => e.Abreviatura)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Abreviatura de la descripcion de tipo de asentamiento");

            entity.Property(e => e.EsHabilitado).HasComment("Si esta disponible el registro ");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Ultima Fecha de Modificacion");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del tipo de Asentamiento ");

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
