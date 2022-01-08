using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionPais : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> entity)
        {
            entity.HasKey(p => p.IdPais);

            entity.ToTable("Pais");

            entity.HasComment("Catalogo de Paises");

            entity.HasIndex(p => p.Nombre, "IX_NoDuplicadoNombrePais").IsUnique();

            entity.HasIndex(p => p.Abreviatura, "IX_NoDuplicadoAbrevPais").IsUnique();

            entity.Property(p => p.IdPais).HasComment("Identificador unico");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha en que se creo el registro");

            entity.Property(e => e.UsuarioCreacion)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasComment("Usuario que creo el registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion del registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("El usuario de la ultima modificacion");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta disponible para trabajar con el");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus del registro");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del Pais");

            entity.Property(e => e.Abreviatura)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComment("Abreviatura del nombre del Pais");
        }
    }
}
