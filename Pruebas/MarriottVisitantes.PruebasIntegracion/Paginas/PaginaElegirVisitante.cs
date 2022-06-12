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

        public string MensajeSinResultados()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.SinResultadosHeaderLocator)));
            return SinResultadosHeader.Text;
        }
    }
}