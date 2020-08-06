using AutomatedTests.BEDCA.Domain.Pages.Base;
using OpenQA.Selenium;
using System;

namespace AutomatedTests.BEDCA.Domain.Pages
{
    public class ConsultaAvanzadaResultsPage:BasePage
    {
        public const string FOOD_TABLE_ID = "querytable1";
        public ConsultaAvanzadaResultsPage(IWebDriver driver) : base(driver)
        {
        }
        public NutritionFactsPage ClickOnResult(string result)
        {
            var link = FindVisibleElement(By.PartialLinkText(result));
            link.Click();
            var foodConfirm = FindVisibleElement(By.Name(NutritionFactsPage.TITLE_FOOD_NAME));
            if (!foodConfirm.Text.Contains(result))
            {
                return null;
            }
            return new NutritionFactsPage(driver);
        }
    }
}
