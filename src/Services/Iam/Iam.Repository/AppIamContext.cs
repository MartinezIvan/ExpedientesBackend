using Iam.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Iam.Repository
{
    public class AppIamContext : DbContext
    {
        public AppIamContext(DbContextOptions<AppIamContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Sector> Sectores => Set<Sector>();
        public DbSet<UsuarioXSector> UsuariosXSectores => Set<UsuarioXSector>();
        public DbSet<TipoDocumento> TiposDocumento => Set<TipoDocumento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppIamContext).Assembly);

            modelBuilder.Entity<Rol>().HasData(
                new Rol(Guid.Parse("10000000-0000-0000-0000-000000000001"), "Admin"),
                new Rol(Guid.Parse("10000000-0000-0000-0000-000000000002"), "Usuario")
            );
        }

    }
}
