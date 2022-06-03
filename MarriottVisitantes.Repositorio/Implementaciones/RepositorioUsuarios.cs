using System.Security.Claims;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Dominio.Identidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.Repositorio.Implementaciones
{
    public class RepositorioUsuarios : IRepositorioUsuario
    {
        private readonly ILogger<RepositorioUsuarios> _logger;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly MarriottVisitantesDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Usuario> _gestorUsuarios;

        public RepositorioUsuarios(ILogger<RepositorioUsuarios> logger,
            SignInManager<Usuario> signInManager,
            MarriottVisitantesDbContext context,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Usuario> gestorUsuarios)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _gestorUsuarios = gestorUsuarios;
        }

        public Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<Usuario> BuscarPorIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IdentityResult> CrearAsync(UsuarioCreacionDTO usuario)
        {
            var nuevoUsuario = new Usuario();
            nuevoUsuario.Actualizar(usuario);
            
            return await _signInManager.UserManager.CreateAsync(nuevoUsuario);
        }

        public async Task<IdentityResult> ActualizarAsync(Usuario usuario)
        {
            return await _signInManager.UserManager.UpdateAsync(usuario);
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
            return usuarioApp;
        }

        public async Task<bool> IngresarAsync(string email, string password, bool recordarme)
        {
            var usuario = await BuscarPorEmailAsync(email);
            if(usuario is null){
                return false;
            }
            
            var resultado = await _signInManager.PasswordSignInAsync(usuario, password, recordarme, false);

            return resultado.Succeeded;
        }

        public async Task SalirAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> EmailExiste(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserNameExiste(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task AgregarARol(Usuario usuario, string rol)
        {
            await _gestorUsuarios.AddToRoleAsync(usuario, rol);
        }

        public bool VerificarContrasena(Usuario usuario, string contrasena)
        {
            var resultado = _gestorUsuarios.PasswordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, contrasena);
            var exito = resultado == PasswordVerificationResult.Success;
            return exito; 
        }
    }
}