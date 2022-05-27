using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MarriottVisitantes.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class BuscarVisitasViewModel
    {
        [HiddenInput]
        public DateTime Fecha { get; set; }
        public VisitasPaginacionDTO VisitasPaginacion {get; set;}
    }
}