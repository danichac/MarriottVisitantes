
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Repositorio.Identidad
{
    public class Rol : IdentityRole<int>
    {
        public ICollection<UsuarioRol> Usuarios {get; set;}
    }
}