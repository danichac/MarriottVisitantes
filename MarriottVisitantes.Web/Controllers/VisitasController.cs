using System;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Web.Controllers
{
    [Authorize]
    public class VisitasController : Controller
    {
        private readonly IServicioVisitas _servicioVisitas;
        private readonly IServicioVisitante _servicioVisitante;
        private readonly IServicioUsuarios _servicioUsuarios;
        private readonly ILogger<VisitasController> _logger;

        public VisitasController(ILogger<VisitasController> logger,
            IServicioVisitas servicioVisitas,
            IServicioVisitante servicioVisitante,
            IServicioUsuarios servicioUsuarios)
        {
            _servicioVisitas = servicioVisitas;
            _servicioVisitante = servicioVisitante;
            _servicioUsuarios = servicioUsuarios;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Terminar(int idVisita)
        {
            try
            {
                var visita =  await _servicioVisitas.BuscarPorId(idVisita);
                visita.TerminarVisita();
                await _servicioVisitas.ActualizarVisita(visita);
                TempData["Éxito"] = $"Visita de {visita.Visitante.ObtenerNombreCompleto()} terminada";
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
        public IActionResult BuscarVisitante(BuscarVisitanteViewModel model)
        {
            try
            {
                return RedirectToAction("ElegirVisitante", 
                    new {@cedula = model.Cedula, @empresa = model.NombreEmpresa});
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en ElegirVisitante");
                return RedirectToAction("Error", "Home");
            }
        }


        public async Task<IActionResult> ElegirVisitante(string cedula, string empresa, int paginaActual = 1)
        {
            try
            {
                var criteriosBusqueda = new BusquedaVisitantesDTO(cedula, empresa);
                var model = new BuscarVisitanteViewModel() {Cedula = cedula, NombreEmpresa = empresa};
                model.VisitantesPaginacion =
                    await _servicioVisitante.ListaVisitantesPaginacion(paginaActual, criteriosBusqueda);

                return View(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en ElegirVisitante");
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Agregar(int visitanteId)
        {
            try
            {
                var visitante = await _servicioVisitante.BuscarPorId(visitanteId);
                var usuario = await _servicioUsuarios.ObtenerUsuarioIngresadoAsync();

                var viewModel = new AgregarVisitasViewModel();

                viewModel.Visitante = visitante;
                viewModel.Usuario = usuario;

                return View(viewModel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en Agregar");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarVisitasViewModel model)
        {
            try
            {
                var isValid = ModelState
                    .Where( s => s.Key == "NuevaVisita.ColorGafeteId" || s.Key == "NuevaVisita.NumeroGafete")
                    .Select(s => s.Value)
                    .All(v => v.ValidationState == ModelValidationState.Valid);

                if(isValid)
                {
                    model.ActualizarVisita();
                    if(model.NuevaVisita.TipoVisitaId == Dominio.Entidades.TipoVisitaId.Entrega)
                        model.NuevaVisita.TerminarVisita();

                    await _servicioVisitas.AgregarVisita(model.NuevaVisita);
                    TempData["Éxito"] = $"Visita agregada";

                    return RedirectToAction("Index", "Home");
                }

                var visitante = await _servicioVisitante.BuscarPorId(model.Visitante.Id);
                var usuario = await _servicioUsuarios.ObtenerUsuarioIngresadoAsync();
                
                model.Visitante = visitante;
                model.Usuario = usuario;
                
                return View(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error agregando nueva visita");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}