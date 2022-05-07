using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Repositorio.Identidad
{
    public class ApplicationUserStore: IUserPasswordStore<Usuario>, IUserRoleStore<Usuario>
    {
        private readonly ILogger<ApplicationUserStore> logger;
        private readonly MarriottVisitantesDbContext context;
        public ApplicationUserStore(ILogger<ApplicationUserStore> logger,
            MarriottVisitantesDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task AddToRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            var roleId = await context.Roles.Where(r => r.Name.ToUpper() == roleName.ToUpper())
                .Select(r => r.Id).FirstOrDefaultAsync();
            var userRole = new IdentityUserRole<int>();
            userRole.RoleId = roleId;
            userRole.UserId = user.Id;

            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();
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
                await context.Users.AddAsync(usuario, cancellationToken);
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

        public async Task<IList<string>> GetRolesAsync(Usuario user, CancellationToken cancellationToken)
        {
            var userRolesIds = await context.UserRoles.Where(ur => ur.UserId == user.Id)
                .Select(x => x.RoleId).ToListAsync();
            var roles = await context.Roles.Where(r => userRolesIds.Contains(r.Id))
                .Select(r => r.Name).ToListAsync();
            return roles;
        }

        public async Task<string> GetUserIdAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(usuario.Id.ToString());
        }
        public async Task<string> GetUserNameAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(usuario.UserName);
        }

        public async Task<IList<Usuario>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var roleId = await context.Roles.Where(r => r.Name.ToUpper() == roleName.ToUpper())
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var userIds = await context.UserRoles.Where(ur => ur.RoleId == roleId)
                .Select(x => x.UserId).ToListAsync();

            var users = await context.Users.Where(u => userIds.Contains(u.Id))
                .Select(x => x).ToListAsync();

            return users;
        }

        public async Task<bool> HasPasswordAsync(Usuario usuario, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> IsInRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            var roleId = await context.Roles.Where(r => r.Name.ToUpper() == roleName.ToUpper())
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var userIds = await context.UserRoles.Where(ur => ur.RoleId == roleId)
                .Select(x => x.UserId).ToListAsync();

            return userIds.Contains(user.Id);
        }

        public Task RemoveFromRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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