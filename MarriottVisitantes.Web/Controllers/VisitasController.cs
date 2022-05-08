using System;
using System.Threading.Tasks;
using MarriottVisitantes.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Web.Controllers
{
    [Authorize]
    public class VisitasController : Controller
    {
        private readonly IServicioVisitas _servicioVisitas;
        private readonly ILogger<VisitasController> _logger;

        public VisitasController(ILogger<VisitasController> logger, IServicioVisitas servicioVisitas)
        {
            _servicioVisitas = servicioVisitas;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Terminar(int idVisita)
        {
            try
            {
                var visita =  await _servicioVisitas.BuscarPorId(idVisita);
                visita.HoraSalida = DateTime.Now;
                visita.TerminarVisita();
                await _servicioVisitas.ActualizarVisita(visita);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error terminando la visita");
                return RedirectToAction("Index", "Home");
            }
            
        }
        
    }
}