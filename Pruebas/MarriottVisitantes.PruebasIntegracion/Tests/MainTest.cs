using System;
using MarriottVisitantes.PruebasIntegracion.Datos;
using MarriottVisitantes.PruebasIntegracion.Paginas;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarriottVisitantes.PruebasIntegracion.Tests
{
    public class MainTest : IDisposable
    {
        private const string url = "https://localhost:5001/";
        private readonly IWebDriver _driver;
        protected readonly PaginaInicio _paginaInicio;
        

        public MainTest()
        {
            _driver = new ChromeDriver();
            _paginaInicio = new PaginaInicio(_driver);
        }

        public PaginaInicio IrInicio()
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            return new PaginaInicio(_driver);
        }

        private void Terminar()
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

        public PaginaInicio Login(PaginaLogin pagina)
        {
            pagina.IngresarEmail(FuenteDatos.EmailCorrecto);
            pagina.IngresarPassword(FuenteDatos.PasswordCorrecto);
            var paginaInicio = pagina.ClickIngresar();
            return paginaInicio;
        }

        public PaginaLogin Salir()
        {
            return _paginaInicio.Salir();
        }

        public void Dispose()
        {
            Terminar();
        }
    }
}