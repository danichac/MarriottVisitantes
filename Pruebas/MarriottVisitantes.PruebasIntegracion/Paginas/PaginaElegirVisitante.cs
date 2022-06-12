using System.Collections.Generic;
using System.Linq;
using MarriottVisitantes.PruebasIntegracion.Locators;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaElegirVisitante : PaginaLayout
    {
        public PaginaElegirVisitante(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.SinResultadosHeaderLocator)]
        private IWebElement SinResultadosHeader;
        [FindsBy(How = How.ClassName, Using = LocatorStrings.LinkSeleccionClassLocator)]
        private IList<IWebElement> EnlacesCedula;
        [FindsBy(How = How.ClassName, Using = LocatorStrings.BotonVisitaClassLocator)]
        private IList<IWebElement> BotonesVisita;
        [FindsBy(How = How.Id, Using = LocatorStrings.TablaVisitantesLocator)]
        private IWebElement TablaVisitantes;
        [FindsBy(How = How.Id, Using = LocatorStrings.AgregarNuevoVisitanteBotonLocator)]
        private IWebElement BotonNuevoVisitante;

        public string MensajeSinResultados()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.SinResultadosHeaderLocator)));
            return SinResultadosHeader.Text;
        }

        public PaginaVisitante ClickCedula()
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(LocatorStrings.LinkSeleccionClassLocator)));
            var primerEnlace = EnlacesCedula.FirstOrDefault();
            primerEnlace.Click();

            return new PaginaVisitante(_driver);
        }

        public PaginaVisitante ClickBotonNuevoVisitante()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.AgregarNuevoVisitanteBotonLocator)));
            BotonNuevoVisitante.Click();

            return new PaginaVisitante(_driver);
        }

        public PaginaVisita ClickAgregarVisita()
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(LocatorStrings.BotonVisitaClassLocator)));
            var primerBoton = BotonesVisita.FirstOrDefault();
            primerBoton.Click();

            return new PaginaVisita(_driver);
        }

        public int GetCantidadFilasTabla()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.TablaVisitantesLocator)));
            var cantidad = TablaVisitantes.FindElements(By.ClassName(LocatorStrings.FilaTablasLocatorClass)).Count;

            return cantidad;
        }
    }
}