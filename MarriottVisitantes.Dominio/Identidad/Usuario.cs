using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Dominio.Identidad
{
    public class Usuario : IdentityUser<int>
    {   
        public Usuario()
        {
            
        }

        public Usuario(int id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombre_usuario")]
        public override string UserName { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public override string Email { get; set; } = "";

        [Required]
        [Column("password")]
        public override string PasswordHash { get; set; } = "";

        [Required]
        [MaxLength(50)]
        [Column("primer_nombre")]
        public string PrimerNombre { get; set; } = "";

        [MaxLength(50)]
        [Column("segundo_nombre")]
        public string SegundoNombre { get; set; } = "";

        [Required]
        [MaxLength(50)]
        [Column("primer_apellido")]
        public string PrimerApellido { get; set; } = "";

        [MaxLength(50)]
        [Column("segundo_apellido")]
        public string SegundoApellido { get; set; } = "";

        [NotMapped]
        public override bool EmailConfirmed { get; set; }

        [NotMapped]
        public override string NormalizedUserName {
            get
            {
                return UserName.ToUpper();
            }
        }

        [NotMapped]
        public override string NormalizedEmail {
            get
            {
                return Email.ToUpper();
            }
        }

        [NotMapped]
        public override bool LockoutEnabled { get; set; }

        [NotMapped]
        public override int AccessFailedCount { get; set; }

        [NotMapped]
        public override string? PhoneNumber { get; set; }

        [NotMapped]
        public override string? ConcurrencyStamp { get; set; }

        [NotMapped]
        public override string? SecurityStamp { get; set; }

        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }

        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }

        [NotMapped]
        public override bool PhoneNumberConfirmed { get; set; } 

        public ICollection<UsuarioRol> Roles {get; set;}

        public ICollection<Visita> Visitas {get; set;}

        public void Actualizar(Usuario usuario)
        {
            UserName = usuario.UserName;
            PasswordHash = usuario.PasswordHash;
            Email = usuario.Email;
        }

        public void Actualizar(UsuarioCreacionDTO usuario)
        {
            UserName = usuario.UserName;
            PrimerNombre = usuario.PrimerNombre;
            SegundoNombre = usuario.SegundoNombre;
            PrimerApellido = usuario.PrimerApellido;
            SegundoApellido = usuario.SegundoApellido;
            Email = usuario.Email;
            PasswordHash = new PasswordHasher<Usuario>().HashPassword(this, usuario.Password);
        }

        public string Validar()
        {
            if(string.IsNullOrEmpty(UserName))
            {
                return "El nombre de usuario es requerido";
            }
            if(string.IsNullOrEmpty(Email))
            {
                return "El E-Mail es requerido";
            }
            if(string.IsNullOrEmpty(PasswordHash))
            {
                return "La contraseña es requerida";
            }
            return "";
        }

        public string GetNombreApellido()
        {
            return $"{PrimerNombre} {PrimerApellido}";
        }
    }
}