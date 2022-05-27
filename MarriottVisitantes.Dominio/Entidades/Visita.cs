using System;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.Identidad;

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
        public long VisitanteId {get; set;}

        public virtual Visitante Visitante { get; set; }

        [Required]
        public int UsuarioId {get; set;}

        public virtual Usuario Usuario { get; set; }

        [Required]
        public GafeteId ColorGafeteId { get; set; }

        public ColorGafete ColorGafete { get; set; }

        [Required]
        public int NumeroGafete { get; set; }

        [Required]
        public TipoVisitaId TipoVisitaId { get; set; }
        
        public TipoVisita TipoVisita { get; set; }

        [Required]
        public DateTime HoraEntrada { get; set; }

        public DateTime? HoraSalida { get; set; }

        [Required]
        public DateTime FechaVisita { get; set; }

        public bool VisitaTerminada { get; set; }

        public void TerminarVisita()
        {
            VisitaTerminada = true;
            HoraSalida = DateTime.Now;
        }
    }
}