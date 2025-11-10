using Expedientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedientes.Repository.Configuration;

public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
{
    public void Configure(EntityTypeBuilder<Movimiento> b)
    {
        b.ToTable("Movimientos");
        b.HasKey(x => x.Id);

        b.Property(x => x.Detalle)
            .HasMaxLength(1000);

        b.Property(x => x.EstadoId);
        b.Property(x => x.SectorDesdeId);
        b.Property(x => x.SectorHastaId);

        b.Property(x => x.Fecha)
            .HasColumnType("datetime")
            .IsRequired();


        b.HasIndex(x => new { x.ExpedienteId, x.Fecha });
    }
}
