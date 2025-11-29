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

            modelBuilder.Entity<Sector>().HasData(
                new Sector(Guid.Parse("291aefbb-1f66-4aff-a30c-6163d726c43c"), "Desarrollo"),
                new Sector(Guid.Parse("c6eb1013-ea61-4f0d-9774-ace21596a02a"), "Diseño"),
                new Sector(Guid.Parse("faafefc4-9368-4624-93ac-1b7a734e7000"), "Calidad"),
                new Sector(Guid.Parse("e69d41f0-5a46-4b9d-840a-dd76d55c92cd"), "Investigacion"),
                new Sector(Guid.Parse("e6f5f7ca-079e-4a5c-b1cb-d03f953a21b2"), "Administracion")
            );

            modelBuilder.Entity<TipoDocumento>().HasData(
                new TipoDocumento(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "DNI"),
                new TipoDocumento(Guid.Parse("e9210cfd-f497-428a-81d9-dd7cae9a0adf"), "Pasaporte"),
                new TipoDocumento(Guid.Parse("34ed1c14-f92a-4b29-b5e4-4a0fef9e9ec3"), "Cedula de Ciudadania")
            );
        }

    }
}
