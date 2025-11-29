using BuildingBlocks.Contracts.Expedientes;

namespace Expedientes.Services.Interfaces;

public interface IExpedienteService
{
    Task<ICollection<ListadoExpedienteDTO>> GetAll();
    Task<DetalleExpedienteDTO> GetDetalle(Guid id);
}
