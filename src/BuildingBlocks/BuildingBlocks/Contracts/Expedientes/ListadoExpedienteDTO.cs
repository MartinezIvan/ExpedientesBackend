namespace BuildingBlocks.Contracts.Expedientes;

public record ListadoExpedienteDTO(Guid Id, string Numero, string Tema, DateTime Fecha, string Observacion, Guid IdUsuario, string Estado, string subTema, DateTime FechaAlta, string Caratula, string Sector);
