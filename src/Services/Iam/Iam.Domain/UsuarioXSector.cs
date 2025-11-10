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
        public UsuarioXSector(Guid usuarioId, Guid sectorId, Guid rolId, bool esPrincipal = false)
        {
            UsuarioId = usuarioId;
            SectorId = sectorId;
            RolId = rolId;
        }
    }
}