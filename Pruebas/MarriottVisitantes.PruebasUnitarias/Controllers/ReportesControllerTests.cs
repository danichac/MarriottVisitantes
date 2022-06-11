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
    public class ReportesControllerTests
    {
        private readonly Mock<IServicioVisitas> _mockServicio;
        private readonly Mock<IGeneradorReporte> _mockReporte;
        private readonly Mock<ILogger<ReportesController>> _mockLogger;
        private readonly ReportesController _controller;

        public ReportesControllerTests()
        {
            _mockServicio = new Mock<IServicioVisitas>();
            _mockLogger = new Mock<ILogger<ReportesController>>();
            _mockReporte = new Mock<IGeneradorReporte>();

            _mockServicio.Setup(s => s.ObtenerVisitas(It.IsAny<int>(), true))
                .ReturnsAsync(FuenteDatos.ObtenerVisitasPaginacion(true));
            _mockServicio.Setup(s => s.ObtenerVisitas(It.IsAny<int>(), false))
                .ReturnsAsync(FuenteDatos.ObtenerVisitasPaginacion(false));

            _controller = new ReportesController(_mockLogger.Object, _mockServicio.Object, _mockReporte.Object);
        }


        [Fact]
        public void Busqueda_Retorna_Vista()
        {
            var resultado = _controller.Busqueda();

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
        }

        [Fact]
        public async Task Busqueda_Por_Fecha_retorna_vista()
        {
            var busquedaVisitas = new BuscarVisitasViewModel() {Fecha = DateTime.Today};
            _mockServicio.Setup(s => s.BuscarPorFechaPaginacion(1, busquedaVisitas.Fecha))
                .ReturnsAsync(new Dominio.DTOs.VisitasPaginacionDTO(){Visitas = FuenteDatos.ObtenerVisitas()});
        
            var resultado = await _controller.TablaVisitas(busquedaVisitas);
        
            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<BuscarVisitasViewModel>(resultadoVista.ViewData.Model);
            
            var cuentaEsperada = FuenteDatos.ObtenerVisitas().Count;
            var cuentaActual = modelo.VisitasPaginacion.Visitas.Count;

            Assert.Equal(cuentaEsperada, cuentaActual);
        }

        [Fact]
        public async Task Reporte_Generado_Por_Fecha_Correctamente()
        {
            var fecha = DateTime.Today;
            var visitas = FuenteDatos.ObtenerVisitas();
            var excel = new ClosedXML.Excel.XLWorkbook();
            excel.AddWorksheet(1);

            _mockServicio.Setup(s => s.BuscarPorFecha(fecha)).ReturnsAsync(visitas);
            _mockReporte.Setup(s => s.GenerarReporte(visitas, fecha)).Returns(excel);
        
            var resultado = await _controller.DescargarReporte(fecha);

            var resultadoVista = Assert.IsType<FileContentResult>(resultado);
        }
    }
}