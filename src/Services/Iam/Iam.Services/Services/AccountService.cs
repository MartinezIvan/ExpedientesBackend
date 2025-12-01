using BuildingBlocks.Contracts.Usuarios;
using Iam.Domain;
using Iam.Repository.Interfaces;
using Iam.Requests;
using Iam.Services.Interfaces;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Iam.Services.Services
{
    public class AccountService(IUnitOfWork unitOfWork) : IAccountService
    {
        private readonly IAccountRepository _accountRepository = unitOfWork.AccountRepository;
        private readonly IUsuarioXSectorRepository _usuarioXSectorRepository = unitOfWork.UsuarioXSectorRepository;
        private readonly IRolRepository _rolRepository = unitOfWork.RolRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private const string JwtSecretKey = "LaClaveSuperSeguraYMuyLarga1234567890";
        private const int TokenExpirationMinutes = 60;

        public async Task<string> LoginAsync(string email, string password)
        {
            var hashedPassword = HashPassword(password);
            var loginResult = await _accountRepository.Login(email, hashedPassword);
            if (loginResult.HasValue)
            {
                return GenerateJwtToken(loginResult.Value);
            }
            return string.Empty;
        }

        public async Task<Guid> RegisterAsync(RegisterServiceRequest registerRequest)
        {
            var rol = await _rolRepository.GetByCriteria(r => r.Descripcion == "Usuario");
            if (rol.Count == 0)
            {
                throw new Exception("Rol de usuario no encontrado");
            }
            var rolId = rol.FirstOrDefault().Id;
            var hashedPassword = HashPassword(registerRequest.Password);

            var registeredAccount = new Usuario(registerRequest.Nombre, registerRequest.Apellido, registerRequest.Email, registerRequest.TipoDocumentoId, registerRequest.NroDocumento, registerRequest.FechaNacimiento, registerRequest.NroTelefono, hashedPassword, rolId);
            var userCreated = await _accountRepository.CreateAccountAsync(registeredAccount);
            return userCreated.Id;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private string GenerateJwtToken(Guid userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", "Usuario"),
            new Claim("userId", userId.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: "Expedientes",
                audience: "Expedientes",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(TokenExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ICollection<ListadoUsuarioDTO>> ObtenerUsuarios()
        {
            var usuarios = await _accountRepository.GetAll();

            return usuarios.Adapt<ICollection<ListadoUsuarioDTO>>();
        }

        public async Task<DetalleUsuarioDTO> ObtenerDetalle(Guid guid)
        {
            var usuario = await _accountRepository.GetById(guid);
            return usuario is null ? throw new Exception("Usuario no encontrado") : usuario.Adapt<DetalleUsuarioDTO>();
        }

        public async Task<InfoUserActivo> ObtenerRolYSectores(Guid guid)
        {
            var usuario = await _accountRepository.GetById(guid);
            if(usuario.Sectores is null)
            {
            }
                Console.WriteLine(usuario.Sectores.Count);
            var sectores = usuario.Sectores.Select(s => new SectoresAsignados(s.SectorId, s.Sector.Nombre)).ToList();
            return usuario is null ? throw new Exception("Usuario no encontrado") : 
                new InfoUserActivo(guid, usuario.RolId, usuario.Rol.Descripcion, sectores);
        }

        public async Task<string> DesactivarUsuario(Guid idUsuario)
        {
            var usuario = await _accountRepository.GetById(idUsuario) ?? throw new Exception("Usuario no existente en BD");
            usuario.Desactivar();

            await _unitOfWork.SaveChangesAsync();
            return usuario.Id.ToString();
        }

        public async Task<string> UpdateUsuario(UpdateUsuarioRequest updateRequest)
        {
            var usuario = await _accountRepository.GetById(updateRequest.Id) ?? throw new Exception("Usuario no encontrado en BD");
            usuario.AsignarRol(updateRequest.IdRol);
            usuario.AsignarSectores(updateRequest.IdSectores);
            
            await _usuarioXSectorRepository.AddRange(usuario.Sectores);
            
            await _unitOfWork.SaveChangesAsync();
            return usuario.Id.ToString();
        }
    }
}
