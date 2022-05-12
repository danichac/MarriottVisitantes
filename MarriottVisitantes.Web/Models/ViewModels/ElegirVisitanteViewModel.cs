using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.Entidades;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class ElegirVisitanteViewModel
    {
        public IList<Visitante> Visitantes { get; set; }
    }
}