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

            entity.HasIndex(e => e.AsentamientoId, "IXFK_Direccion_Asentamiento");

            entity.Property(e => e.IdDireccion).HasComment("Id Numerico Consecutivo de direcciones");

            entity.Property(e => e.Calle)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.CoordenadasGeo).HasComment("Coordenadas geograficas , Acepta nulos");

            entity.Property(e => e.EntreLaCalle)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EsFiscal).HasComment("Si la direccion es fiscal para la emision de facturas");

            entity.Property(e => e.EsHabilitado).HasComment("Si esta disponible el registro");

            entity.Property(e => e.Estatus)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength(true)
                .HasComment("Estatus de la direccion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de creacion del registro");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de la Ultima Modificacion");

            entity.Property(e => e.Foto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Foto de la ubicacion");

            entity.Property(e => e.AsentamientoId).HasComment("El id de la tabla Asentamiento");

            entity.Property(e => e.NumeroExterior)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.NumeroInterior)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Referencia)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Referencias para identificar la direccion");

            entity.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que creo el registro");

            entity.Property(e => e.UsuarioModificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Usuario que hizo la ultima modificacion");

            entity.Property(e => e.YlaCalle)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("YLaCalle");

            entity.HasOne(d => d.AsentamientoIdNavigation)
                .WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.AsentamientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direccion_Asentamiento");
        }
    }
}
