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

        public async Task<IActionResult> Visitante(string cedula = "", string mensajeExito = "", string alert = "")
        {
            try
            {
                var visitante = await _servicioVisitante.BuscarPorCedula(cedula);
                if(cedula == "0" || visitante is null)
                    visitante = new Visitante();

                ViewData["Éxito"] = mensajeExito;
                ViewData["Alerta"] = alert;
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
                if(ModelState.IsValid)
                {
                    var mensajeExito = string.Empty;
                    var alertClase = string.Empty;
                    if(visitante.Id != 0)
                    {   
                        await _servicioVisitante.ActualizarVisitante(visitante);
                        mensajeExito = $"Visitante con identificación {visitante.Cedula} actualizado.";
                        alertClase = "alert-success";
                    }
                    else
                    {
                        var visitanteExistente = await _servicioVisitante.BuscarPorCedula(visitante.Cedula);
                        if(visitanteExistente is not null)
                        {
                            mensajeExito = $"Visitante con identificación {visitante.Cedula} ya existe.";
                            alertClase = "alert-warning";
                        }
                        else
                        {
                            await _servicioVisitante.AgregarVisitante(visitante);
                            mensajeExito = $"Visitante con identificación {visitante.Cedula} agregado.";
                            alertClase = "alert-success";
                        }
                        
                    }

                    return RedirectToAction("Visitante", "Visitantes", new {@cedula = visitante.Cedula, @mensajeExito = mensajeExito, @alert= alertClase});
                }
                else
                {
                    return View(visitante);
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error guardando visitante con cédula: {visitante.Cedula}");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}