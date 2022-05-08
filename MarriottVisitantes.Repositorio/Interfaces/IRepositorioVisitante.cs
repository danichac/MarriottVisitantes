using System.Collections.Generic;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Repositorio.Interfaces
{
    public interface IRepositorioVisitante
    {
        public Task<Visitante> BuscarPorCedula(string cedula);
        public Task<IList<Visitante>> VisitantesPorEmpresa(string nombreEmpresa);
        public Task AgregarVisitante(Visitante visitante);
        public Task ActualizarVisitante(Visitante visitante);
    }
}