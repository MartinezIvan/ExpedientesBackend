using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;

namespace Expedientes.Repository.Repositories;

public class EstadoRepository(AppExpedientesContext context) : GenericRepository<Estado>(context), IEstadoRepository
{
    private readonly AppExpedientesContext _context = context;
}
