using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionEstado : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("Estado");

            entity.HasComment("Estado de paises");

            entity.HasIndex(e => e.Nombre, "IX_NoDuplicadoNombre")
                .IsUnique();

            entity.HasIndex(e => e.RenapoAbrev, "IX_NoDuplicadoRenapoAbrev")
                .IsUnique();

            entity.HasIndex(e => e.TresDigitosAbrev, "IX_NoDuplicadoTresDigitosAbrev")
                .IsUnique();

            entity.HasIndex(e => e.VariableAbrev, "IX_NoDuplicadoVariableAbrev")
                .IsUnique();

            entity.HasIndex(e => e.Clave, "IX_NoDuplicadoClave")
                .IsUnique();

            entity.Property(e => e.IdEstado).HasComment("id del estado");

            entity.Property(e => e.IdPais).HasComment("Id al pais que pertenece");

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
                .HasComment("Usuario de la ultima modificacion");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Nombre del estado del pais");

            entity.Property(e => e.Clave)
                .IsRequired()
                .HasComment("Clave del Estado");

            entity.Property(e => e.VariableAbrev)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Abreviatura de nombre de tipo Variable");

            entity.Property(e => e.RenapoAbrev)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasComment("Abreviatura de nombre segun Registro de Poblacion (RENAPO)");

            entity.Property(e => e.TresDigitosAbrev)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasComment("Abreviatura de nombre a Tres Digitos");

            entity.Property(e => e.EsHabilitado).HasComment("si esta disponible el registro"); 

            entity.HasOne(e => e.Pais)
                .WithMany(e => e.Estados)
                .HasForeignKey(e => e.IdPais)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Estado_Pais");
        }
    }
}
