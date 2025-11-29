namespace Iam.Services.Interfaces
{
    public interface IRolService
    {
        Task<ICollection<string>> GetRolesAsync();
    }
}
