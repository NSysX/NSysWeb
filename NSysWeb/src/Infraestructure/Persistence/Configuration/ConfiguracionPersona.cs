﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionPersona : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> entity)
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("Persona");

            entity.HasComment("Almacena la informacion de todas las personas");

            entity.HasIndex(e => e.IdEstadoCivil, "IXFK_Persona_EstadoCivil");

            entity.HasIndex(e => e.IdNacionalidad, "IXFK_Persona_Nacionalidad");

            entity.HasIndex(e => new { e.ApellidoPaterno, e.ApellidoMaterno, e.Nombres }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdPersona)
                .HasColumnName("idPersona")
                .HasComment("id consecutivo de la tabla personas");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Apellido materno de la persona");

            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Apellido paterno de la persona");

            entity.Property(e => e.EsHabilitado).HasComment("Si el registro esta habilitado ");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Estatus de la Persona ");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la Creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la ultima modificacion ");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasComment("Fecha de nacimiento de la persona");

            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("El path de la foto de la persona");

            entity.Property(e => e.IdEstadoCivil)
                .HasColumnName("idEstadoCivil")
                .HasComment("El estado civil de la persona Casado, Divorciado, Soltero, union libre");

            entity.Property(e => e.IdNacionalidad)
                .HasColumnName("idNacionalidad")
                .HasComment("id Nacionalidad de la persona");

            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre o Nombres de la persona");

            entity.Property(e => e.Notas)
                .IsUnicode(false)
                .HasComment("Notas importantes de la persona");

            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("M = Masculino , F = Femenino");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Ultimo usuario que modifico ");

            entity.HasOne(d => d.IdEstadoCivilNavigation)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdEstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_EstadoCivil");

            entity.HasOne(d => d.IdNacionalidadNavigation)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Nacionalidad");
        }
    }
}
