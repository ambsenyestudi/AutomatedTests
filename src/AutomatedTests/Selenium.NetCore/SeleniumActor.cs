using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium.NetCore
{
    public class SeleniumActor
    {
        
        protected readonly ChromeDriver driver;

        public SeleniumActor()
        {
            driver = new ChromeDriver();
        }
        public bool NavigateTo(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        protected IWebElement FindElement(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(d => d.FindElement(by));
        }

        public bool Close()
        {
            driver.Close();
            driver.Quit();
            var isValid = driver.SessionId == null;
            return isValid;
        }
            
    }
}
