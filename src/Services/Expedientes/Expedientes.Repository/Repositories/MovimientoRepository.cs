using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expedientes.Repository.Repositories;

public class MovimientoRepository(AppExpedientesContext context) : GenericRepository<Movimiento>(context), IMovimientoRepository
{
    private readonly AppExpedientesContext _context = context;

    public new async Task<ICollection<Movimiento>> GetAll()
    {
        return await _context.Movimientos
            .Include(m => m.Estado)
            .Include(m => m.Expediente)
            .ToListAsync();
    }
}
