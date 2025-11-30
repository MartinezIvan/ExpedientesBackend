namespace BuildingBlocks.Contracts.Usuarios;
public record GetSectoresResponse(ICollection<GetSectorResponse> Sectores);
public record GetSectorResponse(Guid SectorId, string Nombre);
