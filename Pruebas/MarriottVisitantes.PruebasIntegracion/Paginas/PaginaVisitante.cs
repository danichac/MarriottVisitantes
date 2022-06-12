using MarriottVisitantes.PruebasIntegracion.Locators;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace MarriottVisitantes.PruebasIntegracion.Paginas
{
    public class PaginaVisitante : PaginaLayout
    {

        public PaginaVisitante(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = LocatorStrings.CedulaLocator)]
        private IWebElement CedulaInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.ValidacionCedulaLocator)]
        private IWebElement ValidacionCedula;
        [FindsBy(How = How.Id, Using = LocatorStrings.PrimerNombreLocator)]
        private IWebElement PrimerNombreInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.SegundoNombreLocator)]
        private IWebElement SegundoNombreInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.PrimerApellidoLocator)]
        private IWebElement PrimerApellidoInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.SegundoApellidoLocator)]
        private IWebElement SegundoApellidoInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.NombreEmpresaLocator)]
        private IWebElement NombreEmpresaInput;
        [FindsBy(How = How.Id, Using = LocatorStrings.AgregarVisitanteBotonLocator)]
        private IWebElement BotonAgregar;
        [FindsBy(How = How.Id, Using = LocatorStrings.MensajeExitoLocator)]
        private IWebElement MensajeExito;

        public void IngresarDato(DatosEnum dato, string valor)
        {
            switch(dato)
            {
                case DatosEnum.Cedula:
                    CedulaInput.Clear();
                    CedulaInput.SendKeys(valor);
                    break;
                case DatosEnum.PrimerNombre:
                    PrimerNombreInput.Clear();
                    PrimerNombreInput.SendKeys(valor);
                    break;
                case DatosEnum.SegundoNombre:
                    SegundoNombreInput.Clear();
                    SegundoNombreInput.SendKeys(valor);
                    break;
                case DatosEnum.PrimerApellido:
                    PrimerApellidoInput.Clear();
                    PrimerApellidoInput.SendKeys(valor);
                    break;
                case DatosEnum.SegundoApellido:
                    SegundoApellidoInput.Clear();
                    SegundoApellidoInput.SendKeys(valor);
                    break;
                case DatosEnum.Empresa:
                    NombreEmpresaInput.Clear();
                    NombreEmpresaInput.SendKeys(valor);
                break;
            }
        }

        public void ClickAgregarVisitante()
        {
            BotonAgregar.Click();
        }

        public string ObtenerExitoVisitante()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.MensajeExitoLocator)));
            return MensajeExito.Text;
        }

        public string ObtenerErrorCedula()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Id(LocatorStrings.ValidacionCedulaLocator)));
            return ValidacionCedula.Text;
        }
    }
}