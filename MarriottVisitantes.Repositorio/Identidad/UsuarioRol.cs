
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Repositorio.Identidad
{
    public class UsuarioRol : IdentityUserRole<int>
    {
        public Usuario Usuario {get; set;}
        public Rol Rol {get; set;}
    }
}