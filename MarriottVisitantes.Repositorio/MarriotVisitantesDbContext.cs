using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Repositorio
{
    public class MarriottVisitantesDbContext : IdentityDbContext<IdentityUser>
    {
        public MarriottVisitantesDbContext(DbContextOptions<MarriottVisitantesDbContext> options) : base(options)
        {

        }

        public DbSet<Visitante> Visitantes {get; set;}
        public DbSet<Visita> Visitas { get; set; }
    }
}