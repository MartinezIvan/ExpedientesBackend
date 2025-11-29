namespace Iam.Requests
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Guid TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NroTelefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
