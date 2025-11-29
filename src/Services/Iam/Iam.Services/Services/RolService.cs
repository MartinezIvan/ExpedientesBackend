using Iam.Repository.Interfaces;
using Iam.Services.Interfaces;

namespace Iam.Services.Services;

public class RolService(IUnitOfWork unitOfWork) : IRolService
{
    private readonly IRolRepository _rolRepository = unitOfWork.RolRepository;
    public async Task<ICollection<string>> GetRolesAsync()
    {
        var roles = await _rolRepository.GetAll();
        return [.. roles.Select(r => r.Descripcion)];
    }
}
