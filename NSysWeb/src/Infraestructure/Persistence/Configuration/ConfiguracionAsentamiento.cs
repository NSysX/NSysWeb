using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionAsentamiento : IEntityTypeConfiguration<Asentamiento>
    {
        public void Configure(EntityTypeBuilder<Asentamiento> builder)
        {
            builder.HasKey(e => e.IdAsentamiento);

            builder.ToTable("Asentamiento");

            builder.HasComment("Nombre del asentamiento");

            builder.HasIndex(e => e.IdMunicipio, "IXFK_Asentamiento_Municipio");

            builder.HasIndex(e => e.IdTipoAsentamiento, "IXFK_Asentamiento_TipoAsentamiento");

            builder.HasIndex(e => new { e.IdMunicipio, e.IdTipoAsentamiento, e.Nombre }, "IX_NoDuplicado")
                .IsUnique();

            builder.Property(e => e.IdAsentamiento)
                .HasColumnName("idAsentamiento")
                .HasComment("Consecutivo de Asentamiento");

            builder.Property(e => e.CodigoPostal).HasComment("Codigo Postal");

            builder.Property(e => e.EsHabilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("Si el registro esta habilitado ");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de Creacion del Registro");

            builder.Property(e => e.FechaMod)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Mod")
                .HasComment("Fecha de la Ultima Modificacion");

            builder.Property(e => e.IdMunicipio)
                .HasColumnName("idMunicipio")
                .HasComment("id del municipio al que pertenece");

            builder.Property(e => e.IdTipoAsentamiento)
                .HasColumnName("idTipoAsentamiento")
                .HasComment("El id de la tabla TipoAsentamiento ");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del asentamiento");

            builder.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion")
                .HasComment("Usuario de Creacion del registro");

            builder.Property(e => e.UsuarioMod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Mod")
                .HasComment("Ultimo usuario que modifico el registro");

            builder.HasOne(d => d.IdMunicipioNavigation)
                .WithMany(p => p.Asentamientos)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asentamiento_Municipio");

            builder.HasOne(d => d.IdTipoAsentamientoNavigation)
                .WithMany(p => p.Asentamientos)
                .HasForeignKey(d => d.IdTipoAsentamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asentamiento_TipoAsentamiento");
        }
    }
}
