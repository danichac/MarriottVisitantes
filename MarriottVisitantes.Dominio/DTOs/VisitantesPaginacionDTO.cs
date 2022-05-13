
using System.Collections.Generic;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Dominio.DTOs
{
    public class VisitantesPaginacionDTO
    {
        public List<Visitante> Visitantes {get; set;} = new List<Visitante>();
        public int IndicePagina { get; set; } = 1;
        public int CantidadPaginas { get; set; }
    }
}