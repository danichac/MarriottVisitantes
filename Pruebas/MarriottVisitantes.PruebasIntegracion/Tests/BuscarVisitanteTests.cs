using MarriottVisitantes.PruebasIntegracion.Datos;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    public class BuscarVisitanteTests : MainTest
    {
        [Fact]
        public void Buscar_Con_Cedula_y_Empresa_Inexistentes_No_Resultados()
        {
            var paginaLogin = IrLogin();
            var paginaInicio = Login(paginaLogin);
            var paginaBuscar = paginaInicio.ClickNuevaVisita();
            
            paginaBuscar.IngresarCedula(FuenteDatos.CedulaNoExiste);
            var paginaElegir = paginaBuscar.ClickBuscarVisitante();

            var sinResultados = paginaElegir.MensajeSinResultados();

            Assert.Equal("La búsqueda no obtuvo resultados.", sinResultados);
            Salir();
            Terminar();
        }
    }
}