using Expedientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expedientes.Repository.Configuration;

public class ExpedienteConfiguration : IEntityTypeConfiguration<Expediente>
{
    public void Configure(EntityTypeBuilder<Expediente> b)
    {
        b.ToTable("Expedientes");

        b.HasKey(x => x.Id);

        b.Property(x => x.Numero)
            .IsRequired()
            .HasMaxLength(32);

        b.Property(x => x.Numero);

        b.Property(x => x.Tema)
            .IsRequired()
            .HasMaxLength(200);

        b.Property(x => x.SubTema)
            .HasMaxLength(200);

        b.Property(x => x.Caratula)
            .IsRequired()
            .HasMaxLength(300);

        b.Property(x => x.Observacion)
            .HasMaxLength(1000);

        b.Property(x => x.UsuarioCreadorId).IsRequired();

        b.Property(x => x.FechaAlta)
            .HasColumnType("datetime")
            .IsRequired();

        b.HasMany(x => x.Movimientos)
            .WithOne(x => x.Expediente)
            .HasForeignKey(m => m.ExpedienteId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasMany(x => x.Fojas)
            .WithOne(x => x.Expediente)
            .HasForeignKey(f => f.ExpedienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}