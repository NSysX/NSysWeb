using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configuration
{
    public class ConfigutacionSysDominioEmail : IEntityTypeConfiguration<SysDominioEmail>
    {
        public void Configure(EntityTypeBuilder<SysDominioEmail> entity)
        {
            entity.HasKey(e => e.IdSysDominio)
                    .HasName("PK_Sys_Dominio");

            entity.ToTable("SysDominioEmail");

            entity.HasComment("Dominios precapturados para los correos");

            entity.HasIndex(e => e.Dominio, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdSysDominio).HasComment("Identificador unico ");

            entity.Property(e => e.Dominio)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasComment("Dominio Hotmail.com, Gmail.com, etc..");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion");

            entity.Property(e => e.UsuarioCreacion)
                .HasColumnType("datetime")
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que hizo la ultima modificacion");
        }
    }
}
