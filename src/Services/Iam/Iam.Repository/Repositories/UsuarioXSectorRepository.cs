using Iam.Domain;
using Iam.Repository.Interfaces;

namespace Iam.Repository.Repositories;

public class UsuarioXSectorRepository(AppIamContext context) : GenericRepository<UsuarioXSector>(context), IUsuarioXSectorRepository
{
}
