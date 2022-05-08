using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;
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

        public async Task ActualizarVisita(Visita visita)
        {
            _context.Visitas.Update(visita);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarVisita(Visita visita)
        {
            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();
        }

        public Task<Visita> BuscarPorId(int id)
        {
            var visita = _context.Visitas.Where(v => v.IdVisita == id)
                .FirstOrDefaultAsync();
            return visita;
        }

        public async Task<IList<Visita>> GetVisitasPorVisitante(int idVisitante)
        {
            var visitas = await _context.Visitas.Where(v => v.IdVisitante == idVisitante)
                .Select(v => v)
                .ToListAsync();
            
            return visitas;
        }

        public async Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual, bool terminada)
        {
            int resultadosPorPagina = 10;
            var visitas = new VisitasPaginacionDTO();

            visitas.Visitas = await _context.Visitas
                .Where(x => x.VisitaTerminada == terminada)
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