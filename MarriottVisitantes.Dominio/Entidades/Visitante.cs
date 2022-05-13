using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarriottVisitantes.Dominio.Entidades
{
    public class Visitante 
    {
        public Visitante()
        {
            
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cedula { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrimerNombre { get; set; }

        [MaxLength(50)]
        public string? SegundoNombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrimerApellido { get; set; }

        [Required]
        [MaxLength(50)]
        public string? SegundoApellido { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreEmpresa { get; set; }
        public ICollection<Visita> Visitas { get; set; }
    }
}