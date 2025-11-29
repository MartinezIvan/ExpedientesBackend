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
            return Result< DetalleExpedienteDTO >.Success(await _expedienteService.GetDetalle(id));
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
