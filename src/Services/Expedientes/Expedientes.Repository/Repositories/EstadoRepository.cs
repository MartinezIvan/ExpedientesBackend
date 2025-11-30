using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expedientes.Repository.Repositories;

public class EstadoRepository(AppExpedientesContext context) : GenericRepository<Estado>(context), IEstadoRepository
{
    private readonly AppExpedientesContext _context = context;

    public async Task<Estado> ObtenerEstadoInicial()
    {
        return await _context.Estados.FirstOrDefaultAsync(e => e.Descripcion == "Creado");
    }
}
