using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionAsentamiento : IEntityTypeConfiguration<Asentamiento>
    {
        public void Configure(EntityTypeBuilder<Asentamiento> entity)
        {
            entity.HasKey(e => e.IdAsentamiento);

            entity.ToTable("Asentamiento");

            entity.HasComment("Nombre del asentamiento");

            entity.HasIndex(e => e.IdMunicipio, "IXFK_Asentamiento_Municipio");

            entity.HasIndex(e => e.IdTipoAsentamiento, "IXFK_Asentamiento_TipoAsentamiento");

            entity.HasIndex(e => new { e.IdMunicipio, e.IdTipoAsentamiento, e.Nombre }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdAsentamiento)
                .HasColumnName("idAsentamiento")
                .HasComment("Consecutivo de Asentamiento");

            entity.Property(e => e.CodigoPostal).HasComment("Codigo Postal");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado ");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion del Registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la Ultima Modificacion");

            entity.Property(e => e.IdMunicipio)
                .HasColumnName("idMunicipio")
                .HasComment("id del municipio al que pertenece");

            entity.Property(e => e.IdTipoAsentamiento)
                .HasColumnName("idTipoAsentamiento")
                .HasComment("El id de la tabla TipoAsentamiento ");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del asentamiento");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario de Creacion del registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");

            entity.HasOne(d => d.IdMunicipioNavigation)
                .WithMany(p => p.Asentamientos)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asentamiento_Municipio");

            entity.HasOne(d => d.IdTipoAsentamientoNavigation)
                .WithMany(p => p.Asentamientos)
                .HasForeignKey(d => d.IdTipoAsentamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asentamiento_TipoAsentamiento");
        }
    }
}
