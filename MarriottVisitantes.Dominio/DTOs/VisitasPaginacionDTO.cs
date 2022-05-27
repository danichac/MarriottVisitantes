
using System.Collections.Generic;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Dominio.DTOs
{
    public class VisitasPaginacionDTO
    {
        public List<Visita> Visitas {get; set;} = new List<Visita>();
        public int IndicePagina { get; set; }
        public int CantidadPaginas { get; set; }
        public int TotalResultados { get; set; }
    }
}