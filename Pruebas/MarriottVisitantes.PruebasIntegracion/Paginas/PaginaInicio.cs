using System;
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

    }
}