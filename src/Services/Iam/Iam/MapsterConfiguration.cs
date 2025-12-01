
using BuildingBlocks.Contracts.Usuarios;
using Iam.Domain;
using Mapster;

public class MapsterConfiguration
{
    public static void ConfigureMapster()
    {
        ConfigureUsuarioMapster();
        ConfigureSectorMapster();
    }

    private static void ConfigureUsuarioMapster()
    {
        TypeAdapterConfig<Usuario, ListadoUsuarioDTO>
            .NewConfig()
            .Map(dest => dest.Sector, src => src.Sectores.Select(s => s.Sector.Nombre).ToList());

        TypeAdapterConfig<Usuario, DetalleUsuarioDTO>
            .NewConfig()
            .Map(dest => dest.Sector, src => src.Sectores.Select(s => s.Sector.Nombre).ToList())
            .Map(dest => dest.FechaCreacion, src => src.CreadoEnUtc)
            .Map(dest => dest.Rol, src => src.Rol.Descripcion);
    }

    private static void ConfigureSectorMapster()
    {
        TypeAdapterConfig<SectoresSeleccionDTO, GetSectorResponse>
            .NewConfig()
            .Map(dest => dest.SectorId, src => src.Id);
    }
}