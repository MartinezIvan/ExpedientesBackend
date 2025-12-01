using Iam.Domain;
using Iam.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Iam.Repository.Repositories
{
    public class AccountRepository(AppIamContext context) : GenericRepository<Usuario>(context), IAccountRepository
    {
        private readonly AppIamContext _context = context;
        public async Task<Usuario> CreateAccountAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Guid?> Login(string email, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
            return usuario?.Id;
        }

        public new async Task<Usuario?> GetById(Guid guid)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.Sectores)
                .ThenInclude(us => us.Sector)
                .FirstOrDefaultAsync(u => u.Id == guid);
        }

        public new async Task<ICollection<Usuario>> GetAll()
        {
            return await _context.Usuarios
                        .Include(u => u.Sectores)
                        .ThenInclude(us => us.Sector)
                        .ToListAsync();

        }
    }
}
