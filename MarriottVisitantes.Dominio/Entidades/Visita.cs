using System;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.Identidad;
using MarriottVisitantes.Dominio.Validaciones;

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

        [RequiredIf(nameof(TipoVisitaId), TipoVisitaId.Extensa, "El color de gafete es requerido para una visita extensa")]
        [NotRequiredIf(nameof(TipoVisitaId), TipoVisitaId.Entrega, "El color de gafete no es requerido para una entrega")]
        public GafeteId? ColorGafeteId { get; set; }

        public ColorGafete? ColorGafete { get; set; }

        [RequiredIf(nameof(TipoVisitaId), TipoVisitaId.Extensa, "El número de gafete es requerido para una visita extensa")]
        [NotRequiredIf(nameof(TipoVisitaId), TipoVisitaId.Entrega, "El número de gafete no es requerido para una entrega")]
        public int? NumeroGafete { get; set; }

        [Required]
        public TipoVisitaId TipoVisitaId { get; set; }
        
        public TipoVisita TipoVisita { get; set; }

        [Required]
        public DateTime HoraEntrada { get; set; }

        public DateTime? HoraSalida { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaVisita { get; set; }

        public bool VisitaTerminada { get; set; }

        public void TerminarVisita()
        {
            VisitaTerminada = true;
            HoraSalida = DateTime.Now;
        }
    }
}