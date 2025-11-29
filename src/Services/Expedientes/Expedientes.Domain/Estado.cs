namespace Expedientes.Domain;

public class Estado
{
    public Estado(){}
    public Estado(string desc)
    {
        Id = Guid.NewGuid();
        Descripcion = desc;
    }

    public Estado(Guid id, string desc)
    {
        Id = id;
        Descripcion = desc;
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Descripcion { get; private set; }

    public ICollection<Expediente> Expedientes { get; set; }
    public ICollection<Movimiento> Movimientos { get; set; }
}
