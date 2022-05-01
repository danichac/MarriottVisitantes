using System;
using System.Threading.Tasks;
using MarriottVisitantes.Repositorio.Identidad;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace MarriottVisitantes.Repositorio.Claims
{
    public class MarriottUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Usuario, IdentityRole<int>>
    {
        public MarriottUserClaimsPrincipalFactory(UserManager<Usuario> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Usuario usuario)
        {
            var identidad = await base.GenerateClaimsAsync(usuario);
            var nombreCompleto = $"{usuario.PrimerNombre} {usuario.PrimerApellido}";
            identidad.AddClaim(new Claim("NombreApellido", nombreCompleto));

            return identidad;
        }
    }
}