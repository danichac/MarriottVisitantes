using System.Collections.Generic;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Servicios.Interfaces
{
    public interface IServicioVisitante
    {
        public Task<Visitante> BuscarPorCedula(string cedula);
        public Task<Visitante> BuscarPorId(long id);
        public Task<IList<Visitante>> VisitantesPorEmpresa(string nombreEmpresa);
        public Task AgregarVisitante(Visitante visitante);
        public Task ActualizarVisitante(Visitante visitante);
        public Task<IList<string>> ObtenerTodasCedulas();
        public Task<IList<string>> ListaDeEmpresas();
        public Task<VisitantesPaginacionDTO> ListaVisitantesPaginacion(int paginaActual, BusquedaVisitantesDTO busqueda);
    }
}