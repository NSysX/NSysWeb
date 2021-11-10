using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionDireccion : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(e => e.IdDireccion);

            builder.ToTable("Direccion");

            builder.HasComment("Registra todas las direcciones");

            builder.HasIndex(e => e.IdAsentamiento, "IXFK_Direccion_Asentamiento");

            builder.HasIndex(e => new { e.Calle, e.Numero_Exterior, e.Numero_Interior, e.IdAsentamiento }, "IX_NoDuplicados")
                .IsUnique();

            builder.Property(e => e.IdDireccion).HasComment("Id Numerico Consecutivo de direcciones");

            builder.Property(e => e.Calle)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Coordenadas_Geo)
                .IsRequired()
                .HasComment("Coordenadas geograficas ");

            builder.Property(e => e.Es_Fiscal).HasComment("Si la direccion es fiscal para la emision de facturas");

            builder.Property(e => e.Es_Habilitado)
                .HasColumnName("Es_Habilitado")
                .HasComment("Si esta disponible el registro");

            builder.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus de la direccion");

            builder.Property(e => e.Fecha_Creacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion")
                .HasComment("Fecha de creacion del registro");

            builder.Property(e => e.Fecha_Modificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion")
                .HasComment("Fecha de la Ultima Modificacion");

            builder.Property(e => e.Foto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Foto de la ubicacion");

            builder.Property(e => e.IdAsentamiento)
                .HasColumnName("idAsentamiento")
                .HasComment("el id de la tabla Asentamiento");

            builder.Property(e => e.Numero_Exterior)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Numero_Interior)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Referencia)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Referencias para identificar la direccion");

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
                .HasComment("Usuario que hizo la ultima modificacion");

            builder.HasOne(d => d.IdAsentamientoNavigation)
                .WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdAsentamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direccion_Asentamiento");

        }
    }
}
