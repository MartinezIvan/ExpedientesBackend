using Iam.Domain;

namespace Iam.Repository.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> CreateAccountAsync(Usuario usuario);
        Task<Guid?> Login(string email, string password);
    }
}
