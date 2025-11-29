namespace BuildingBlocks.Contracts.Usuarios;

public record ListadoUsuarioDTO(string Nombre,string Apellido, string Email, string NroDocumento, bool Activo, ICollection<string> sector);

