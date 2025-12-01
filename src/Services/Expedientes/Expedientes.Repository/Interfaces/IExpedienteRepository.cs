using Expedientes.Domain;
using Expedientes.Repository.Interfaces.Iam.Repository.Interfaces;

namespace Expedientes.Repository.Interfaces;

public interface IExpedienteRepository : IGenericRepository<Expediente>
{
    new Task<ICollection<Expediente>> GetAll();
    new Task<Expediente?> GetById(Guid id);
    Task<ICollection<Expediente>> GetExpedientesDeSectores(ICollection<Guid> idSectores);
}
