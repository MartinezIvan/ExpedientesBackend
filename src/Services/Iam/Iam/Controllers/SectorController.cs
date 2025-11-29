using BuildingBlocks.Contracts.Usuarios;
using BuildingBlocks.Shared.Kernel;
using Iam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SectorController(ISectorService sectorService) : ControllerBase
    {
        private readonly ISectorService _sectorService = sectorService;
        
        [HttpGet]
        public async Task<Result<ICollection<SectoresSeleccionDTO>>> GetSectores()
        {
            return Result<ICollection<SectoresSeleccionDTO>>.Success(await _sectorService.ObtenerSectoresParaSeleccion());
        }
    }
}
