using BuildingBlocks.Contracts.Expedientes;

namespace Expedientes.Services.Interfaces;

public interface IExpedienteService
{
    Task<string> AltaExpediente(ExpedienteRequest value);
    Task<string> EditarExpediente(Guid id, ExpedienteRequest value);
    Task<ICollection<ListadoExpedienteDTO>> GetAll();
    Task<DetalleExpedienteDTO> GetDetalle(Guid id);
    Task<EstadisticasDTO> GetEstadisticasSectores(ICollection<Guid> idSectores);
    Task<string> GetNumeroExpedienteNuevo(string numero);
    Task<string> VerificarNumeroExpediente();
}
