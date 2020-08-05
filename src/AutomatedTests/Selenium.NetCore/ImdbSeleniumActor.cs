using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using extras = SeleniumExtras.WaitHelpers;
namespace Selenium.NetCore
{
    public class ImdbSeleniumActor : SeleniumActor
    {
        private readonly bool isWait;
        public const string IMDB_URL = "https://www.imdb.com/";
        public const string MOVIE_HEADER = "findHeader";
        public const string SEARCH_INPUT = "suggestion-search";
        public By SearchElement { get; }
        public By MovieHeaderElment { get; }

        public ImdbSeleniumActor(bool isWait = false)
        {
            SearchElement = By.Id(SEARCH_INPUT);
            MovieHeaderElment = By.ClassName("findHeader");
            this.isWait = isWait;
        }

        public bool SearchMovie(string title)
        {
            NavigateTo(IMDB_URL);
            var seachInput = FindElement(SearchElement);
            seachInput.SendKeys(title);
            seachInput.SendKeys(Keys.Enter);
            
            return IsMovieFound(title);
        }
        public bool FindMore(string title)
        {
            var success = SearchMovie(title);
            if(!success)
            {
                return false;
            }
            var relatedMovies = FindClickableElement(By.LinkText("More title matches"));
            relatedMovies.Click();
            var titleList = FindVisibleElement(By.ClassName("findList"));
            return titleList != null;
        }
        private bool IsMovieFound(string title) =>
            FindMovieHeader(title);

        private bool FindMovieHeader(string title)
        {
            var result = driver.FindElement(MovieHeaderElment);
            if (isWait)
            {
                result = FindVisibleElement(MovieHeaderElment);
            }            
            return result.Text.Contains(title);
        }
        private IWebElement FindVisibleElement(By element, int waitSeconds = 60)
        {
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            return waiter.Until(extras.ExpectedConditions.ElementIsVisible(element));
        }
        private IWebElement FindClickableElement(By element, int waitSeconds = 60)
        {
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            return waiter.Until(extras.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
