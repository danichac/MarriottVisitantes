using System;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.Utils;

namespace MarriottVisitantes.Dominio.Entidades
{
    public class Visita 
    {
        public Visita()
        {
            
        }

        [Key]
        public int IdVisita { get; set; }

        [Required]
        public int IdVisitante { get; set; }

        public Visitante Visitante { get; set; }

        [Required]
        public ColorGafete ColorGafete { get; set; }

        public int NumeroGafete { get; set; }

        [Required]
        public DateTime HoraEntrada { get; set; }

        public DateTime HoraSalida { get; set; }

        [Required]
        public DateTime FechaVisita { get; set; }

        public bool VisitaTerminada { get; set; }
    }
}