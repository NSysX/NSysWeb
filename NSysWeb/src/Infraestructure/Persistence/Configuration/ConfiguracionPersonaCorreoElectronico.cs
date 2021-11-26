﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configuration
{
    public class ConfiguracionPersonaCorreoElectronico : IEntityTypeConfiguration<PersonaCorreoElectronico>
    {
        public void Configure(EntityTypeBuilder<PersonaCorreoElectronico> entity)
        {
            entity.HasKey(e => e.IdPersonaCorreoElectronico);

            entity.ToTable("PersonaCorreoElectronico");

            entity.HasComment("Los Correos electronicos que tiene una persona");

            entity.HasIndex(e => e.IdCorreoElectronico, "IXFK_PersonaCorreoElectronico_CorreoElectronico");

            entity.HasIndex(e => e.IdPersona, "IXFK_PersonaCorreoElectronico_Persona");

            entity.HasIndex(e => new { e.IdPersona, e.IdCorreoElectronico }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdPersonaCorreoElectronico).HasComment("identificador unico de los registros");

            entity.Property(e => e.IdCorreoElectronico).HasComment("Identificador unico de la tabla de email");

            entity.Property(e => e.IdPersona).HasComment("Identificador unico del registro de persona ");

            //entity.HasOne(d => d.IdCorreoElectronicoNavigation)
            //    //.WithMany(p => p.PersonaCorreoElectronico)
            //    .HasForeignKey(d => d.IdCorreoElectronico)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaCorreoElectronico_CorreoElectronico");

            //entity.HasOne(d => d.IdPersonaNavigation)
            //    .WithMany(p => p.PersonaCorreoElectronico)
            //    .HasForeignKey(d => d.IdPersona)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaCorreoElectronico_Persona");
        }
    }
}
