using System;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Dominio.Identidad;

namespace MarriottVisitantes.Web.Models.ViewModels
{
    public class AgregarVisitasViewModel
    {
        public Visitante Visitante { get; set; }
        public Visita NuevaVisita { get; set; } = new Visita();
        public Usuario Usuario { get; set; }

        public void ActualizarVisita()
        {
            NuevaVisita.UsuarioId = Usuario.Id;
            NuevaVisita.VisitanteId = Visitante.Id;
            NuevaVisita.FechaVisita = DateTime.Today;
            NuevaVisita.HoraEntrada = DateTime.Now;
        }
    }
}