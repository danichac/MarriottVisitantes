using System;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarriottVisitantes.Repositorio.Implementaciones
{
    public class RepositorioVisitas : IRepositorioVisitas
    {
        private readonly MarriottVisitantesDbContext _context;

        public RepositorioVisitas(MarriottVisitantesDbContext context)
        {
            _context = context;
        }

        public async Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual)
        {
            int resultadosPorPagina = 10;
            var visitas = new VisitasPaginacionDTO();

            visitas.Visitas = await _context.Visitas
                .Select(x => x).Include(x => x.ColorGafete)
                .Include(x => x.Visitante)
                .OrderByDescending(x => x.FechaVisita).ThenByDescending(x => x.HoraEntrada)
                .Skip((paginaActual - 1) * resultadosPorPagina)
                .Take(resultadosPorPagina).ToListAsync();

            var cantidadPaginas = (double)((decimal) await _context.Visitas.CountAsync() / Convert.ToDecimal(resultadosPorPagina));
            visitas.CantidadPaginas = (int)Math.Ceiling(cantidadPaginas);
            visitas.IndicePagina = paginaActual;

            return visitas;
        }
    }
}