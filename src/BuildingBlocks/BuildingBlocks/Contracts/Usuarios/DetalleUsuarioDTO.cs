namespace BuildingBlocks.Contracts.Usuarios;

public record DetalleUsuarioDTO(string Nombre,string Apellido, string Email, string NroDocumento, bool Activo, ICollection<string> sector, string rol, DateTime FechaCreacion, string NroTelefono);

