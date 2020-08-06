using AutomatedTests.BEDCA.Domain.Pages.Base;
using OpenQA.Selenium;

namespace AutomatedTests.BEDCA.Domain.Pages
{
    public class ConsultaPage : BasePage
    {
        public const string CONSULTA_AVANZADA_ID = "Avanzada";
        public By ConsultaAbanzadaElement { get; }
        public ConsultaPage(IWebDriver driver) : base(driver)
        {
            ConsultaAbanzadaElement = By.Id(CONSULTA_AVANZADA_ID);
        }

        

        public ConsultaAvanzadaPage GoToConsultaAvanzadaPage()
        {
            var consultaAvanzada = FindVisibleElement(ConsultaAbanzadaElement);
            consultaAvanzada.Click();

            var confirmConsulta = FindVisibleElement(By.Name(ConsultaAvanzadaPage.INPUT_FOOD_NAME));
            if (confirmConsulta == null)
            {
                throw new NotFoundException($"{ConsultaPage.CONSULTA_AVANZADA_ID} not present on site");
            }
            return new ConsultaAvanzadaPage(driver);

        }
    }
}