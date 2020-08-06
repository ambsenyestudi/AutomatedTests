using AutomatedTests.BEDCA.Domain.Pages.Base;
using OpenQA.Selenium;

namespace AutomatedTests.BEDCA.Domain.Pages
{
    public class HomePage : BasePage
    {
        public const string URL = "https://www.bedca.net/bdpub/";
        private readonly By consultaElment;

        public HomePage(IWebDriver driver):base(driver)
        {
            Navigate(URL);
            consultaElment = By.LinkText("Consulta");
        }
        public ConsultaPage GoToConsultaPage()
        {
            var consulta = FindVisibleElement(consultaElment);
            consulta.Click();

            var confirmConsulta = FindVisibleElement(By.Id(ConsultaPage.CONSULTA_AVANZADA_ID));
            if(confirmConsulta == null)
            {
                throw new NotFoundException($"{ConsultaPage.CONSULTA_AVANZADA_ID} not present on site");
            }
            return new ConsultaPage(driver);

        }
    }
}
