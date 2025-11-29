using BuildingBlocks.Contracts.Expedientes;
using Expedientes.Domain;
using Mapster;

public class MapsterConfiguration
{
    public static void ConfigureMapster()
    {
        ConfigureMovimientoMapster();
        ConfigureEstadoMapster();
    }

    private static void ConfigureMovimientoMapster()
    {
        TypeAdapterConfig<Movimiento, ListadoMovimientoDTO>
            .NewConfig()
            .Map(dest => dest.Fecha, src => src.Fecha)
            .Map(dest => dest.FechaCreacion, src => src.Expediente.FechaAlta)
            .Map(dest => dest.IdSectorOrigen, src => src.SectorDesdeId)
            .Map(dest => dest.IdSectorDestino, src => src.SectorHastaId)
            .Map(dest => dest.EstadoExpediente, src => src.Estado.Descripcion)
            .Map(dest => dest.Detalle, src => src.Detalle);

    }


    private static void ConfigureEstadoMapster()
    {
        TypeAdapterConfig<Estado, EstadoDTO>
            .NewConfig()
            .Map(dest => dest.Nombre, src => src.Descripcion);

    }
}