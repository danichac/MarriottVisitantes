
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Repositorio.Identidad;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Servicios.Interfaces
{
    public interface IServicioUsuarios
    {
        public Task<bool> IngresarAsync(string email, string password, bool recordarme);

        public Task SalirAsync();

        public Task<Usuario> BuscarPorEmailAsync(string email);

        public Task<Usuario> BuscarPorIdAsync(int id);

        public Task<IdentityResult> CrearAsync(UsuarioCreacionDTO usuario);

        public ValueTask<Usuario?> ObtenerUsuarioIngresadoAsync();

        public Task<bool> EmailExiste(string email);

        public Task<bool> UserNameExiste(string userName);

        public Task AgregarARol(Usuario usuario, string rol);
    }
}