using BuildingBlocks.Shared.Kernel;
using Iam.Services.Interfaces;
using Iam.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController(IRolService rolService) : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly IRolService _rolService = rolService;

        [HttpGet]
        public async Task<Result<ICollection<string>>> GetRoles()
        {
            return Result<ICollection<string>>.Success(await _rolService.GetRolesAsync());
        }
    }
}
