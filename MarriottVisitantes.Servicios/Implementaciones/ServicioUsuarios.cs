
using System.Threading.Tasks;
using MarriottVisitantes.Repositorio.Identidad;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Servicios.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Servicios.Implementaciones
{
    public class ServicioUsuarios : IServicioUsuarios
    {

        private readonly IRepositorioUsuario _repositorio;
    
        public ServicioUsuarios(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return await _repositorio.BuscarPorEmailAsync(email);
        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            return await _repositorio.BuscarPorIdAsync(id);
        }

        public async Task<IdentityResult> CrearAsync(string userName, string email, string password)
        {
            return await _repositorio.CrearAsync(userName, email, password);
        }

        public async Task<bool> IngresarAsync(string email, string password, bool recordarme)
        {
            return await _repositorio.IngresarAsync(email, password, recordarme);
        }

        public async ValueTask<Usuario?> ObtenerUsuarioIngresadoAsync()
        {
            return await _repositorio.ObtenerUsuarioIngresadoAsync();
        }

        public async Task SalirAsync()
        {
            await _repositorio.SalirAsync();
        }
    }
}