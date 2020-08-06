using AutomatedTests.BEDCA.Domain.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTests.BEDCA.Domain.Pages
{
    public class ConsultaAvanzadaPage : BasePage
    {
        public const string INPUT_FOOD_NAME = "foodname";
        public By SearchFoodElement { get; }

        public ConsultaAvanzadaPage(IWebDriver driver) : base(driver)
        {
            SearchFoodElement = By.Name(INPUT_FOOD_NAME);
        }
        
        public ConsultaAvanzadaResultsPage SearchFood(string search)
        {
            TypeSeachToInput(search);
            var result = FindVisibleElement(By.Id(ConsultaAvanzadaResultsPage.FOOD_TABLE_ID));
            if(result==null)
            {
                throw new NotFoundException($"{ConsultaAvanzadaResultsPage.FOOD_TABLE_ID} not present on site");
            }
            return new ConsultaAvanzadaResultsPage(driver);
        }

        private void TypeSeachToInput(string search)
        {
            var inputField = FindVisibleElement(SearchFoodElement);
            inputField.SendKeys(search);
            inputField.SendKeys(Keys.Enter);
        }
    }
}
