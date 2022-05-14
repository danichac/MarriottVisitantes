using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class BuscarVisitasViewModel
    {
        public DateTime Fecha { get; set; }
        public VisitasPaginacionDTO VisitasPaginacion {get; set;}
    }
}