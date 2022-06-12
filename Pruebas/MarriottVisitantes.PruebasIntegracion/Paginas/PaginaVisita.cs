using MarriottVisitantes.PruebasIntegracion.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaVisita : PaginaLayout
    {
    
        public PaginaVisita(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.ColorGafeteSelectLocator)]
        private IWebElement ColorGafeteSelect;
        [FindsBy(How = How.Id, Using = LocatorStrings.ValidacionColorLocator)]
        private IWebElement ValidacionColor;
        [FindsBy(How = How.Id, Using = LocatorStrings.TipoVisitaSelectLocator)]
        private IWebElement TipoVisitaSelect;
        [FindsBy(How = How.Id, Using = LocatorStrings.NumeroGafeteLocator)]
        private IWebElement NumerGafeteInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.ValidacionNumeroGafeteLocator)]
        private IWebElement NumeroGafeteValidacion;
        [FindsBy(How = How.Id, Using = LocatorStrings.AgregarNuevaVisitaBotonLocator)]
        private IWebElement BotonAgregarNuevaVisita;

        public void ElegirTipoVisita(string tipo)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.TipoVisitaSelectLocator)));
            var select = new SelectElement(TipoVisitaSelect);
            select.SelectByValue(tipo);
            
        }

        public void ElegirColor(string color)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.ColorGafeteSelectLocator)));
            var select = new SelectElement(ColorGafeteSelect);
            select.SelectByValue(color);
        }

        public void IngresarNumeroGafete(string numero)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.NumeroGafeteLocator)));
            NumerGafeteInput.SendKeys(numero);
        }

        public PaginaInicio ClickAgregarNuevaVisita()
        {
            Actions action = new Actions(_driver);
            action.ScrollByAmount(0, 350);
            action.MoveToElement(BotonAgregarNuevaVisita).Click().Build().Perform();

            return new PaginaInicio(_driver);
        }

        public string ObtenerValidacionColor()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.ValidacionColorLocator)));
            return ValidacionColor.Text;
        }

        public string ObtenerValidacionNumero()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.ValidacionNumeroGafeteLocator)));
            return NumeroGafeteValidacion.Text;
        }
    }
}