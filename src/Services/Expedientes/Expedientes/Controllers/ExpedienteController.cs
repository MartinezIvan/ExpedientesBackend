using BuildingBlocks.Contracts.Expedientes;
using BuildingBlocks.Shared.Kernel;
using Expedientes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expedientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpedienteController(IExpedienteService expedienteService) : ControllerBase
    {
        private readonly IExpedienteService _expedienteService = expedienteService;
        [HttpGet]
        public async Task<Result<ICollection<ListadoExpedienteDTO>>> Get()
        {
            return Result<ICollection<ListadoExpedienteDTO>>.Success(await _expedienteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Result<DetalleExpedienteDTO>> GetDetalle(Guid id)
        {
            return Result<DetalleExpedienteDTO>.Success(await _expedienteService.GetDetalle(id));
        }

        [HttpGet]
        [Route("GetNumeroExpedienteNuevo")]
        public async Task<Result<string>> GetNumero()
        {
            return Result<string>.Success(await _expedienteService.VerificarNumeroExpediente());
        }
        
        [HttpGet]
        [Route("VerificarNumeroDeExpediente/{numero}")]
        public async Task<Result<string>> GetNumero(string numero)
        {
            return Result<string>.Success(await _expedienteService.GetNumeroExpedienteNuevo(numero));
        }
        [HttpGet]
        [Route("EstadisticasSectores")]
        public async Task<Result<EstadisticasDTO>> GetNumero(ICollection<Guid> idSectores)
        { 
            return Result<EstadisticasDTO>.Success(await _expedienteService.GetEstadisticasSectores(idSectores));
        }

        [HttpPost]
        public async Task<Result<string>> Post([FromBody]ExpedienteRequest value)
        {
            return Result<string>.Success(await _expedienteService.AltaExpediente(value));
        }

        [HttpPut("{id}")]
        public async Task<Result<string>> Put(Guid id, [FromBody] ExpedienteRequest value)
        {
            return Result<string>.Success(await _expedienteService.EditarExpediente(id, value));
        }
    }
}
