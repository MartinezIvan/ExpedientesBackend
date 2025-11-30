using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expedientes.Repository.Repositories;

public class ExpedienteRepository(AppExpedientesContext context) : GenericRepository<Expediente>(context), IExpedienteRepository
{
    private readonly AppExpedientesContext _context = context;
    new public async Task<Expediente?> GetById(Guid id)
    {
        return await _context.Expedientes
            .Include(e => e.Movimientos)
            .Include(e => e.Fojas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ICollection<Expediente>> GetExpedientesDeSectores(ICollection<Guid> idSectores)
    {
        return await _context.Expedientes
            .Include(e => e.EstadoActual)
            .Where(c => idSectores.Contains(c.IdSectorActual))
            .ToListAsync();
    }
}
