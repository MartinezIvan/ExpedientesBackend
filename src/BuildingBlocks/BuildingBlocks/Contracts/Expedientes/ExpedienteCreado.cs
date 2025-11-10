namespace BuildingBlocks.Contracts.Expedientes;

public record ExpedienteCreado(Guid ExpedienteId, Guid UsuarioCreadorId, int EstadoInicial);
