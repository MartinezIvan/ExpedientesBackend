using BuildingBlocks.Contracts.Expedientes;
using BuildingBlocks.Shared.Kernel;
using Expedientes.Domain;
using Expedientes.Services.Interfaces;
using Expedientes.Services.Services;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Expedientes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientoController(IMovimientoService movimientoService) : ControllerBase
    {
        private readonly IMovimientoService _movimientoService = movimientoService;
        
        [HttpPost]
        public async Task<Result<string>> CreateMovimiento([FromBody]MovimientoRequest movimiento)
        {
            var movimientoId = await _movimientoService.AltaMovimiento(movimiento);
            return Result<string>.Success(movimientoId.ToString());
        }

        [HttpGet]
        public async Task<Result<ICollection<ListadoMovimientoDTO>>> Get()
        {
            return Result<ICollection<ListadoMovimientoDTO>>.Success(await _movimientoService.GetMovimientos());
        }
    }
}
