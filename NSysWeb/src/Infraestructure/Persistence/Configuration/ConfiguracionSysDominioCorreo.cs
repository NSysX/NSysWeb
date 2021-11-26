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
    public class ConfiguracionSysDominioCorreo : IEntityTypeConfiguration<SysDominioCorreo>
    {
        public void Configure(EntityTypeBuilder<SysDominioCorreo> entity)
        {
            entity.HasKey(e => e.IdSysDominioCorreo);

            entity.ToTable("SysDominioCorreo");

            entity.HasComment("Dominios precapturados para los correos");

            entity.HasIndex(e => e.Dominio, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdSysDominioCorreo).HasComment("Identificador unico ");

            entity.Property(e => e.Dominio)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasComment("Dominio Hotmail.com, Gmail.com, etc..");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro estra disponible, borrado Logico");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("estatus del registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que hizo la ultima modificacion");
        }
    }
}
