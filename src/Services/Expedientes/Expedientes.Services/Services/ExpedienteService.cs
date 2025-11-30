using BuildingBlocks.Contracts.Expedientes;
using BuildingBlocks.Contracts.Usuarios;
using Expedientes.Domain;
using Expedientes.Repository.Interfaces;
using Expedientes.Repository.Repositories;
using Expedientes.Services.Interfaces;
using Mapster;
using MassTransit;

namespace Expedientes.Services.Services;

public class ExpedienteService(IUnitOfWork unitOfWork, IRequestClient<GetSectorRequest> client) : IExpedienteService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IExpedienteRepository _expedienteRepository = unitOfWork.ExpedienteRepository;
    private readonly IEstadoRepository _estadoRepository = unitOfWork.EstadoRepository;
    private readonly IRequestClient<GetSectorRequest> _client = client;
    public async Task<ICollection<ListadoExpedienteDTO>> GetAll()
    {
        var expedientes = await _expedienteRepository.GetAll();
        var mensajeRta = await GetSector(null);
        var sectores = mensajeRta.Sectores;
        Console.WriteLine(sectores.Select(x => x.Nombre));

        var expedientesMapeados = expedientes.Adapt<ICollection<ListadoExpedienteDTO>>();

        var expedientesConSector = expedientes
            .Select(e => new ListadoExpedienteDTO
            (
                e.Id,
                e.Numero,
                e.Tema,
                e.FechaAlta,
                e.Observacion,
                e.UsuarioCreadorId,
                e.EstadoActual.Descripcion,
                e.SubTema,
                e.FechaAlta,
                e.Caratula,
                e.IdSectorActual,
                sectores.FirstOrDefault(x => x.SectorId == e.IdSectorActual)?.Nombre
            ))
            .ToList();

        return expedientesConSector;
    }

    public async Task<DetalleExpedienteDTO> GetDetalle(Guid id)
    {
        var expedientes = await _expedienteRepository.GetById(id);
        var mensajeRta = await GetSector(null);
        var sector = mensajeRta.Sectores.FirstOrDefault();

        var expedienteMapeado = expedientes.Adapt<DetalleExpedienteDTO>();
        return expedienteMapeado with
        {
            Sector = sector.Nombre
        }; ;
    }

    public async Task<string> VerificarNumeroExpediente()
    {
        var fechaActual = DateTime.Now;
        var ultimoExpediente = await _expedienteRepository.GetByCriteria(x => x.FechaAlta.Year == fechaActual.Year);
        var numeroAnterior = ultimoExpediente.OrderBy(x => x.FechaAlta).LastOrDefault()?.Numero;

        if(numeroAnterior is null)
        {
            return $"0000-{fechaActual.Year}-00";
        }
        var numeroNuevoDividido = numeroAnterior.Split('-');
        var numeroSecuencia = int.Parse(numeroNuevoDividido[0]) + 1;
        return $"{numeroSecuencia:D4}-{fechaActual.Year}-00";
    }

    public async Task<GetSectoresResponse> GetSector(Guid? sectorId)
    {
        var response = await _client.GetResponse<GetSectoresResponse>(new GetSectorRequest(sectorId));
        return response.Message;
    }

    public async Task<string> GetNumeroExpedienteNuevo(string numero)
    {
        string[] numeroDividido = ValidarNumero(numero);
        var existeExpediente = await _expedienteRepository.GetByCriteria(x => x.Numero == numero);
        if (existeExpediente.Count == 0)
        {
            var numeroEsperado = await VerificarNumeroExpediente();
            if (numeroEsperado != numero)
            {
                throw new InvalidOperationException("El número de expediente no existe.");
            }
            return numero;
        }
        var numeroAlcance = existeExpediente.Count;

        return $"{numeroDividido[0]}-{numeroDividido[1]}-{numeroAlcance:D2}";
    }

    private static string[] ValidarNumero(string numero)
    {
        var numeroDividido = numero.Split('-');
        if (numeroDividido.Length != 3)
        {
            throw new ArgumentException("El formato del número de expediente es incorrecto.");
        }

        return numeroDividido;
    }

    public async Task<string> AltaExpediente(ExpedienteRequest value)
    {
        var estadoInicial = await _estadoRepository.ObtenerEstadoInicial();
        ValidarNumero(value.Numero);
        var expediente = new Expediente(value.Numero, value.Tema,value.Caratula,value.IdUsuario, value.IdSector, estadoInicial.Id, value.Subtema,value.Observaciones);

        await _expedienteRepository.Insert(expediente);
        await _unitOfWork.SaveChangesAsync();
        
        return expediente.Id.ToString();
    }

    public async Task<string> EditarExpediente(Guid id,ExpedienteRequest value)
    {
        var expediente = await _expedienteRepository.GetById(id);
        expediente.Update(value);
        await _unitOfWork.SaveChangesAsync();
        return expediente.Id.ToString();
    }
}
