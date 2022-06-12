using MarriottVisitantes.PruebasIntegracion.Datos;
using MarriottVisitantes.PruebasIntegracion.Orden;
using Xunit;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    [TestCaseOrderer("MarriottVisitantes.PruebasIntegracion.Orden.PriorityOrderer", "MarriottVisitantes.PruebasIntegracion")]
    public class LoginTests: IClassFixture<MainTest>
    {
        MainTest testFixture;

        public LoginTests(MainTest mainTest)
        {
            testFixture = mainTest;
        }
        
        [Fact, TestPriority(1)]
        public void Login_Informacion_Incorrecta_Mensaje_error()
        {
            var paginaLogin = testFixture.IrLogin();
            paginaLogin.IngresarEmail(FuenteDatos.EmailIncorrecto);
            paginaLogin.IngresarPassword(FuenteDatos.PasswordCorrecto);
            paginaLogin.ClickIngresar();

            var datosError = paginaLogin.ObtenerDatosError();

            Assert.NotEmpty(datosError);
            Assert.Equal("Correo electrónico o contraseña incorrecta", datosError);
        }

        [Fact, TestPriority(2)]
        public void Login_Informacion_Correcta_Ingreso_Exitoso()
        {
            var paginaLogin = testFixture.IrLogin();
            testFixture.Login(paginaLogin);

            var datosExito = paginaLogin.ObtenerDatosExito();

            Assert.NotEmpty(datosExito);
            Assert.Equal("Visitantes del día", datosExito);
        }

        [Fact, TestPriority(3)]
        public void Salir_Con_exito()
        {
            var paginaInicio = testFixture.IrInicio();
            var paginaLogin = paginaInicio.Salir();
            var headerInicio = paginaLogin.ObtenerHeaderInicio();

            Assert.Equal("Inicio de sesión", headerInicio);
        }
    }
}