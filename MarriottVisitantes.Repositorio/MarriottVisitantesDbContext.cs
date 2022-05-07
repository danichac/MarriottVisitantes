using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Repositorio.Identidad;

namespace MarriottVisitantes.Repositorio
{
    public class MarriottVisitantesDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public MarriottVisitantesDbContext(DbContextOptions<MarriottVisitantesDbContext> options) : base(options)
        {

        }

        //public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Visitante> Visitantes {get; set;}
        public DbSet<Visita> Visitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var daniel = new Usuario
            {
                Id = 1,
                UserName = "danichac",
                PasswordHash = "Welcome123",
                PrimerNombre = "Daniel",
                PrimerApellido = "Chacón",
                SegundoApellido = "Navarro",
                Email = "dfchacon@uned.cr"
            };
            
            daniel.PasswordHash = new PasswordHasher<Usuario>().HashPassword(daniel, daniel.PasswordHash);
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.HasData(daniel);
            });

            modelBuilder.Entity<UsuarioRol>()
                .HasKey(ur => new {ur.UserId, ur.RoleId});
            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}