using Expedientes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Expedientes.Repository;
public class AppExpedientesContext : DbContext
{
    public AppExpedientesContext(DbContextOptions<AppExpedientesContext> options) : base(options) { }

    public DbSet<Expediente> Expedientes => Set<Expediente>();
    public DbSet<Movimiento> Movimientos => Set<Movimiento>();
    public DbSet<Foja> Fojas => Set<Foja>();
    public DbSet<Estado> Estados => Set<Estado>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppExpedientesContext).Assembly);
    }
}
