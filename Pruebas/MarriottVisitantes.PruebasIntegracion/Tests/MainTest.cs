using MarriottVisitantes.PruebasIntegracion.Datos;
using MarriottVisitantes.PruebasIntegracion.Paginas;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    public class MainTest
    {
        private const string url = "https://localhost:5001/";
        private readonly IWebDriver _driver;
        protected readonly PaginaInicio _paginaInicio;
        

        public MainTest()
        {
            _driver = new ChromeDriver();
            _paginaInicio = new PaginaInicio(_driver);
        }

        public void IrInicio()
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void Terminar()
        {
            _driver.Close();
            _driver.Quit();
        }


        public PaginaLogin IrLogin()
        {   
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            return new PaginaLogin(_driver);
        }

        protected PaginaInicio Login(PaginaLogin pagina)
        {
            pagina.IngresarEmail(FuenteDatos.EmailCorrecto);
            pagina.IngresarPassword(FuenteDatos.PasswordCorrecto);
            var paginaInicio = pagina.ClickIngresar();
            return paginaInicio;
        }

        protected PaginaLogin Salir()
        {
            return _paginaInicio.Salir();
        }
    }
}