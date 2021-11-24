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
    public class ConfiguracionPersonaDocumento : IEntityTypeConfiguration<PersonaDocumento>
    {
        public void Configure(EntityTypeBuilder<PersonaDocumento> entity)
        {
            entity.HasKey(e => e.IdPersonaDocumento);

            entity.ToTable("PersonaDocumento");

            entity.HasComment("La relacion de los documentos que puede tener una persona");

            entity.HasIndex(e => e.IdDocumento, "IXFK_PersonaDocumento_Documento");

            entity.HasIndex(e => e.IdPersona, "IXFK_PersonaDocumento_Persona");

            entity.HasIndex(e => new { e.IdPersona, e.IdDocumento }, "IX_NoDuplicado")
                .IsUnique();

            entity.Property(e => e.IdPersonaDocumento).HasColumnName("idPersonaDocumento");

            entity.Property(e => e.IdDocumento)
                .HasColumnName("idDocumento")
                .HasComment("IdDocumento de la Tabla Documento");

            entity.Property(e => e.IdPersona)
                .HasColumnName("idPersona")
                .HasComment("El idPersona de la tabla Personas");

            entity.HasOne(d => d.IdDocumentoNavigation)
                .WithMany(p => p.PersonaDocumentos)
                .HasForeignKey(d => d.IdDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDocumento_Documento");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaDocumentos)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDocumento_Persona");
        }
    }
}
