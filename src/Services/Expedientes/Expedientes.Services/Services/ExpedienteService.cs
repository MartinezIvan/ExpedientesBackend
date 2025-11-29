using BuildingBlocks.Contracts.Expedientes;
using Expedientes.Repository.Interfaces;
using Expedientes.Services.Interfaces;
using Mapster;

namespace Expedientes.Services.Services;

public class ExpedienteService(IUnitOfWork unitOfWork) : IExpedienteService
{
    private readonly IExpedienteRepository _expedienteRepository = unitOfWork.ExpedienteRepository;
    public async Task<ICollection<ListadoExpedienteDTO>> GetAll()
    {
        var expedientes = await _expedienteRepository.GetAll();
        return expedientes.Adapt<ICollection<ListadoExpedienteDTO>>();
    //TODO: verificar mapeos
    }

    public async Task<DetalleExpedienteDTO> GetDetalle(Guid id)
    {
        var expedientes = await _expedienteRepository.GetById(id);
        return expedientes.Adapt<DetalleExpedienteDTO>();
        //TODO: verificar mapeos
    }
}
