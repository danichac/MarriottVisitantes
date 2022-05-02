
using System.Threading.Tasks;
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

        public Task<IdentityResult> CrearAsync(string userName, string email, string password);

        public ValueTask<Usuario?> ObtenerUsuarioIngresadoAsync();
    }
}