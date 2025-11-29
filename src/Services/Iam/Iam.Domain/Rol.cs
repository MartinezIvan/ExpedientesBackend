namespace Iam.Domain
{
    public class Rol
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Descripcion { get; private set; } = default!;
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<UsuarioXSector>? UsuarioXSector { get; private set; } = default!;
        public Rol() { }
        public Rol(string descripcion)
        {
            Descripcion = descripcion;
        }
        public Rol(Guid id, string descripcion) : this(descripcion)
        {
            Id = id;
        }
    }
}