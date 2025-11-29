namespace Expedientes.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFojaRepository FojaRepository { get; }
        IExpedienteRepository ExpedienteRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IMovimientoRepository MovimientoRepository { get; }
        Task SaveChangesAsync();
    }
}
