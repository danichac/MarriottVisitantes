using MarriottVisitantes.PruebasIntegracion.Datos;
using MarriottVisitantes.PruebasIntegracion.Orden;
using Xunit;


namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    [TestCaseOrderer("MarriottVisitantes.PruebasIntegracion.Orden.PriorityOrderer", "MarriottVisitantes.PruebasIntegracion")]
    public class BuscarVisitanteTests : IClassFixture<MainTest>
    {
        MainTest testFixture;

        public BuscarVisitanteTests(MainTest testFixture)
        {
            this.testFixture = testFixture;
        }

        [Fact, TestPriority(1)]
        public void A_Buscar_Con_Cedula_y_Empresa_Inexistentes_No_Resultados()
        {
            var paginaLogin = testFixture.IrLogin();
            var paginaInicio = testFixture.Login(paginaLogin);
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
            
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaNoExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();

            var sinResultados = paginaElegir.MensajeSinResultados();

            Assert.Equal("La búsqueda no obtuvo resultados.", sinResultados);
        }

        [Fact, TestPriority(2)]
        public void B_Buscar_Cedula_Existente_ProduceResultados()
        {
            var paginaInicio = testFixture.IrInicio();
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
        
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();
        
            var cantidadResultados = paginaElegir.GetCantidadFilasTabla();

            Assert.Equal(1, cantidadResultados);
        }

        [Fact, TestPriority(3)]
        public void C_Buscar_Empresa_Existente_ProduceResultados()
        {
            var paginaInicio = testFixture.IrInicio();
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
        
            paginaBuscar.SeleccionarEmpresa(FuenteDatos.EmpresaExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();
        
            var cantidadResultados = paginaElegir.GetCantidadFilasTabla();

            Assert.Equal(3, cantidadResultados);
            testFixture.Salir();
        }

    }
}
