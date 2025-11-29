using Expedientes.Repository.Interfaces;

namespace Expedientes.Repository.Repositories;

public class UnitOfWork(AppExpedientesContext context) : IUnitOfWork
{
    private readonly AppExpedientesContext _context = context;
    private FojaRepository? _fojaRepository;
    private ExpedienteRepository? _expedienteRepository;
    private EstadoRepository? _estadoRepository;
    private MovimientoRepository? _movimientoRepository;

    public IFojaRepository FojaRepository => _fojaRepository ??= new FojaRepository(_context);

    public IExpedienteRepository ExpedienteRepository => _expedienteRepository ??= new ExpedienteRepository(_context);

    public IEstadoRepository EstadoRepository => _estadoRepository ??= new EstadoRepository(_context);

    public IMovimientoRepository MovimientoRepository => _movimientoRepository ??= new MovimientoRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
