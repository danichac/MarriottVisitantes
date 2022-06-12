using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using MarriottVisitantes.PruebasIntegracion.Locators;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaLogin
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public PaginaLogin(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.EmailLoginLocator)]
        private IWebElement EmailInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.PasswordLoginLocator)]
        private IWebElement PasswordInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.IngresarLoginBotonLocator)]
        private IWebElement IngresarBoton;
        [FindsBy(How = How.Id, Using = LocatorStrings.DatosErrorLocator)]
        private IWebElement DatosError;
        [FindsBy(How = How.Id, Using = LocatorStrings.VisitantesHeaderLocator)]
        private IWebElement VisitantesHeader;
        [FindsBy(How = How.Id, Using = LocatorStrings.InicioHeaderLocator)]
        private IWebElement InicioHeader;

        public void IngresarEmail(string email)
        {   
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id(LocatorStrings.EmailLoginLocator)));
            EmailInput.SendKeys(email);
        }

        public void IngresarPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public string ObtenerDatosError()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.DatosErrorLocator)));
            return DatosError.Text;
        }

        public string ObtenerDatosExito()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.VisitantesHeaderLocator)));
            return VisitantesHeader.Text;
        }

        public PaginaInicio ClickIngresar()
        {
            IngresarBoton.Click();
            return new PaginaInicio(_driver);
        }

        public string ObtenerHeaderInicio()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.InicioHeaderLocator)));
            return InicioHeader.Text;
        }
    }
}