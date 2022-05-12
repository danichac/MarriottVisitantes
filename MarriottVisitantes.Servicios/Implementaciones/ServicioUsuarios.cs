
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Identidad;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Servicios.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Servicios.Implementaciones
{
    public class ServicioUsuarios : IServicioUsuarios
    {

        private readonly IRepositorioUsuario _repositorio;
        private readonly UserManager<Usuario> _gestorUsuario;
    
        public ServicioUsuarios(IRepositorioUsuario repositorio, UserManager<Usuario> gestorUsuario)
        {
            _gestorUsuario = gestorUsuario;
            _repositorio = repositorio;
        }

        public async Task AgregarARol(Usuario usuario, string rol)
        {
            await _repositorio.AgregarARol(usuario, rol);
        }

        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return await _repositorio.BuscarPorEmailAsync(email);
        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            return await _repositorio.BuscarPorIdAsync(id);
        }

        public async Task<IdentityResult> CrearAsync(UsuarioCreacionDTO usuario)
        {
            var result = await _repositorio.CrearAsync(usuario);
            return result;
        }

        public async Task<bool> EmailExiste(string email)
        {
            return await _repositorio.EmailExiste(email);
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

        public async Task<bool> UserNameExiste(string userName)
        {
            return await _repositorio.UserNameExiste(userName);
        }
    }
}