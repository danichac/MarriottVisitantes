using System;
using MarriottVisitantes.PruebasIntegracion.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaLayout
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public PaginaLayout(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.BotonPerfilLocator)]
        private IWebElement BotonPerfil;
        [FindsBy(How = How.Id, Using = LocatorStrings.LinkSalirLocator)]
        private IWebElement LinkSalir;
        [FindsBy(How = How.Id, Using = LocatorStrings.NuevaVisitaLocator)]
        private IWebElement LinkNuevaVisita;
        [FindsBy(How = How.Id, Using = LocatorStrings.AgregarUsuarioLocator)]
        private IWebElement AgregarUsuarioLink;
        [FindsBy(How = How.Id, Using = LocatorStrings.ReporteVisitasLocator)]
        private IWebElement ReporteLink;

        public void ClickBotonPerfil()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.BotonPerfilLocator)));
            BotonPerfil.Click();
        }

        public PaginaLogin Salir()
        {
            ClickBotonPerfil();
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.LinkSalirLocator)));
            LinkSalir.Click();
            return new PaginaLogin(_driver);
        }

        public PaginaBuscarVisitante ClickNuevaVisita()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.NuevaVisitaLocator)));
            LinkNuevaVisita.Click();
            return new PaginaBuscarVisitante(_driver);
        }

    }
}