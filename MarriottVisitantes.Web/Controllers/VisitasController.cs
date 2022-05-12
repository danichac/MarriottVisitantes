using System;
using System.Threading.Tasks;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Web.Controllers
{
    [Authorize]
    public class VisitasController : Controller
    {
        private readonly IServicioVisitas _servicioVisitas;
        private readonly IServicioVisitante _servicioVisitante;
        private readonly ILogger<VisitasController> _logger;

        public VisitasController(ILogger<VisitasController> logger,
            IServicioVisitas servicioVisitas,
            IServicioVisitante servicioVisitante)
        {
            _servicioVisitas = servicioVisitas;
            _servicioVisitante = servicioVisitante;
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
        
        public async Task<IActionResult> BuscarVisitante()
        {
            try
            {
                var busquedaViewModel = new BuscarVisitanteViewModel();
                busquedaViewModel.CedulasActivas = await _servicioVisitante.ObtenerTodasCedulas();
                busquedaViewModel.ListaEmpresas = await _servicioVisitante.ListaDeEmpresas();
                return View(busquedaViewModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en BuscarVisitante");
                return RedirectToAction("Error", "Home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> BuscarVisitante(BuscarVisitanteViewModel model)
        {
            try
            {
                var visitante = await _servicioVisitante.BuscarPorCedula(model.Cedula);
                if (visitante is null || visitante?.Id == 0)
                {
                    return RedirectToAction("Visitante", "Visitantes", model.Cedula);
                }
                else
                {
                    return RedirectToAction("Agregar", "Visitas");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error buscando el visitante");
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> ElegirVisitante(BuscarVisitanteViewModel model)
        {
            try
            {
                var visitantesPorEmpresa = await _servicioVisitante.VisitantesPorEmpresa(model.NombreEmpresa);
                var elegirVisitanteViewModel = new ElegirVisitanteViewModel();
                elegirVisitanteViewModel.Visitantes = visitantesPorEmpresa;

                return View(elegirVisitanteViewModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en ElegirVisitante");
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Agregar()
        {
            return View();
        }
    }
}