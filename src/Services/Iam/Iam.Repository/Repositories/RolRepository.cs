using Iam.Domain;
using Iam.Repository.Interfaces;

namespace Iam.Repository.Repositories
{
    public class RolRepository (AppIamContext context) : GenericRepository<Rol>(context), IRolRepository
    {
    }
}
