using System;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.PruebasUnitarias;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MarriottVisitantes.Web.Controllers
{
    public class VisitantesControllerTests
    {
        private readonly Mock<IServicioVisitante> _mockServicio;
        private readonly Mock<ILogger<VisitantesController>> _mockLogger;
        private readonly VisitantesController _controller;

        public VisitantesControllerTests()
        {
            _mockServicio = new Mock<IServicioVisitante>();
            _mockLogger = new Mock<ILogger<VisitantesController>>();


            _controller = new VisitantesController(_mockLogger.Object, _mockServicio.Object);
        }


        [Fact]
        public async Task Busqueda_Visitante_Retorna_Vista()
        {
            var cedula = "1-1111-1111";
            var exito = "Visitante actualizado.";

            _mockServicio.Setup(s => s.BuscarPorCedula(cedula))
                .ReturnsAsync(new Visitante(){Cedula = cedula});

            var resultado = await _controller.Visitante(cedula, exito);

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<Visitante>(
                resultadoVista.ViewData.Model
            );

            Assert.Equal(exito, resultadoVista.ViewData["Éxito"]);
        }
        
        [Fact]
        public async Task Agregar_Visitante_Invalido_Resulta_error()
        {
            var visitante = FuenteDatos.VisitanteNoValido();
            _controller.ModelState.AddModelError("Cedula", "La identificación es requerida");
            
            var resultado = await _controller.Visitante(visitante);
            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<Visitante>(
                resultadoVista.ViewData.Model
            );
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public async Task Agregar_Visitante_Valido_Resulta_Exito()
        {
            var visitante = FuenteDatos.VisitanteValido();

            _mockServicio.Setup(s => s.BuscarPorCedula(visitante.Cedula)).ReturnsAsync(visitante);
            
            var resultado = await _controller.Visitante(visitante);
            var resultadoVista = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.True(_controller.ModelState.IsValid);
        }
    }
}