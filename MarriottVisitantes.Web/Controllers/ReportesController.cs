using System;
using System.IO;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarriottVisitantes.Web.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        private readonly IServicioVisitas _servicioVisitas;
        private readonly ILogger<ReportesController> _logger;
        private readonly IGeneradorReporte _generadorReporte;

        public ReportesController(ILogger<ReportesController> logger,
            IServicioVisitas servicioVisitas,
            IGeneradorReporte generadorReporte)
        {
            _servicioVisitas = servicioVisitas;
            _generadorReporte = generadorReporte;
            _logger = logger;
        }
        
        public IActionResult Busqueda()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en buscar reporte visitas.");
                return RedirectToAction("Error", "Home");
            }
            
        }

        public async Task<IActionResult> TablaVisitas(BuscarVisitasViewModel model, int paginaActual = 1)
        {
            try
            {
                model.VisitasPaginacion =
                    await _servicioVisitas.BuscarPorFechaPaginacion(paginaActual, model.Fecha);

                return View(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error en TablaVisitas");
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<FileResult> GenerarReporte(BuscarVisitasViewModel model)
        {
            var visitas = await _servicioVisitas.BuscarPorFecha(model.Fecha);
            var reporte = _generadorReporte.GenerarReporte(visitas, model.Fecha);

            using(var stream = new MemoryStream())
            {
                reporte.SaveAs(stream);
                return File(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"visitas_{model.Fecha.ToString("dd/MM/yyyy")}.xlsx");
            }
        }
    }
}