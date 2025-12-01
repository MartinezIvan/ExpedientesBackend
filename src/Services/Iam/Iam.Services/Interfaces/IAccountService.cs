using BuildingBlocks.Contracts.Usuarios;
using Iam.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Iam.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> RegisterAsync(RegisterServiceRequest registerRequest);   

        Task<string> LoginAsync(string email, string password);
        Task<ICollection<ListadoUsuarioDTO>> ObtenerUsuarios();
        Task<DetalleUsuarioDTO> ObtenerDetalle(Guid guid);
        Task<InfoUserActivo> ObtenerRolYSectores(Guid guid);
        Task<string> DesactivarUsuario(Guid idUsuario);
        Task<string> UpdateUsuario(UpdateUsuarioRequest updateRequest);
    }
}
