namespace BuildingBlocks.Contracts.Expedientes;

public record ExpedienteRequest(string Numero, Guid IdSector, Guid IdUsuario, string Tema, string Subtema, string Observaciones, string Caratula);

