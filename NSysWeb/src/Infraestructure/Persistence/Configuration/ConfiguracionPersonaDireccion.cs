using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionPersonaDireccion : IEntityTypeConfiguration<PersonaDireccion>
    {
        public void Configure(EntityTypeBuilder<PersonaDireccion> builder)
        {
            builder.HasKey(e => e.IdPersonaDireccion);

            builder.ToTable("PersonaDireccion");

            builder.HasComment("Las direcciones que tiene una persona");

            builder.HasIndex(e => e.IdDireccion, "IXFK_PersonaDireccion_Direccion");

            builder.HasIndex(e => e.IdPersona, "IXFK_PersonaDireccion_Persona");

            builder.HasIndex(e => new { e.IdPersona, e.IdDireccion }, "IX_NoDuplicado")
                .IsUnique();

            builder.Property(e => e.IdPersonaDireccion).HasColumnName("idPersonaDireccion");

            builder.Property(e => e.IdDireccion).HasComment("El id de la Tabla Direccion");

            builder.Property(e => e.IdPersona).HasComment("El id de la Tabla de Personas");

            builder.HasOne(d => d.IdDireccionNavigation)
                .WithMany(p => p.PersonaDireccions)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Direccion");

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaDireccions)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Persona");
        }
    }
}
