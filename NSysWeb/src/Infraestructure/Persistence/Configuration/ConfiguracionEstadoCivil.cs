using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionEstadoCivil : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil> builder)
        {
            builder.HasKey(e => e.IdEstadoCivil);

            builder.ToTable("EstadoCivil");

            builder.HasComment("Los estados Civiles de las Personas");

            builder.HasIndex(e => e.Descripcion, "IX_NoDuplicado")
                .IsUnique();

          //  builder.HasIndex(e => e.Codigo, "IX_NoDuplicadoCodigo")
          //      .IsUnique();

            builder.Property(e => e.IdEstadoCivil).HasComment("Id consecutivo");

           // builder.Property(e => e.Codigo).HasComment("Codigo consecutivo visible a usuario");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Descripcion del estado civil");

            builder.Property(e => e.EsHabilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("Si el registro esta habilitado");

            builder.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus del estado civil");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de creacion del registro");

            builder.Property(e => e.FechaMod)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Mod")
                .HasComment("Fecha de la ultima modificacion");

            builder.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion")
                .HasComment("El usuario que creo el registro");

            builder.Property(e => e.UsuarioMod)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Mod")
                .HasComment("Ultimo usuario que modifico el registro");
        }
    }
}
