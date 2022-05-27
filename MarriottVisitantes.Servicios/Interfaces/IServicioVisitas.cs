using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Servicios.Interfaces
{
    public interface IServicioVisitas
    {
        public Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual, bool terminada);
        public Task ActualizarVisita(Visita visita);
        public Task AgregarVisita(Visita visita);
        public Task<Visita> BuscarPorId(int id);
        public Task<IList<Visita>> GetVisitasPorVisitante(int idVisitante); 
        public Task<IList<Visita>> BuscarPorFecha(DateTime fecha);
        public Task<VisitasPaginacionDTO> BuscarPorFechaPaginacion(int paginaActual, DateTime fecha);
    }
}