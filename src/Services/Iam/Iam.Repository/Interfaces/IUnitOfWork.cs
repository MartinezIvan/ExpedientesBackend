namespace Iam.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        IRolRepository RolRepository { get; }
        ISectorRepository SectorRepository { get; }

        Task SaveChangesAsync();
    }
}
