namespace Iam.Domain
{
    public class Sector
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nombre { get; private set; } = default!;

        public ICollection<UsuarioXSector>? UsuarioXSector { get; private set; } = default!;
        public Sector() { }
        public Sector(string nombre)
        {
            Nombre = nombre;
        }
        public Sector(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void AsignarSector(Usuario usuario, Rol rol)
        {
            UsuarioXSector ??= new List<UsuarioXSector>();
            UsuarioXSector.Add(new UsuarioXSector(usuario.Id, Id, rol.Id));
        }
    }
}