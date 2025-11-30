using Expedientes.Domain;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;

namespace Expedientes.Repository.Interfaces;

public interface IEstadoRepository : IGenericRepository<Estado>
{
    Task<Estado> ObtenerEstadoInicial();
}
