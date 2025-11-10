namespace Expedientes.Domain;

public class Movimiento
{
    private Movimiento() { }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime Fecha { get; private set; } = DateTime.UtcNow;
    public string? Detalle { get; private set; }
    public Guid EstadoId { get; set; }
    public Estado Estado { get; private set; }
    public Guid SectorDesdeId { get; private set; }
    public Guid SectorHastaId { get; private set; }
    public Guid ExpedienteId { get; private set; }
    public Expediente Expediente { get; private set; } = default!;


    private Movimiento(Guid expedienteId, Guid usuarioId, string tipo, Estado estado, string? detalle = null)
    {
        ExpedienteId = expedienteId;
        Detalle = detalle;
        Estado = estado;
    }

    public static Movimiento Derivacion(Guid expedienteId, Guid usuarioId, Guid sectorDesde, Guid sectorHasta, Estado estado, string? detalle) =>
        new(expedienteId, usuarioId, "Derivacion", estado, detalle)
        {
            SectorDesdeId = sectorDesde,
            SectorHastaId = sectorHasta
        };
}
