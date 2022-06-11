using System;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.PruebasUnitarias;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MarriottVisitantes.Web.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<IServicioVisitas> _mockServicio;
        private readonly Mock<ILogger<HomeController>> _mockLogger;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockServicio = new Mock<IServicioVisitas>();
            _mockLogger = new Mock<ILogger<HomeController>>();

            _mockServicio.Setup(s => s.ObtenerVisitas(It.IsAny<int>(), true))
                .ReturnsAsync(FuenteDatos.ObtenerVisitasPaginacion(true));
            _mockServicio.Setup(s => s.ObtenerVisitas(It.IsAny<int>(), false))
                .ReturnsAsync(FuenteDatos.ObtenerVisitasPaginacion(false));

            _controller = new HomeController(_mockLogger.Object, _mockServicio.Object);
        }


        [Fact]
        public async Task Index_Retorna_Vista()
        {
            var resultado = await _controller.Index();

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<VisitasPaginacionViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.Equal(5, modelo.VisitasTerminadas.Visitas.Count);
            Assert.Equal(0, modelo.VisitasNoTerminadas.Visitas.Count);
        }
    }
}