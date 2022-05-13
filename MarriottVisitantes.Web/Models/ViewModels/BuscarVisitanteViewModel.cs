using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class BuscarVisitanteViewModel
    {
        [Required(ErrorMessage = "La identificación es requerida")]
        //[RegularExpression("")]
        public string Cedula { get; set; }
        public string NombreEmpresa { get; set; }
        public IList<string> CedulasActivas { get; set; }
        public IList<string> ListaEmpresas { get; set; }
        public VisitantesPaginacionDTO VisitantesPaginacion {get; set;}
    }
}