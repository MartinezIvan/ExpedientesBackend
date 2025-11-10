using Expedientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedientes.Repository.Configuration;

public class FojaConfiguration : IEntityTypeConfiguration<Foja>
{
    public void Configure(EntityTypeBuilder<Foja> b)
    {
        b.ToTable("Fojas");
        b.HasKey(x => x.Id);

        b.Property(x => x.Detalle)
            .IsRequired()
            .HasMaxLength(500);

        b.Property(x => x.Url)
            .IsRequired()
            .HasMaxLength(500);

        b.HasIndex(x => x.ExpedienteId);
    }
}

