using AutomatedTests.BEDCA.Domain.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AutomatedTests.Test
{
    public class BedcaShould
    {
        public const string PLATANO_SEARCH_TERM = "plátano";
        private readonly IWebDriver driver;

        public BedcaShould()
        {
            driver = new ChromeDriver();
        }
        [Fact]
        public void GoToConsulta()
        {
            var home = new HomePage(driver);
            var consultas = home.GoToConsultaPage();
            var consultaAvanzada = consultas.GoToConsultaAvanzadaPage();
            var results = consultaAvanzada.SearchFood(PLATANO_SEARCH_TERM);
            var nutritionFacts = results.ClickOnResult(PLATANO_SEARCH_TERM);
            Assert.True(nutritionFacts != null);
        }
    }
}
