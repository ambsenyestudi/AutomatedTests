using OpenQA.Selenium;
using System;

namespace Selenium.NetCore
{
    public class GoogleSeleniumActor: SeleniumActor
    {
        public const string GOOGLE_URL = "http://www.google.com";
        public const string INPUT_QUESTION_NAME = "q";
        public bool Ask(string question)
        {
            try
            {
                NavigateTo(GOOGLE_URL);
                TypeQuestionToInput(question);
                return IsQuestionAnswered(question);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsQuestionAnswered(string question) =>
            driver.Title.Contains(question);

        private void TypeQuestionToInput(string question)
        {
            var questionInput = FindQuestionInput();
            questionInput.SendKeys(question);
            questionInput.SendKeys(Keys.Enter);
        }

        private IWebElement FindQuestionInput()
        {
            var questionInput = FindElement(By.Name(INPUT_QUESTION_NAME));
            if(questionInput==null)
            {
                throw new NotFoundException($"{INPUT_QUESTION_NAME} not present on site");
            }
            return questionInput;
        }

        
    }
}
