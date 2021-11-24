using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ConfiguracionDireccion : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> entity)
        {
            entity.HasKey(e => e.IdDireccion);

            entity.ToTable("Direccion");

            entity.HasComment("Registra todas las direcciones");

            entity.HasIndex(e => e.IdAsentamiento, "IXFK_Direccion_Asentamiento");

            entity.Property(e => e.IdDireccion).HasComment("Id Numerico Consecutivo de direcciones");

            entity.Property(e => e.Calle)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.CoordenadasGeo).HasComment("Coordenadas geograficas , Acepta nulos");

            entity.Property(e => e.EntreLaCalle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EsFiscal).HasComment("Si la direccion es fiscal para la emision de facturas");

            entity.Property(e => e.EsHabilitado).HasComment("Si esta disponible el registro");

            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Estatus de la direccion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la Ultima Modificacion");

            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Foto de la ubicacion");

            entity.Property(e => e.IdAsentamiento)
                .HasColumnName("idAsentamiento")
                .HasComment("el id de la tabla Asentamiento");

            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Referencia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Referencias para identificar la direccion");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que hizo la ultima modificacion");

            entity.Property(e => e.YlaCalle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("YLaCalle");

            entity.HasOne(d => d.IdAsentamientoNavigation)
                .WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdAsentamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direccion_Asentamiento");

        }
    }
}
