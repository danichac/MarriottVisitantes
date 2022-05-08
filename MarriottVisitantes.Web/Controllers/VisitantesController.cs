using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Visitante(string cedula)
        {
            try
            {
                var visitante = await _servicioVisitante.BuscarPorCedula(cedula);

                return View(visitante);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error buscando visitante por cédula: {cedula}");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}