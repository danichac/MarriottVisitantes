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
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.HasData(new Usuario
                {
                    UserName = "danichac",
                    PasswordHash = "Welcome123",
                    PrimerNombre = "Daniel",
                    PrimerApellido = "Chacón",
                    SegundoApellido = "Navarro",
                    Email = "dfchacon@uned.cr"
                });
            });
        }
    }
}