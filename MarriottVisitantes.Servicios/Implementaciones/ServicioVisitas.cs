
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Servicios.Interfaces;

namespace MarriottVisitantes.Servicios.Implementaciones
{
    public class ServicioVisitas : IServicioVisitas
    {
        private readonly IRepositorioVisitas _repositorioVisitas;

        public ServicioVisitas(IRepositorioVisitas repositorioVisitas)
        {
            _repositorioVisitas = repositorioVisitas;
        }
        public async Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual)
        {
            return await _repositorioVisitas.ObtenerVisitas(paginaActual);
        }
    }
}