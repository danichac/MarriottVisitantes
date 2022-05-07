
namespace MarriottVisitantes.Dominio.DTOs
{
    public interface UsuarioCreacionDTO
    {
        public string UserName { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }  
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}