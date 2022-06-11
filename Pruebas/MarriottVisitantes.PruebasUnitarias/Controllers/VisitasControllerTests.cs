using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.DTOs;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.PruebasUnitarias;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MarriottVisitantes.Web.Controllers
{
    public class VisitasControllerTests
    {
        private readonly Mock<IServicioVisitante> _mockServicioVisitante;
        private readonly Mock<IServicioVisitas> _mockServicioVisitas;
        private readonly Mock<IServicioUsuarios> _mockServicioUsuarios;
        private readonly Mock<ILogger<VisitasController>> _mockLogger;
        private readonly VisitasController _controller;

        public VisitasControllerTests()
        {
            _mockServicioVisitante = new Mock<IServicioVisitante>();
            _mockServicioVisitas =  new Mock<IServicioVisitas>();
            _mockServicioUsuarios = new Mock<IServicioUsuarios>();

            _mockLogger = new Mock<ILogger<VisitasController>>();

            _controller = new VisitasController(_mockLogger.Object, _mockServicioVisitas.Object,
                _mockServicioVisitante.Object, _mockServicioUsuarios.Object);
        }


        [Fact]
        public async Task Terminar_Visita_Resulta_Exito()
        {
            var visita = FuenteDatos.ObtenerVisitaEnCurso();
            _mockServicioVisitas.Setup(s => s.BuscarPorId(visita.Id))
                .ReturnsAsync(visita);
            _mockServicioVisitas.Setup(s => s.ActualizarVisita(visita));


            var resultado = await _controller.Terminar(visita.Id);

            var resultadoVista = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.True(visita.VisitaTerminada);
        }
        
        [Fact]
        public async Task Buscar_Visitante_Retorna_Vista()
        {
            _mockServicioVisitante.Setup(s => s.ListaDeEmpresas())
                .ReturnsAsync(new List<string>());
        
            var resultado = await _controller.BuscarVisitante();
        
            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<BuscarVisitanteViewModel>(resultadoVista.ViewData.Model);
        }

        [Fact]
        public async Task Elegir_Visitante_retorna_vista()
        {
            _mockServicioVisitante.Setup(s => s.ListaVisitantesPaginacion(It.IsAny<int>(), It.IsAny<BusquedaVisitantesDTO>()))
                .ReturnsAsync(FuenteDatos.ObtenerVisitantesPaginacion());
        
            var resultado = await _controller.ElegirVisitante("1-1111-1111", "Automercado");
        
            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<BuscarVisitanteViewModel>(resultadoVista.ViewData.Model);
        }

        [Fact]
        public async Task Agregar_Nueva_Visita_Valida_Con_exito()
        {
            var nuevaVisita = FuenteDatos.ObtenerVisitaAgregar();

            _mockServicioVisitas.Setup(s => s.AgregarVisita(nuevaVisita.NuevaVisita));
            
            var resultado = await _controller.Agregar(nuevaVisita);
        
            var resultadoVista = Assert.IsType<RedirectToActionResult>(resultado);
        }

        [Fact]
        public async Task Agregar_Nueva_Visita_Invalida_Con_Error()
        {
            var nuevaVisita = FuenteDatos.ObtenerVisitaAgregar();
            _controller.ModelState.AddModelError("NuevaVisita.ColorGafeteId", "Color de gafete requerido");

            _mockServicioVisitante.Setup(s => s.BuscarPorId(It.IsAny<int>()))
                .ReturnsAsync(nuevaVisita.Visitante);
            _mockServicioUsuarios.Setup(s => s.ObtenerUsuarioIngresadoAsync())
                .ReturnsAsync(nuevaVisita.Usuario);
            
            var resultado = await _controller.Agregar(nuevaVisita);
        
            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<AgregarVisitasViewModel>(resultadoVista.ViewData.Model);

            Assert.Equal(nuevaVisita.Usuario, modelo.Usuario);
            Assert.Equal(nuevaVisita.Visitante, modelo.Visitante);
        }
    }
}