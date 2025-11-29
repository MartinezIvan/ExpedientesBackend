using BuildingBlocks.Contracts.Expedientes;
using Expedientes.Repository.Interfaces;
using Expedientes.Services.Interfaces;
using Mapster;

namespace Expedientes.Services.Services;

public class EstadoService(IUnitOfWork unitOfWork) : IEstadoService
{
    private readonly IEstadoRepository _estadoRepository = unitOfWork.EstadoRepository;
    public async Task<ICollection<EstadoDTO>> GetAll()
    {
        var estados = await _estadoRepository.GetAll();
        return estados.Adapt<ICollection<EstadoDTO>>();
    }
}
