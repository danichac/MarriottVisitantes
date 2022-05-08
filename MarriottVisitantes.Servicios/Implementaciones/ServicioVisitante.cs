using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IList<Visitante>> VisitantesPorEmpresa(string nombreEmpresa)
        {
            return await _repositorioVisitante.VisitantesPorEmpresa(nombreEmpresa);
        }
    }
}