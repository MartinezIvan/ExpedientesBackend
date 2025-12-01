namespace Iam.Domain
{
    public class UsuarioXSector
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UsuarioId { get; private set; }
        public Guid SectorId { get; private set; }
        public Guid RolId { get; private set; }
        
        public Sector Sector { get; private set; } = default!;
        public Usuario Usuario { get; private set; } = default!;
        public Rol Rol { get; private set; } = default!;
        private UsuarioXSector() { }
        public UsuarioXSector(Guid sectorId, Guid rolId, bool esPrincipal = false)
        {
            SectorId = sectorId;
            RolId = rolId;
        }

        public UsuarioXSector(Guid idUsuario, Guid sectorId, Guid rolId, bool esPrincipal = false): this(sectorId, rolId, esPrincipal)
        {
            UsuarioId = idUsuario;
        }
    }
}