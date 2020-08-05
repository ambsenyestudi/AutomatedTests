using OpenQA.Selenium.Chrome;
using System;

namespace Selenium.NetCore
{
    public class SeleniumActor
    {
        public const string GOOGLE_URL = "http://www.google.com";
        private readonly ChromeDriver driver;

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
        public bool NavigateToGoogle() =>
            NavigateTo(GOOGLE_URL);
    }
}
