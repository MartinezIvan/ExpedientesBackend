using Iam.Domain;
using Iam.Repository.Interfaces;

namespace Iam.Repository.Repositories;

public class SectorRepository(AppIamContext context) : GenericRepository<Sector>(context), ISectorRepository
{
}
