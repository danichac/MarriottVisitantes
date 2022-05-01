using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Repositorio.Identidad
{
    public class ApplicationUserStore: IUserPasswordStore<Usuario>
    {
        private readonly ILogger<ApplicationUserStore> logger;
        private readonly MarriottVisitantesDbContext context;
        public ApplicationUserStore(ILogger<ApplicationUserStore> logger,
            MarriottVisitantesDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task<IdentityResult> CreateAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            // validacion
            var validacionError = usuario.Validar();
            if(string.IsNullOrEmpty(validacionError) == false)
            {
                return IdentityResult.Failed(new IdentityError { Description = validacionError });
            }
            using(IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                if(await context.Users
                    .AnyAsync(u => u.Email == usuario.Email,
                    cancellationToken))
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Su e-mail ya ha sido utilizado." });
                }
                var usuarioNuevo = new Usuario();
                usuarioNuevo.Actualizar(usuario);
                await context.Users.AddAsync(usuarioNuevo, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync();
                return IdentityResult.Success;
            }
        }

        public async Task<IdentityResult> DeleteAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            Usuario? target = await context.Users
                .FirstOrDefaultAsync(u => u.Id == usuario.Id,
                cancellationToken); 
            context.Users.Remove(target);
            await context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public void Dispose() { }
        
        public async Task<Usuario> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if(int.TryParse(userId, out var id) == false)
            {
                return new Usuario();
            }
            return await context.Users
                .FirstOrDefaultAsync(u => u.Id == id,
                cancellationToken);
        }
        
        public async Task<Usuario> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToUpper() == normalizedUserName,
                cancellationToken);
        }
        public async Task<string> GetNormalizedUserNameAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(usuario.NormalizedUserName);
        }
        public async Task<string> GetPasswordHashAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(usuario.PasswordHash);
        }
        public async Task<string> GetUserIdAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(usuario.Id.ToString());
        }
        public async Task<string> GetUserNameAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(usuario.UserName);
        }
        public async Task<bool> HasPasswordAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }
        public async Task SetNormalizedUserNameAsync(Usuario usuario, string normalizedName, CancellationToken cancellationToken)
        {
            await Task.Run(() => {});
        }
        public async Task SetPasswordHashAsync(Usuario usuario, string passwordHash, CancellationToken cancellationToken)
        {
            using(IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                Usuario? target = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == usuario.Id,
                    cancellationToken);
                target.PasswordHash = passwordHash;
                // validation
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }            
        }
        public async Task SetUserNameAsync(Usuario usuario, string userName, CancellationToken cancellationToken)
        {
            using(IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                Usuario? target = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == usuario.Id,
                    cancellationToken);
                target.UserName = userName;
                // validation
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }
        public async Task<IdentityResult> UpdateAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            var validacionError = usuario.Validar();

            if(string.IsNullOrEmpty(validacionError) == false)
            {
                return IdentityResult.Failed(new IdentityError { Description = validacionError });
            }
            using(IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                Usuario? target = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == usuario.Id,
                    cancellationToken);
                // validation
                target.Actualizar(usuario);
                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync();
                return IdentityResult.Success;
            }
        }
    }
}