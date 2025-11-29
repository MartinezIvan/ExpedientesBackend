using Iam.Requests;

namespace Iam.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Guid> RegisterAsync(RegisterServiceRequest registerRequest);   

        Task<string> LoginAsync(string email, string password);
    }
}
