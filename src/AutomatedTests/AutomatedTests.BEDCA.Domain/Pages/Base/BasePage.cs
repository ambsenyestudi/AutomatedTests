using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using extras = SeleniumExtras.WaitHelpers;

namespace AutomatedTests.BEDCA.Domain.Pages.Base
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected virtual void Navigate(string url) =>
            driver.Navigate().GoToUrl(url);

        protected virtual IWebElement FindVisibleElement(By element)
        {
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            return waiter.Until(extras.ExpectedConditions.ElementIsVisible(element));
        }
        //Todo implement clicable
    }
}
