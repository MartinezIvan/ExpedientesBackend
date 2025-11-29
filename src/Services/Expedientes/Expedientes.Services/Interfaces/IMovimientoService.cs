using BuildingBlocks.Contracts.Expedientes;

namespace Expedientes.Services.Interfaces;

public interface IMovimientoService
{
    Task<Guid> AltaMovimiento(MovimientoRequest movimiento);
    Task<ICollection<ListadoMovimientoDTO>> GetMovimientos();
}
