
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Identidad;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Repositorio.Interfaces
{
    public interface IRepositorioUsuario
    {
        public Task<bool> IngresarAsync(string email, string password, bool recordarme);

        public Task SalirAsync();

        public Task<Usuario> BuscarPorEmailAsync(string email);

        public Task<Usuario> BuscarPorIdAsync(int id);

        public Task<IdentityResult> CrearAsync(UsuarioCreacionDTO usuario);

        public Task<IdentityResult> ActualizarAsync(Usuario usuario);

        public ValueTask<Usuario?> ObtenerUsuarioIngresadoAsync();

        public Task<bool> EmailExiste(string email);

        public Task<bool> UserNameExiste(string userName);

        bool VerificarContrasena(Usuario usuario, string contrasena);

        public Task AgregarARol(Usuario usuario, string rol);

        public Task<IdentityResult> ReestablecerPassword(Usuario usuario, string token, string nuevoPassword);

    }
}