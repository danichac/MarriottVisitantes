
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Repositorio.Identidad;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Repositorio.Interfaces
{
    public interface IRepositorioVisitas
    {
        public Task<VisitasPaginacionDTO> ObtenerVisitas(int paginaActual);

    }
}