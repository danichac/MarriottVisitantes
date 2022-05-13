using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarriottVisitantes.Dominio.DTOs;
using System;

namespace MarriottVisitantes.Repositorio.Implementaciones
{
    public class RepositorioVisitante : IRepositorioVisitante
    {
        private readonly MarriottVisitantesDbContext _context;

        public RepositorioVisitante(MarriottVisitantesDbContext context)
        {
            _context = context;
        }

        public async Task ActualizarVisitante(Visitante visitante)
        {
            _context.Visitantes.Update(visitante);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarVisitante(Visitante visitante)
        {
            _context.Visitantes.Add(visitante);
            await _context.SaveChangesAsync();
        }

        public async Task<Visitante> BuscarPorCedula(string cedula)
        {
            var visitante = await _context.Visitantes
                .Include(v => v.Visitas)
                .Where(v => v.Cedula == cedula)
                .FirstOrDefaultAsync();

            return visitante;
        }

        public async Task<Visitante> BuscarPorId(int id)
        {
            return await _context.Visitantes.Where(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<string>> ListaDeEmpresas()
        {
            return await _context.Visitantes.Select(x => x.NombreEmpresa).Distinct().ToListAsync();
        }

        public async Task<VisitantesPaginacionDTO> ListaVisitantesPaginacion(int paginaActual, BusquedaVisitantesDTO busqueda)
        {
            int resultadosPorPagina = 10;
            var visitas = new VisitantesPaginacionDTO();

            visitas.Visitantes = await _context.Visitantes
                .Where(v => v.Cedula == busqueda.Cedula || v.NombreEmpresa == busqueda.Empresa)
                .Select(v => v)
                .OrderBy(v => v.Cedula)
                .Skip((paginaActual - 1) * resultadosPorPagina)
                .Take(resultadosPorPagina).ToListAsync();

            var cantidadPaginas = (double)((decimal) await _context.Visitantes.CountAsync() / Convert.ToDecimal(resultadosPorPagina));
            visitas.CantidadPaginas = (int)Math.Ceiling(cantidadPaginas);
            visitas.IndicePagina = paginaActual;

            return visitas;
        }

        public async Task<IList<string>> ObtenerTodasCedulas()
        {
            return await _context.Visitantes.Select(x => x.Cedula).ToListAsync();
        }

        public async Task<IList<Visitante>> VisitantesPorEmpresa(string nombreEmpresa)
        {
            var visitantes = await _context.Visitantes
                .Where(v => v.NombreEmpresa == nombreEmpresa)
                .ToListAsync();

            return visitantes;
        }

        
    }
}