using Iam.Repository.Interfaces;
namespace Iam.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIamContext _context;
        private AccountRepository _accountRepository;
        private RolRepository _rolRepository;
        private SectorRepository _sectorRepository;
        private UsuarioXSectorRepository _usuarioXSectorRepository;

        public UnitOfWork(AppIamContext context)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_context);
        public IRolRepository RolRepository => _rolRepository ??= new RolRepository(_context);
        public ISectorRepository SectorRepository => _sectorRepository ??= new SectorRepository(_context);

        public IUsuarioXSectorRepository UsuarioXSectorRepository => _usuarioXSectorRepository ??= new UsuarioXSectorRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
