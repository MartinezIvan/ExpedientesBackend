using Iam.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iam.Repository.Configuration;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> b)
    {
        b.ToTable("Sectores");
        b.HasKey(x => x.Id);
        b.Property(x => x.Id).ValueGeneratedOnAdd();
        b.Property(x => x.Nombre).IsRequired().HasMaxLength(120);
        b.HasIndex(x => x.Nombre).IsUnique();
    }
}
