
namespace MarriottVisitantes.Dominio.DTOs
{
    public class BusquedaVisitantesDTO
    {
        public string Cedula { get; set; }  = string.Empty;
        public string Empresa { get; set; } = string.Empty;

        public BusquedaVisitantesDTO(string cedula, string empresa)
        {
            Cedula = cedula;
            Empresa = empresa;
        }
    }
}