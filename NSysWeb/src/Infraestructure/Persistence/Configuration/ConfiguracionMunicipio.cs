using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionMunicipio : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> entity)
        {
            entity.HasKey(e => e.IdMunicipio);

            entity.ToTable("Municipio");

            entity.HasComment("Municipios de Mexico");

            entity.HasIndex(e => e.IdEstado, "IXFK_Municipio_Estado");

            entity.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrevi")
                .IsUnique();

            entity.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
                .IsUnique();

            entity.HasIndex(e => new { e.IdEstado, e.Nombre }, "IX_NoDuplicadoNomXEdo")
                .IsUnique();

            entity.Property(e => e.IdMunicipio)
                .HasColumnName("idMunicipio")
                .HasComment("id consecutivo de municipio");

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Codigo).HasComment("Codigo visible al usuario");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta disponible");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la utlima modificacion");

            entity.Property(e => e.IdEstado)
                .HasColumnName("idEstado")
                .HasComment("id que pertenece al estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del Municipio");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el Registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");

            entity.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipio_Estado");
        }
    }
}
