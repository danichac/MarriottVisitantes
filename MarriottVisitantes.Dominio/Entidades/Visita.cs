using System;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Repositorio.Identidad;

namespace MarriottVisitantes.Dominio.Entidades
{
    public class Visita 
    {
        public Visita()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public Visitante Visitante { get; set; }

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public GafeteId ColorGafeteId { get; set; }

        public ColorGafete ColorGafete { get; set; }

        [MaxLength(8)]
        public string Temperatura { get; set; }

        public int NumeroGafete { get; set; }

        [Required]
        public DateTime HoraEntrada { get; set; }

        public DateTime? HoraSalida { get; set; }

        [Required]
        public DateTime FechaVisita { get; set; }

        public bool VisitaTerminada { get; set; }

        public void TerminarVisita()
        {
            VisitaTerminada = true;
        }
    }
}