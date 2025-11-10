using Iam.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iam.Repository.Configuration;

public class UsuarioXSectorConfiguration : IEntityTypeConfiguration<UsuarioXSector>
{
    public void Configure(EntityTypeBuilder<UsuarioXSector> b)
    {
        b.ToTable("UsuariosXSectores");
        b.HasKey(x => x.Id);

        b.Property(x => x.UsuarioId).IsRequired();
        b.Property(x => x.SectorId).IsRequired();
        b.Property(x => x.RolId).IsRequired();

        b.HasIndex(x => new { x.UsuarioId, x.SectorId, x.RolId }).IsUnique();

        b.HasOne(b => b.Usuario)
            .WithMany(b => b.Sectores)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(b => b.Sector)
            .WithMany(b => b.UsuarioXSector)
            .HasForeignKey(x => x.SectorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        b.HasOne(b => b.Rol)
            .WithMany(b => b.UsuarioXSector)
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

