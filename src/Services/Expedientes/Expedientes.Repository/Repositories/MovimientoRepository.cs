using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;

namespace Expedientes.Repository.Repositories;

public class MovimientoRepository(AppExpedientesContext context) : GenericRepository<Movimiento>(context), IMovimientoRepository
{
    private readonly AppExpedientesContext _context = context;
}
