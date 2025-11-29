namespace BuildingBlocks.Contracts.Expedientes;

public class MovimientoRequest
{
    public Guid IdSector { get; set; }
    public Guid IdUsuario { get; set; }
    public Guid IdEstado { get; set; }
    public Guid IdExpediente { get; set; }
    public string Detalle { get; set; }
}
