using MarriottVisitantes.PruebasIntegracion.Datos;
using MarriottVisitantes.PruebasIntegracion.Orden;
using MarriottVisitantes.PruebasIntegracion.Paginas;
using Xunit;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    [TestCaseOrderer("MarriottVisitantes.PruebasIntegracion.Orden.PriorityOrderer", "MarriottVisitantes.PruebasIntegracion")]
    public class AgregarVisitansTests : IClassFixture<MainTest>
    {
        MainTest testFixture;

        public AgregarVisitansTests(MainTest testFixture)
        {
            this.testFixture = testFixture;
        }

        [Fact, TestPriority(1)]
        public void Agregar_Visitan_Extensa_Sin_Gafete_Error()
        {
            var paginaLogin = testFixture.IrLogin();
            var paginaInicio = testFixture.Login(paginaLogin);
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
            
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();
            var paginaVisita = paginaElegir.ClickAgregarVisita();

            paginaVisita.ElegirTipoVisita("Extensa");
            paginaVisita.ClickAgregarNuevaVisita();

            var validacionColor = paginaVisita.ObtenerValidacionColor();
            var validacionNum = paginaVisita.ObtenerValidacionNumero();

            Assert.Equal("El color de gafete es requerido para una visita extensa", validacionColor);
            Assert.Equal("El número de gafete es requerido para una visita extensa", validacionNum);
        }

        [Fact, TestPriority(2)]
        public void Agregar_Visita_Con_Datos_Validos_Exito()
        {
            var paginaInicio = testFixture.IrInicio();
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
            
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();
            var paginaVisita = paginaElegir.ClickAgregarVisita();

            paginaVisita.ElegirTipoVisita("Extensa");
            paginaVisita.ElegirColor("Verde");
            paginaVisita.IngresarNumeroGafete("12");
            paginaInicio = paginaVisita.ClickAgregarNuevaVisita();

            var mensajeExito = paginaInicio.GetMensajeExito();

            Assert.True(mensajeExito.Contains("Visita"));
            Assert.True(mensajeExito.Contains("agregada"));
        }

        [Fact, TestPriority(3)]
        public void Terminar_Visita_Con_Exito()
        {
            var paginaInicio = testFixture.IrInicio();
            paginaInicio.ClickTerminarPrimeraVisita();

            var exito = paginaInicio.GetMensajeExito();

            Assert.True(exito.Contains("Visita"));
            Assert.True(exito.Contains("terminada"));

            testFixture.Salir();
        }
    }
}
