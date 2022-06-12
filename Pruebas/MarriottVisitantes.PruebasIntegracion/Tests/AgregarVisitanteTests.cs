using MarriottVisitantes.PruebasIntegracion.Datos;
using MarriottVisitantes.PruebasIntegracion.Orden;
using MarriottVisitantes.PruebasIntegracion.Paginas;
using Xunit;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    [TestCaseOrderer("MarriottVisitantes.PruebasIntegracion.Orden.PriorityOrderer", "MarriottVisitantes.PruebasIntegracion")]
    public class AgregarVisitanteTests : IClassFixture<MainTest>
    {
        MainTest testFixture;

        public AgregarVisitanteTests(MainTest testFixture)
        {
            this.testFixture = testFixture;
        }

        [Fact, TestPriority(1)]
        public void Agregar_Visitante_Sin_Cedula_Error()
        {
            var paginaLogin = testFixture.IrLogin();
            var paginaInicio = testFixture.Login(paginaLogin);
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
            
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaNoExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();

            var paginaAgregar = paginaElegir.ClickBotonNuevoVisitante();

            paginaAgregar.IngresarDato(DatosEnum.Cedula, "");
            paginaAgregar.ClickAgregarVisitante();
            var mensajeError = paginaAgregar.ObtenerErrorCedula();

            Assert.Equal("La identificación es requerida", mensajeError);
        }

        [Fact, TestPriority(2)]
        public void Actualizar_Visitante_Con_Datos_Validos_Exito()
        {
            var paginaInicio = testFixture.IrInicio();
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
            
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();
            var paginaVisitante = paginaElegir.ClickCedula();
            
            paginaVisitante.IngresarDato(DatosEnum.SegundoNombre, "Esteban");
            paginaVisitante.ClickAgregarVisitante();

            var mensajeExito = paginaVisitante.ObtenerExitoVisitante();
            var mensajeEsperado = $"Visitante con identificación {FuenteDatos.CedulaExiste} actualizado.";

            Assert.Equal(mensajeEsperado, mensajeExito);
            testFixture.Salir();
        }
    }
}
