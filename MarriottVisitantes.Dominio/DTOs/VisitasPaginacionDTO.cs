
using System.Collections.Generic;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Dominio.DTOs
{
    public class VisitasPaginacionDTO
    {
        public List<Visita> Visitas {get; set;}
        public int IndicePagina { get; set; }
        public int CantidadPaginas { get; set; }
    }
}