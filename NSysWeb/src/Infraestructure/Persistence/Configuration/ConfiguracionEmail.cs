using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configuration
{
    public class ConfiguracionEmail : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> entity)
        {
            entity.HasKey(e => e.IdEmail);

            entity.ToTable("Email");

            entity.HasComment("Todos lo Correos Electronicos de personas y Empresas");

            entity.HasIndex(e => e.Email1, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdEmail)
                .HasColumnName("idEmail")
                .HasComment("Identificador unico");

            entity.Property(e => e.Email1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email")
                .HasComment("El Email o Correo electroinico");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado para trabajar con el, borrado logico");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha modificacion");

            entity.Property(e => e.TipoEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Tipo de email personal trabajo ");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario Creacion del registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
