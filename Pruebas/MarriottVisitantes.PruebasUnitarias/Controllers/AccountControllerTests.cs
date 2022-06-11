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
    public class AccountControllerTests
    {
        private readonly Mock<IServicioUsuarios> _mockServicioUsuarios;
        private readonly Mock<IServicioEmail> _mockServicioEmail;
        private readonly Mock<ILogger<AccountController>> _mockLogger;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockServicioUsuarios = new Mock<IServicioUsuarios>();
            _mockLogger = new Mock<ILogger<AccountController>>();
            _mockServicioEmail = new Mock<IServicioEmail>();
            _controller = new AccountController(_mockLogger.Object, _mockServicioUsuarios.Object, _mockServicioEmail.Object);
        }


        [Fact]
        public void Login_Retorna_Vista()
        {
            var resultado = _controller.Login();

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
        }

        [Fact]
        public async Task Login_Con_datos_Incompletos_Retorna_Error()
        {
            var loginInvalido = FuenteDatos.LoginNoValido();
            _controller.ModelState.AddModelError("Email", "El correo electrónico es requerido");

            var resultado = await _controller.Login(loginInvalido);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<LoginViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.False(validacion);
        }

        [Fact]
        public async Task login_Datos_Invalidos_Retorna_Error()
        {
            var usuarioValido = FuenteDatos.LoginValido();

            _mockServicioUsuarios.
                Setup(s => s.IngresarAsync(It.IsAny<string>(),It.IsAny<string>(),true))
                .ReturnsAsync(false);

            var resultado = await _controller.Login(usuarioValido);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<LoginViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.False(validacion);
        }

        [Fact]
        public async Task Agregar_Con_Login_Valido_Crea_Ingresa()
        {
            var login = FuenteDatos.LoginValido();

            _mockServicioUsuarios.
                Setup(s => s.IngresarAsync(It.IsAny<string>(),It.IsAny<string>(),true))
                .ReturnsAsync(true);

            var resultado = await _controller.Login(login, "Index");
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<RedirectResult>(resultado);
            Assert.True(validacion);
        }

        [Fact]
        public async Task Editar_Usuario_Devuelve_Vista()
        {
            _mockServicioUsuarios.Setup(s => s.ObtenerUsuarioIngresadoAsync()).ReturnsAsync(FuenteDatos.UsuarioIdentidad());
        
            var resultado = await _controller.Editar();

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
        }

        [Fact]
        public async Task Editar_Usuario_Datos_Incompletos_Produce_Error()
        {
            var usuario = FuenteDatos.UsuarioEdicion();
            _controller.ModelState.AddModelError("Email", "El correo electrónico es requerido");
        
            var resultado = await _controller.Editar(usuario);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<UsuarioEdicionViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.False(validacion);
        }

        [Fact]
        public async Task Editar_Usuario_Datos_Completos_Exitoso()
        {
            var usuario = FuenteDatos.UsuarioEdicion();

            _mockServicioUsuarios.Setup(s => s.ObtenerUsuarioIngresadoAsync()).ReturnsAsync(FuenteDatos.UsuarioIdentidad());
            _mockServicioUsuarios.Setup(s => s.VerificarContrasena(It.IsAny<Usuario>(), It.IsAny<string>()))
                .Returns(true);
            _mockServicioUsuarios.Setup(s => s.EmailExiste(It.IsAny<string>())).ReturnsAsync(false);
            _mockServicioUsuarios.Setup(s => s.UserNameExiste(It.IsAny<string>())).ReturnsAsync(false);
            _mockServicioUsuarios.Setup(s => s.ActualizarAsync(It.IsAny<Usuario>())).ReturnsAsync(IdentityResult.Success);
        
            var resultado = await _controller.Editar(usuario);
            var validacion = _controller.ModelState.IsValid;

            var resultadoVista = Assert.IsType<ViewResult>(resultado);
            var modelo = Assert.IsAssignableFrom<UsuarioEdicionViewModel>(
                resultadoVista.ViewData.Model
            );

            Assert.True(validacion);
        }

        [Fact]
        public async Task Enviar_correo_confirmacion_Correctamente()
        {
            var email = new EmailRecuperarViewModel(){Email = "usuario@prueba.com"};

            _mockServicioEmail.Setup(s => s.EnviarEmailReemplazoPassword(email.Email))
                .ReturnsAsync(true);
        
            var resultado = await _controller.PasswordOlvidado(email);

            var resultadoVista = Assert.IsType<RedirectToActionResult>(resultado);
        }

        [Fact]
        public async Task Reestablecer_Password_Con_Datos_Correctos_Exito()
        {
            var datosPassword = FuenteDatos.DatosPassword();
            _mockServicioUsuarios.Setup(s => s.ReestablecerPassword(datosPassword.Id, datosPassword.Token, datosPassword.Password))
                .ReturnsAsync(IdentityResult.Success);

            var resultado = await _controller.RecuperarPassword(datosPassword);

            var resultadoVista = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.True(_controller.ModelState.IsValid);
        }
    }
}