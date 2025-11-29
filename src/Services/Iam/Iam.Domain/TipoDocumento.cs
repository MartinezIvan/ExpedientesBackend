namespace Iam.Domain
{
    public class TipoDocumento
    {
        public TipoDocumento()
        {
            
        }
        public TipoDocumento(Guid guid, string nombre)
        {
            Id = guid;
            Nombre = nombre;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = default!;
        public ICollection<Usuario> Usuarios { get; set; }
    }
}