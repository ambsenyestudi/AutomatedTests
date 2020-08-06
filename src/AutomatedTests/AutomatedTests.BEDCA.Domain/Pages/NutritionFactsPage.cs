using AutomatedTests.BEDCA.Domain.Pages.Base;
using OpenQA.Selenium;

namespace AutomatedTests.BEDCA.Domain.Pages
{
    public class NutritionFactsPage : BasePage
    {
        public const string TITLE_FOOD_NAME = "foodname";
        public NutritionFactsPage(IWebDriver driver) : base(driver)
        {
        }
    }
}