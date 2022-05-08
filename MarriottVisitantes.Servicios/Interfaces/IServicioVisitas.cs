using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.Servicios.Interfaces
{
    public interface IServicioVisitas
    {
        public Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual);
    }
}