namespace BuildingBlocks.Contracts.Usuarios;

public record UsuarioCreado(Guid UsuarioId, string Nombre, string Email, Guid SectorId);
