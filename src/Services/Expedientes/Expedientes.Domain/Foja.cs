namespace Expedientes.Domain;

public class Foja
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ExpedienteId { get; private set; }
    public string Detalle { get; private set; } = default!;
    public string? Url { get; private set; } = default!;
    public virtual Expediente? Expediente { get; private set; }
    private Foja() { }
    public Foja(Guid expedienteId, string detalle, string url)
    {
        ExpedienteId = expedienteId;
        Detalle = detalle;
        Url = url;
    }
}
