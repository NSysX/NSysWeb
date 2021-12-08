using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ConfiguracionPersonaDireccion : IEntityTypeConfiguration<PersonaDireccion>
    {
        public void Configure(EntityTypeBuilder<PersonaDireccion> entity)
        {
            entity.HasNoKey();

            entity.ToTable("PersonaDireccion");

            entity.HasComment("Las direcciones que tiene una persona");

            entity.HasIndex(e => e.IdDireccion, "IXFK_PersonaDireccion_Direccion");

            entity.HasIndex(e => e.IdPersona, "IXFK_PersonaDireccion_Persona");

            entity.HasIndex(e => new { e.IdPersona, e.IdDireccion }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdDireccion).HasComment("El id de la Tabla Direccion");

            entity.Property(e => e.IdPersona).HasComment("El id de la tabla de Personas");

            entity.HasOne(d => d.IdDireccionNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Direccion");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Persona");
        }
    }
}
