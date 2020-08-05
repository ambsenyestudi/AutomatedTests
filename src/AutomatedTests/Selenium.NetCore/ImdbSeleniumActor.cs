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
        public const string MOVIE_HEADER_CLASS = "findHeader";
        public const string SEARCH_INPUT_ID = "suggestion-search";
        public const string MORE_LINK_TEXT = "More title matches";
        public const string MORE_LIST_CLASS = "findList";
        public By SearchElement { get; }
        public By MovieHeaderElment { get; }
        public By MoreLikeThisElement { get; }
        public By MoreLikeThisListElmeent { get; }

        public ImdbSeleniumActor(bool isWait = false)
        {
            SearchElement = By.Id(SEARCH_INPUT_ID);
            MovieHeaderElment = By.ClassName(MOVIE_HEADER_CLASS);
            MoreLikeThisElement = By.LinkText(MORE_LINK_TEXT);
            MoreLikeThisListElmeent = By.ClassName("findList");
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
            var relatedMovies = FindClickableElement(MoreLikeThisElement);
            relatedMovies.Click();
            var titleList = FindVisibleElement(MoreLikeThisListElmeent);
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
