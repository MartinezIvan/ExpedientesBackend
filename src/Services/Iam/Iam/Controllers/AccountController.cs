using BuildingBlocks.Contracts.Usuarios;
using BuildingBlocks.Shared.Kernel;
using Iam.Requests;
using Iam.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Iam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }
        
        [HttpPost("Login")]
        public async Task<Result<IActionResult>> Login([FromBody]LoginRequest loginRequest)
        {
            return Result<IActionResult>.Success(Ok(await _accountService.LoginAsync(loginRequest.Email, loginRequest.Password)));
        }

        [HttpPost("Register")]
        public async Task<Result<IActionResult>> Register([FromBody]RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return Result<IActionResult>.Failure(HttpStatusCode.BadRequest, "Confirmar datos del registro");
            }
            return Result<IActionResult>.Success(Ok(await _accountService.RegisterAsync(registerRequest.Adapt<RegisterServiceRequest>())));
        }

        [HttpGet]
        public Task<Result<ICollection<ListadoUsuarioDTO>>> Get()
        {
            return Result<ICollection<ListadoUsuarioDTO>>.Success(await _accountService.ObtenerUsuarios());
        }

        [HttpGet("guid")]
        public Task<Result<DetalleUsuarioDTO>> Get(Guid guid)
        {
            if (!ModelState.IsValid)
            {
                return Result<IActionResult>.Failure(HttpStatusCode.BadRequest, "Guid no proporcionado o incorrecto");
            }
            return Result<DetalleUsuarioDTO>.Success(await _accountService.ObtenerDetalle(guid));
        }
    }
}
