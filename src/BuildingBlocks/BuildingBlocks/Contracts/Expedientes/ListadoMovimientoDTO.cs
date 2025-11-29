namespace BuildingBlocks.Contracts.Expedientes;

public record ListadoMovimientoDTO(Guid Id, Guid ExpedienteId, DateTime Fecha, string Detalle, Guid IdSectorOrigen, Guid IdSectorDestino, Guid UsuarioId, string EstadoExpediente,DateTime FechaCreacion);
