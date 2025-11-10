namespace Iam.Domain
{
    public class TipoDocumento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = default!;
        public ICollection<Usuario> Usuarios { get; set; }
    }
}