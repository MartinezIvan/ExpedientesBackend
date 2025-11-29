using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;

namespace Expedientes.Repository.Repositories;

public class ExpedienteRepository(AppExpedientesContext context) : GenericRepository<Expediente>(context), IExpedienteRepository
{
    private readonly AppExpedientesContext _context = context;
}
