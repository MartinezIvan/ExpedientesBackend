using BuildingBlocks.Contracts.Expedientes;
using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Services.Interfaces;
using Mapster;

namespace Expedientes.Services.Services;

public class MovimientoService(IUnitOfWork unitOfWork) : IMovimientoService
{
    private readonly IMovimientoRepository _movimientoRepository = unitOfWork.MovimientoRepository;
    private readonly IExpedienteRepository _expedienteRepository = unitOfWork.ExpedienteRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Guid> AltaMovimiento(MovimientoRequest movimiento)
    {
        var expediente = await _expedienteRepository.GetById(movimiento.IdExpediente);
        if(expediente == null)
        {
            throw new Exception("El expediente no existe");
        }
        Movimiento movimientoNuevo;
        if(expediente.IdSectorActual == movimiento.IdSector)
        {
            movimientoNuevo = Movimiento.Derivacion(movimiento.IdExpediente, movimiento.IdUsuario, expediente.IdSectorActual, movimiento.IdSector, movimiento.IdEstado, movimiento.Detalle);
        }
        else
        {
            movimientoNuevo = Movimiento.CambioEstado(movimiento.IdExpediente, movimiento.IdUsuario, expediente.IdSectorActual, movimiento.IdEstado, movimiento.Detalle);
        }
        await _movimientoRepository.Insert(movimientoNuevo);
        await _unitOfWork.SaveChangesAsync();
        return movimientoNuevo.Id;
    }

    public async Task<ICollection<ListadoMovimientoDTO>> GetMovimientos()
    {
        var movimientos = await _movimientoRepository.GetAll();
        return movimientos.Adapt<ICollection<ListadoMovimientoDTO>>();
    }
}
