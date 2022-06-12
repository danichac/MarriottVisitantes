using MarriottVisitantes.PruebasIntegracion.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaBuscarVisitante : PaginaLayout
    {
        public PaginaBuscarVisitante(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.CedulaLocator)]
        private IWebElement CedulaInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.NombreEmpresaLocator)]
        private IWebElement EmpresasSelect;
        [FindsBy(How = How.Id, Using = LocatorStrings.BuscarVisitanteBotonLocator)]
        private IWebElement BotonBuscar;
        [FindsBy(How = How.Id, Using = LocatorStrings.NuevoVisitanteBotonLocator)]
        private IWebElement BotonNuevoVisitante;

        public void IngresarCedula(string cedula)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.CedulaLocator)));
            CedulaInput.SendKeys(cedula);
        }

        public void SeleccionarEmpresa(string empresa)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.NombreEmpresaLocator)));
            var select = new SelectElement(EmpresasSelect);
            select.SelectByValue(empresa);
        }

        public PaginaElegirVisitante ClickBuscarVisitante()
        {
            BotonBuscar.Click();
            return new PaginaElegirVisitante(_driver);
        }
    }
}