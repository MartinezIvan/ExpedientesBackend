using Expedientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedientes.Repository.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> b)
    {
        b.ToTable("Estados");
        b.HasKey(x => x.Id);

        b.Property(x => x.Descripcion)
            .IsRequired()
            .HasMaxLength(500);

        b.HasMany(x => x.Expedientes)
            .WithOne(x => x.EstadoActual)
            .HasForeignKey(x => x.EstadoActualId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        b.HasMany(x => x.Movimientos)
            .WithOne(x => x.Estado)
            .HasForeignKey(x => x.EstadoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
