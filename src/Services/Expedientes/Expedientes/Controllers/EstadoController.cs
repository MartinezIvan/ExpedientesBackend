using BuildingBlocks.Contracts.Expedientes;
using BuildingBlocks.Shared.Kernel;
using Expedientes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Expedientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController(IEstadoService estadoService) : ControllerBase
    {
        private readonly ILogger<EstadoController> _logger;
        private readonly IEstadoService _estadoService = estadoService;
        [HttpGet]
        public async Task<Result<ICollection<EstadoDTO>>> Get()
        {
            return Result<ICollection<EstadoDTO>>.Success(await _estadoService.GetAll());
        }
    }
}
