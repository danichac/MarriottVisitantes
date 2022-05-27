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

        [Required(ErrorMessage = "La identificación es requerida")]
        [MaxLength(50, ErrorMessage = "La identificación no puede exceder los 50 caracteres")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El primer nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El primer nombre no puede exceder los 50 caracteres")]
        public string PrimerNombre { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo nombre no puede exceder los 50 caracteres")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [MaxLength(50, ErrorMessage = "El primer apellido no puede exceder los 50 caracteres")]
        public string PrimerApellido { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo apellido no puede exceder los 50 caracteres")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa o lugar de visita es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre de la empresa no puede exceder los 50 caracteres")]
        public string NombreEmpresa { get; set; }

        
        public ICollection<Visita>? Visitas { get; set; }

        public string ObtenerNombreCompleto()
        {
            return $"{PrimerNombre} {PrimerApellido}";
        }
    }
}