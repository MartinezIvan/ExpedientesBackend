using BuildingBlocks.Contracts.Usuarios;
using Iam.Domain;
using Iam.Repository.Interfaces;
using Iam.Requests;
using Iam.Services.Interfaces;
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
        private readonly IRolRepository _rolRepository = unitOfWork.RolRepository;
        private const string JwtSecretKey = "LaClaveSecretaSuperSegura";
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
            new Claim("role", "User")
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

        public Task<ICollection<ListadoUsuarioDTO>> ObtenerUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<DetalleUsuarioDTO> ObtenerDetalle(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
