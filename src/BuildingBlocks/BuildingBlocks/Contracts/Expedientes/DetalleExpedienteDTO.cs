namespace BuildingBlocks.Contracts.Expedientes;

public record DetalleExpedienteDTO(Guid Id, string Numero, string Tema, DateTime Fecha, string Observacion, Guid IdUsuario, string Estado, string subTema, DateTime FechaAlta, string Caratula, string Sector, ICollection<ResumenMovimientoDTO> Movimientos);

public record ResumenMovimientoDTO(Guid Id, DateTime Fecha, string Descripcion, Guid SectorOrigenId, Guid SectorDestinoId, Guid IdUsuario);