using System;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Web.Controllers
{
    [Authorize]
    public class VisitantesController : Controller
    {
        private readonly ILogger<VisitantesController> _logger;
        private readonly IServicioVisitante _servicioVisitante;

        public VisitantesController(ILogger<VisitantesController> logger, IServicioVisitante servicioVisitante)
        {
            _logger = logger;
            _servicioVisitante = servicioVisitante;
        }

        public async Task<IActionResult> Visitante(string cedula = "", string mensajeExito = "")
        {
            try
            {
                var visitante = await _servicioVisitante.BuscarPorCedula(cedula);
                if(cedula == "0" || visitante is null)
                    visitante = new Visitante();

                ViewData["Éxito"] = mensajeExito;
                return View(visitante);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error buscando visitante por cédula: {cedula}");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Visitante(Visitante visitante)
        {
            try
            {
                var mensajeExito = string.Empty;
                if(visitante.Id != 0)
                {
                    await _servicioVisitante.ActualizarVisitante(visitante);
                    mensajeExito = $"Visitante con identificación {visitante.Cedula} actualizado.";
                }
                else
                {
                    await _servicioVisitante.AgregarVisitante(visitante);
                    mensajeExito = $"Visitante con identificación {visitante.Cedula} agregado.";
                }

                return RedirectToAction("Visitante", "Visitantes", new {@cedula = visitante.Cedula, @mensajeExito = mensajeExito});

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error guardando visitante con cédula: {visitante.Cedula}");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}