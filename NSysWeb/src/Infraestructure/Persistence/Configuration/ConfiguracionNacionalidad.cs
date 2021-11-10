using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionNacionalidad : IEntityTypeConfiguration<Nacionalidad>
    {
        public void Configure(EntityTypeBuilder<Nacionalidad> builder)
        {
            builder.HasKey(e => e.IdNacionalidad);

            builder.ToTable("Nacionalidad");

            builder.HasComment("Catalogo de Nacionalidades con su bandera");

            builder.Property(e => e.IdNacionalidad).HasComment("Id unico para el registro");

            builder.Property(e => e.Es_Habilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("si esta disponible el registro ");

            builder.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("El Estatus del Registro");

            builder.Property(e => e.Fecha_Creacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha en que se creo el registro");

            builder.Property(e => e.Fecha_Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion")
                .HasComment("fecha de la ultima modificacion");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre")
                .HasComment("Nombre de nacionalidad de la persona");

            builder.Property(e => e.Usuario_Creacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion")
                .HasComment("Usuario que creo el registro");

            builder.Property(e => e.Usuario_Modificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion")
                .HasComment("El ultimo Usuario que modifico el registro");
        }
    }
}
