using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionCorreoElectronico : IEntityTypeConfiguration<CorreoElectronico>
    {
        public void Configure(EntityTypeBuilder<CorreoElectronico> entity)
        {
            entity.HasKey(e => e.IdCorreoElectronico);

            entity.ToTable("CorreoElectronico");

            entity.HasComment("Todos lo Correos Electronicos de personas y Empresas");

            entity.HasIndex(e => e.Correo, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdCorreoElectronico).HasComment("Identificador unico");

            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("El Email o Correo electroinico");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado para trabajar con el, borrado logico");

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
                .HasComment("Fecha modificacion");

            entity.Property(e => e.TipoEmail)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Tipo de email personal trabajo ");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario Creacion del registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
