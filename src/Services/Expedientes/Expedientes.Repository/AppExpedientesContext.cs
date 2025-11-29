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

        modelBuilder.Entity<Estado>().HasData(
                new Estado(Guid.Parse("fc43dac0-a951-4107-86e5-d63cdaf764e2"), "Creado"),
                new Estado(Guid.Parse("e5b8de27-5d78-457a-913d-89a4e634b0c6"), "En revisión"),
                new Estado(Guid.Parse("be14b378-9742-4c20-bdfe-0bf9d8eacc0e"), "En progreso"),
                new Estado(Guid.Parse("1907e192-d38e-4564-a949-cfad5af7ee0a"), "Aprobado"),
                new Estado(Guid.Parse("1fbf4dc3-cb0c-405e-b0a4-9ea72076b637"), "Rechazado"),
                new Estado(Guid.Parse("80d71e53-5ab3-418b-91ed-980b2e40595e"), "Completado")
            );
    }
}
