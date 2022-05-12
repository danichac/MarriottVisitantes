
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MarriottVisitantes.Dominio.Identidad
{
    public class Rol : IdentityRole<int>
    {
        public ICollection<UsuarioRol> Usuarios {get; set;}
    }
}