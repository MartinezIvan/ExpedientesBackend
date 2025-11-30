namespace Expedientes.Domain;

public class Movimiento
{
    private Movimiento() { }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime Fecha { get; private set; } = DateTime.UtcNow;
    public string? Detalle { get; private set; }
    public Guid EstadoId { get; set; }
    public Guid UsuarioId { get; set; }
    public Estado Estado { get; private set; }
    public Guid SectorDesdeId { get; private set; }
    public Guid SectorHastaId { get; private set; }
    public Guid ExpedienteId { get; private set; }
    public Expediente Expediente { get; private set; } = default!;


    private Movimiento(Guid expedienteId, Guid usuarioId, Guid estadoId, string? detalle = null)
    {
        ExpedienteId = expedienteId;
        Detalle = detalle;
        EstadoId = estadoId;
    }

    public static Movimiento Derivacion(Guid expedienteId, Guid usuarioId, Guid sectorDesde, Guid sectorHasta, Guid estadoId, string? detalle) =>
        new(expedienteId, usuarioId, estadoId, detalle)
        {
            SectorDesdeId = sectorDesde,
            SectorHastaId = sectorHasta
        };

    public static Movimiento CambioEstado(Guid idExpediente, Guid idUsuario, Guid idSectorActual, Guid idEstado, string detalle) => new(idExpediente, idUsuario, idEstado, detalle)
    {
        SectorDesdeId = idSectorActual,
        SectorHastaId = idSectorActual
    };
}
