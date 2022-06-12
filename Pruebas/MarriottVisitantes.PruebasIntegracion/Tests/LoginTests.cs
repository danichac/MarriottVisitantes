using MarriottVisitantes.PruebasIntegracion.Datos;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    public class LoginTests: MainTest
    {
        
        [Fact, Order(1)]
        public void Login_Informacion_Incorrecta_Mensaje_error()
        {
            var paginaLogin = IrLogin();
            paginaLogin.IngresarEmail(FuenteDatos.EmailIncorrecto);
            paginaLogin.IngresarPassword(FuenteDatos.PasswordCorrecto);
            paginaLogin.ClickIngresar();

            var datosError = paginaLogin.ObtenerDatosError();

            Assert.NotEmpty(datosError);
            Assert.Equal("Correo electrónico o contraseña incorrecta", datosError);
            Terminar();
        }

        [Fact, Order(2)]
        public void Login_Informacion_Correcta_Ingreso_Exitoso()
        {
            var paginaLogin = IrLogin();
            Login(paginaLogin);

            var datosExito = paginaLogin.ObtenerDatosExito();

            Assert.NotEmpty(datosExito);
            Assert.Equal("Visitantes del día", datosExito);
            
            Terminar();
        }

        [Fact, Order(3)]
        public void Salir_Con_exito()
        {
            var paginaLogin = IrLogin();
            var paginaInicio = Login(paginaLogin);
            paginaLogin = paginaInicio.Salir();
            var headerInicio = paginaLogin.ObtenerHeaderInicio();

            Assert.Equal("Inicio de sesión", headerInicio);

            Terminar();
        }
    }
}