namespace Iam.Domain
{
    public class Usuario
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nombre { get; private set; } = default!;
        public string Apellido { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public Guid TipoDocumentoId { get; private set; }
        public Guid RolId { get; private set; }
        public string NroDocumento { get; private set; } = default!;
        public string NroTelefono { get; private set; } = default!;
        public bool Activo { get; private set; } = true;
        public DateTime FechaNacimiento { get; private set; }

        public DateTime CreadoEnUtc { get; private set; } = DateTime.UtcNow;
        public DateTime? ActualizadoEnUtc { get; private set; }

        public TipoDocumento TipoDocumento { get; set; }
        public Rol Rol { get; set; }
        public ICollection<UsuarioXSector> Sectores { get; set; }

        private Usuario() { }

        public Usuario(string nombre, string apellido, string email, Guid tipoDocumentoId, string nroDocumento, DateTime fechaNacimiento, string nroTelefono, string hashedPassword, Guid rolId)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            TipoDocumentoId = tipoDocumentoId;
            NroDocumento = nroDocumento;
            FechaNacimiento = fechaNacimiento;
            NroTelefono = nroTelefono;
            PasswordHash = hashedPassword;
            RolId = rolId;
        }

        public void Activar() { Activo = true; ActualizadoEnUtc = DateTime.UtcNow; }
        public void Desactivar() { Activo = false; ActualizadoEnUtc = DateTime.UtcNow; }

        public void ActualizarDatos(string nombre, string apellido, string email)
        {
            Nombre = nombre; Apellido = apellido; Email = email;
            ActualizadoEnUtc = DateTime.UtcNow;
        }
    }
}
