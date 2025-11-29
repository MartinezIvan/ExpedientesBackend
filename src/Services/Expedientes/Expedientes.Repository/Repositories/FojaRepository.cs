using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;

namespace Expedientes.Repository.Repositories;

public class FojaRepository(AppExpedientesContext context) : GenericRepository<Foja>(context), IFojaRepository
{
    private readonly AppExpedientesContext _context = context;
}
