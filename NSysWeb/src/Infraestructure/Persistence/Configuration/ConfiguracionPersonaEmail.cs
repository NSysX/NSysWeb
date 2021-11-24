using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionPersonaEmail : IEntityTypeConfiguration<PersonaEmail>
    {
        public void Configure(EntityTypeBuilder<PersonaEmail> entity)
        {
            entity.HasKey(e => e.IdPersonaEmail);

            entity.ToTable("PersonaEmail");

            entity.HasComment("Los email que tiene una persona");

            entity.HasIndex(e => e.IdEmail, "IXFK_PersonaEmail_Email");

            entity.HasIndex(e => e.IdPersona, "IXFK_PersonaEmail_Persona");

            entity.Property(e => e.IdPersonaEmail).HasComment("identificador unico de los registros");

            entity.Property(e => e.IdEmail).HasComment("Identificador unico de la tabla de email");

            entity.Property(e => e.IdPersona).HasComment("Identificador unico del registro de persona ");

            entity.HasOne(d => d.IdEmailNavigation)
                .WithMany(p => p.PersonaEmails)
                .HasForeignKey(d => d.IdEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaEmail_Email");

            entity.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaEmails)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaEmail_Persona");
        }
    }
}
