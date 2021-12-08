﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configuration
{
    public class ConfiguracionPersonaTelefono : IEntityTypeConfiguration<PersonaTelefono>
    {
        public void Configure(EntityTypeBuilder<PersonaTelefono> entity)
        {
            entity.HasNoKey();

            entity.ToTable("PersonaTelefono");

            entity.HasComment("Los numeros de telefono de las personas");

            entity.HasIndex(e => e.IdPersona, "IXFK_PersonaTelefono_Persona");

            entity.HasIndex(e => e.IdTelefono, "IXFK_PersonaTelefono_Telefono");

            entity.HasIndex(e => new { e.IdPersona, e.IdTelefono }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdPersona).HasComment("El identificador de la tabla persona");

            entity.Property(e => e.IdTelefono).HasComment("El identificador de la tabla telefono");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaTelefono_Persona");

            entity.HasOne(d => d.IdTelefonoNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdTelefono)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaTelefono_Telefono");
        }
    }
}
