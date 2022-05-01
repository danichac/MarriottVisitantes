using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Repositorio.Identidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace MarriottVisitantes.Repositorio.Implementaciones
{
    public class RepositorioUsuarios : IRepositorioUsuario
    {
        private readonly ILogger<RepositorioUsuarios> _logger;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly MarriottVisitantesDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositorioUsuarios(ILogger<RepositorioUsuarios> logger,
            SignInManager<Usuario> signInManager,
            MarriottVisitantesDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<Usuario> BuscarPorIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IdentityResult> CrearAsync(string userName, string email, string password)
        {
            var usuario = new Usuario();
            usuario.Actualizar(userName, email, password);
            return await _signInManager.UserManager.CreateAsync(usuario);
        }

        public async ValueTask<Usuario?> ObtenerUsuarioIngresadoAsync()
        {
            ClaimsPrincipal? usuario = _httpContextAccessor.HttpContext?.User;
            if (usuario is null)
            {
                return null;
            }
            if(_signInManager.IsSignedIn(usuario) is false)
            {
                return null;
            }
            string? userId = usuario.FindFirstValue(ClaimTypes.NameIdentifier);
            if(string.IsNullOrEmpty(userId) ||
                int.TryParse(userId, out var id) == false)
            {
                return null;
            }
            Usuario? usuarioApp = await BuscarPorIdAsync(id);
            if (usuarioApp is null)
            {
                return null;
            }
            return new Usuario(usuarioApp.Id, usuarioApp.UserName, usuarioApp.Email);
        }

        public async Task<bool> IngresarAsync(string email, string password)
        {
            var usuario = await BuscarPorEmailAsync(email);
            if(usuario is null){
                return false;
            }

            var resultado = await _signInManager.PasswordSignInAsync(usuario, password, false, false);

            return resultado.Succeeded;
        }

        public async Task SalirAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}