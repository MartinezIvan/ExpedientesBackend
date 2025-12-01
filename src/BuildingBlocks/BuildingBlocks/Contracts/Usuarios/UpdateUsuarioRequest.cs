namespace BuildingBlocks.Contracts.Usuarios;

public record UpdateUsuarioRequest(Guid Id, ICollection<Guid> IdSectores, Guid IdRol);

