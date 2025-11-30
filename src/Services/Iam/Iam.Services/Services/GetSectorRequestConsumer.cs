using BuildingBlocks.Contracts.Usuarios;
using Iam.Domain;
using Iam.Services.Interfaces;
using Mapster;
using MassTransit;

namespace Iam.Services.Services;

public class GetSectorRequestConsumer(ISectorService sectorService) : IConsumer<GetSectorRequest>
{
    private readonly ISectorService _sectorService = sectorService;

    public async Task Consume(ConsumeContext<GetSectorRequest> context)
    {
        var sector = await _sectorService.ObtenerSectoresParaSeleccion();
        var idSector = context.Message.SectorId;
        var sectoresADevolver = sector.Where(x => !idSector.HasValue || x.Id == idSector);

        await context.RespondAsync(new GetSectoresResponse(sectoresADevolver.Adapt<ICollection<GetSectorResponse>>()));
    }
}
