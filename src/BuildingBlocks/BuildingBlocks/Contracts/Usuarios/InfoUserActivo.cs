namespace BuildingBlocks.Contracts.Usuarios;

public record InfoUserActivo(Guid Id, Guid IdRol, string NombreRol, ICollection<SectoresAsignados> Sectores);
