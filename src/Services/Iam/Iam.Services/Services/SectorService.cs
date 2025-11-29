using BuildingBlocks.Contracts.Usuarios;
using Iam.Repository.Interfaces;
using Iam.Services.Interfaces;
using Mapster;

namespace Iam.Services.Services;

public class SectorService(IUnitOfWork unitOfWork) : ISectorService
{
    private readonly ISectorRepository _sectorRepository = unitOfWork.SectorRepository;

    public async Task<ICollection<SectoresSeleccionDTO>> ObtenerSectoresParaSeleccion()
    {
        var sector = await  _sectorRepository.GetAll();
        
        return sector.Adapt<ICollection<SectoresSeleccionDTO>>();
    }
}
