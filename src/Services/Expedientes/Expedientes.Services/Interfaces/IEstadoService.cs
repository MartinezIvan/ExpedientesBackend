
using BuildingBlocks.Contracts.Expedientes;

namespace Expedientes.Services.Interfaces;

public interface IEstadoService
{
    Task<ICollection<EstadoDTO>> GetAll();
}
