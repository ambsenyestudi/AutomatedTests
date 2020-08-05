using OpenQA.Selenium.Chrome;
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
        public bool Close()
        {
            driver.Close();
            driver.Quit();
            var isValid = driver.SessionId == null;
            return isValid;
        }
            
    }
}
