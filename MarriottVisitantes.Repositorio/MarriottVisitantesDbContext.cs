using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Dominio.Identidad;
using MarriottVisitantes.Dominio.Extensiones;

namespace MarriottVisitantes.Repositorio
{
    public class MarriottVisitantesDbContext : IdentityDbContext<Usuario, Rol, int>
    {
        public MarriottVisitantesDbContext(DbContextOptions<MarriottVisitantesDbContext> options) : base(options)
        {

        }

        public DbSet<Visitante> Visitantes {get; set;}
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<ColorGafete> ColorGafete {get; set;}
        public DbSet<TipoVisita> TipoVisita { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Visita>()
                .Property(v => v.ColorGafeteId);
            modelBuilder
                .Entity<ColorGafete>()
                .Property(cg => cg.Id);
            modelBuilder
                .Entity<ColorGafete>()
                .HasData(
                    Enum.GetValues(typeof(GafeteId))
                        .Cast<GafeteId>()
                        .Select(g => new ColorGafete()
                            {
                                Id = g,
                                Color = g.ObtenerDescripcion()
                            })
                );

            modelBuilder
                .Entity<Visita>()
                .Property(v => v.TipoVisitaId);
            modelBuilder
                .Entity<TipoVisita>()
                .Property(tp => tp.Id);
            modelBuilder
                .Entity<TipoVisita>()
                .HasData(
                    Enum.GetValues(typeof(TipoVisitaId))
                        .Cast<TipoVisitaId>()
                        .Select(t => new TipoVisita()
                            {
                                Id = t,
                                Tipo = t.ObtenerDescripcion()
                            })
                );

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

            var rolAdministrador = new Rol
            {
                Id = 1,
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            };
            var rolUsuario = new Rol
            {
                Id = 2,
                Name = "Usuario",
                NormalizedName = "USUARIO"
            };
            
            modelBuilder.Entity<Rol>(rol =>
            {
                rol.HasData(rolAdministrador);
                rol.HasData(rolUsuario);
            });

            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(ur => ur.RoleId);

            var usuarioRol = new UsuarioRol
            {
                UserId = 1,
                RoleId = 1,
            };

            modelBuilder.Entity<UsuarioRol>(ur =>
            {
                ur.HasData(usuarioRol);
            });
        }
    }
}