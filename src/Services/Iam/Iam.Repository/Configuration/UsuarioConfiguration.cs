using Iam.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iam.Repository.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> b)
    {
        b.ToTable("Usuarios");
        b.HasKey(x => x.Id);

        b.Property(x => x.Nombre).IsRequired().HasMaxLength(120);
        b.Property(x => x.Apellido).IsRequired().HasMaxLength(120);

        b.Property(x => x.Email).IsRequired().HasMaxLength(256);
        b.HasIndex(x => x.Email).IsUnique();

        b.Property(x => x.TipoDocumentoId).IsRequired();
        b.Property(x => x.NroDocumento).IsRequired().HasMaxLength(32);
        b.HasIndex(x => new { x.TipoDocumentoId, x.NroDocumento }).IsUnique();

        b.Property(x => x.Activo).IsRequired();

        b.Property(x => x.CreadoEnUtc).HasColumnType("datetime").IsRequired();
        b.Property(x => x.ActualizadoEnUtc).HasColumnType("datetime");

        b.HasOne(x => x.TipoDocumento)
            .WithMany(t => t.Usuarios)
            .HasForeignKey(x => x.TipoDocumentoId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Rol)
            .WithMany(r => r.Usuarios)
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
