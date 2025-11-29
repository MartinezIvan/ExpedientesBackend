using BuildingBlocks.Contracts.Usuarios;

namespace Iam.Services.Interfaces;

public interface ISectorService
{
    Task<ICollection<SectoresSeleccionDTO>> ObtenerSectoresParaSeleccion();
}
