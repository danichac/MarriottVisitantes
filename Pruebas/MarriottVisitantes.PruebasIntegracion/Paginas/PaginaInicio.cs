using System;
using System.Linq;
using System.Collections.Generic;
using MarriottVisitantes.PruebasIntegracion.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaInicio : PaginaLayout
    {

        public PaginaInicio(IWebDriver driver) : base(driver)
        {
            
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.MensajeExitoLocator)]
        private IWebElement MensajeExito;
        [FindsBy(How = How.ClassName, Using = LocatorStrings.BotonesTerminarClassLocator)]
        private IList<IWebElement> BotonesTerminar;

        public string GetMensajeExito() 
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.MensajeExitoLocator)));
            return MensajeExito.Text;
        }

        public void ClickTerminarPrimeraVisita()
        {
            _wait.Until(ExpectedConditions
                    .PresenceOfAllElementsLocatedBy(By.ClassName(LocatorStrings.BotonesTerminarClassLocator)));
            
            var primerBoton = BotonesTerminar.FirstOrDefault();
            primerBoton.Click();
        }


    }
}