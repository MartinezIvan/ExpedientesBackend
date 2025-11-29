namespace Expedientes.Domain
{
    public class Expediente
    {
        private Expediente() { }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Numero { get; private set; } = default!;     
        public string Tema { get; private set; } = default!;
        public string? SubTema { get; private set; }
        public string Caratula { get; private set; } = default!;
        public string? Observacion { get; private set; }
        public DateTime FechaAlta { get; private set; } = DateTime.UtcNow;
        public Guid EstadoActualId { get; private set; }
        public Estado EstadoActual { get; private set; }
        public Guid IdSectorActual { get; private set; }
        public Guid UsuarioCreadorId { get; private set; }

        public ICollection<Movimiento> Movimientos { get; set; }
        public ICollection<Foja> Fojas { get; set; }

        public Expediente(
            string numero, string tema, string caratula,
            Guid usuarioCreadorId,
            string? subTema = null, string? observacion = null)
        {
            Numero = numero;
            Tema = tema;
            Caratula = caratula;
            UsuarioCreadorId = usuarioCreadorId;
            SubTema = subTema;
            Observacion = observacion;
        }

        public void AgregarFoja(string detalle, string? url)
        {
            Fojas.Add(new Foja(Id, detalle, url));
        }
    }
}
