using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarriottVisitantes.Web.Models;
using Microsoft.AspNetCore.Authorization;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;

namespace MarriottVisitantes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioVisitas _servicioVisitas;

        public HomeController(ILogger<HomeController> logger, IServicioVisitas servicioVisitas)
        {
            _logger = logger;
            _servicioVisitas = servicioVisitas;
        }

        [Authorize]
        public async Task<IActionResult> Index(int indicePagina = 1)
        {
            var visitasTerminadas = await _servicioVisitas.ObtenerVisitas(indicePagina, true);
            var visitasNoTerminadas = await _servicioVisitas.ObtenerVisitas(indicePagina, false);

            var totalVisitas = new VisitasPaginacionViewModel(visitasTerminadas, visitasNoTerminadas);

            return View(totalVisitas);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Exito(string mensaje)
        {
            var model = new SuccessViewModel() {Mensaje = mensaje};
            return View(model);
        }
    }
}
