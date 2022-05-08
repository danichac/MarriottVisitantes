
using System.Collections.Generic;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;
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

        public async Task ActualizarVisita(Visita visita)
        {
            await _repositorioVisitas.ActualizarVisita(visita);
        }

        public async Task AgregarVisita(Visita visita)
        {
            await _repositorioVisitas.AgregarVisita(visita);
        }

        public async Task<Visita> BuscarPorId(int id)
        {
            return await _repositorioVisitas.BuscarPorId(id);
        }

        public async Task<IList<Visita>> GetVisitasPorVisitante(int idVisitante)
        {
            return await _repositorioVisitas.GetVisitasPorVisitante(idVisitante);
        }

        public async Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual, bool terminada)
        {
            return await _repositorioVisitas.ObtenerVisitas(paginaActual, terminada);
        }
    }
}