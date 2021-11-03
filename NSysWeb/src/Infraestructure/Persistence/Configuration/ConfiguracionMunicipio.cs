using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionMunicipio : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.HasKey(e => e.IdMunicipio);

            builder.ToTable("Municipio");

            builder.HasComment("Municipios de Mexico");

            builder.HasIndex(e => e.IdEstado, "IXFK_Municipio_Estado");

            builder.HasIndex(e => e.Abreviatura, "IX_NoDuplicadoAbrevi")
                .IsUnique();

            builder.HasIndex(e => new { e.IdEstado, e.Nombre }, "IX_NoDuplicadoNomXEdo")
                .IsUnique();

            builder.Property(e => e.IdMunicipio)
                .HasColumnName("idMunicipio")
                .HasComment("id consecutivo de municipio");

            builder.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.EsHabilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("Si el registro esta disponible");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de Creacion del registro");

            builder.Property(e => e.FechaMod)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Mod")
                .HasComment("Fecha de la utlima modificacion");

            builder.Property(e => e.IdEstado)
                .HasColumnName("idEstado")
                .HasComment("id que pertenece al estado");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del Municipio");

            builder.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion")
                .HasComment("Usuario que creo el Registro");

            builder.Property(e => e.UsuarioMod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Mod")
                .HasComment("Ultimo usuario que modifico el registro");

            builder.HasOne(d => d.IdEstadoNavigation)
                .WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipio_Estado");
        }
    }
}
