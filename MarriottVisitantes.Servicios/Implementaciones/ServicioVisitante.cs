using System.Collections.Generic;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Servicios.Interfaces;

namespace MarriottVisitantes.Servicios.Implementaciones
{
    public class ServicioVisitante : IServicioVisitante
    {
        private readonly IRepositorioVisitante _repositorioVisitante;

        public ServicioVisitante(IRepositorioVisitante repositorioVisitante)
        {
            _repositorioVisitante = repositorioVisitante;
        }

        public async Task ActualizarVisitante(Visitante visitante)
        {
            await _repositorioVisitante.ActualizarVisitante(visitante);
        }

        public async Task AgregarVisitante(Visitante visitante)
        {
            await _repositorioVisitante.AgregarVisitante(visitante);
        }

        public async Task<Visitante> BuscarPorCedula(string cedula)
        {
            return await _repositorioVisitante.BuscarPorCedula(cedula);
        }

        public async Task<Visitante> BuscarPorId(long id)
        {
            return await _repositorioVisitante.BuscarPorId(id);
        }

        public async Task<IList<string>> ListaDeEmpresas()
        {
            return await _repositorioVisitante.ListaDeEmpresas();
        }

        public async Task<VisitantesPaginacionDTO> ListaVisitantesPaginacion(int paginaActual, BusquedaVisitantesDTO busqueda)
        {
            return await _repositorioVisitante.ListaVisitantesPaginacion(paginaActual, busqueda);
        }

        public async Task<IList<string>> ObtenerTodasCedulas()
        {
            return await _repositorioVisitante.ObtenerTodasCedulas();
        }

        public async Task<IList<Visitante>> VisitantesPorEmpresa(string nombreEmpresa)
        {
            return await _repositorioVisitante.VisitantesPorEmpresa(nombreEmpresa);
        }
    }
}