using System;
using System.Linq;
using System.Threading.Tasks;
using MarriottVisitantes.Dominio.Identidad;
using MarriottVisitantes.PruebasUnitarias;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MarriottVisitantes.Web.Controllers
{
    public class AdminControllerTests
    {
        private readonly Mock<IServicioUsuarios> _mockServicio;
        private readonly Mock<ILogger<AdminController>> _mockLogger;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            _mockServicio = new Mock<IServicioUsuarios>();
            _mockLogger = new Mock<ILogger<AdminController>>();
            
            _controller = new AdminController(_mockLogger.Object, _mockServicio.Object);
        }


        [Fact]
        public void AgregarUsuario_Retorna_Vista()
        {
            var resultado = _controller.AgregarUsuario();

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
        }

        [Fact]
        public async Task Agregar_Con_Usuario_Invalido_Retorna_Error()
        {
            var usuarioInvalido = FuenteDatos.UsuarioNoValido();
            _controller.ModelState.AddModelError("Email", "El correo electrónico es requerido");

            var resultado = await _controller.AgregarUsuario(usuarioInvalido);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<UsuarioCreacionViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.False(validacion);
        }

        [Fact]
        public async Task Agregar_Con_Email_O_Usuario_Existente_Retorna_Error()
        {
            var usuarioValido = FuenteDatos.UsuarioValido();

            _mockServicio.Setup(s => s.EmailExiste(It.IsAny<string>())).ReturnsAsync(true);
            _mockServicio.Setup(s => s.UserNameExiste(It.IsAny<string>())).ReturnsAsync(true);

            var resultado = await _controller.AgregarUsuario(usuarioValido);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<UsuarioCreacionViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.False(validacion);
        }

        [Fact]
        public async Task Agregar_Con_Usuario_Valido_Crea_Usuario()
        {
            var usuarioValido = FuenteDatos.UsuarioValido();

            _mockServicio.Setup(s => s.EmailExiste(It.IsAny<string>())).ReturnsAsync(false);
            _mockServicio.Setup(s => s.UserNameExiste(It.IsAny<string>())).ReturnsAsync(false);
            _mockServicio.Setup(s => s.CrearAsync(It.IsAny<UsuarioCreacionViewModel>()))
                .ReturnsAsync(IdentityResult.Success);
            _mockServicio.Setup(s => s.BuscarPorEmailAsync(It.IsAny<string>())).ReturnsAsync(new Usuario());
            _mockServicio.Setup(s => s.AgregarARol(It.IsAny<Usuario>(), It.IsAny<string>()));

            var resultado = await _controller.AgregarUsuario(usuarioValido);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.True(validacion);
        }
    }
}