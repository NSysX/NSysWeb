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

            entity.HasIndex(e => e.IdAsentamientoTipo, "IXFK_Asentamiento_AsentamientoTipo");

            entity.HasIndex(e => new { e.IdMunicipio, e.Nombre }, "IX_NoDuplicadoIdMunicipioNombre")
                .IsUnique();

            entity.Property(e => e.IdAsentamiento).HasComment("Consecutivo de Asentamiento");

            entity.Property(e => e.CodigoPostal).HasComment("Codigo Postal");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado ");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus del registro");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creacion del Registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la Ultima Modificacion");

            entity.Property(e => e.IdAsentamientoTipo).HasComment("El id de la tabla TipoAsentamiento");

            entity.Property(e => e.IdMunicipio).HasComment("id del municipio al que pertenece");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del asentamiento");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario de Creacion del registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico el registro");

            entity.HasOne(d => d.AsentamientoTipo)
                .WithMany(p => p.Asentamientos)
                .HasForeignKey(d => d.IdAsentamientoTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asentamiento_AsentamientoTipo");

            entity.HasOne(m => m.Municipio)
                .WithMany(a => a.Asentamientos)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asentamiento_Municipio");
        }
    }
}
