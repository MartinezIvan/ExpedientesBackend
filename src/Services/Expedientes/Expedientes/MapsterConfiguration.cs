using BuildingBlocks.Contracts.Expedientes;
using Expedientes.Domain;
using Mapster;

public class MapsterConfiguration
{
    public static void ConfigureMapster()
    {
        ConfigureMovimientoMapster();
        ConfigureEstadoMapster();
        ConfigureExpedienteMapster();
    }

    private static void ConfigureExpedienteMapster()
    {
        TypeAdapterConfig<Expediente, DetalleExpedienteDTO>
            .NewConfig()
            .Map(dest => dest.IdUsuario, src => src.UsuarioCreadorId);
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

        TypeAdapterConfig<Movimiento, ResumenMovimientoDTO>
            .NewConfig()
            .Map(dest => dest.Fecha, src => src.Fecha)
            .Map(dest => dest.Descripcion, src => src.Detalle)
            .Map(dest => dest.SectorDestinoId, src => src.SectorHastaId)
            .Map(dest => dest.SectorOrigenId, src => src.SectorDesdeId)
            .Map(dest => dest.UsuarioId, src => src.UsuarioId);

    }


    private static void ConfigureEstadoMapster()
    {
        TypeAdapterConfig<Estado, EstadoDTO>
            .NewConfig()
            .Map(dest => dest.Nombre, src => src.Descripcion);

    }
}