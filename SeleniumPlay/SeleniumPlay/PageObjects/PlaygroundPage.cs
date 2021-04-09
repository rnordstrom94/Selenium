using OpenQA.Selenium;

namespace SeleniumPlay.PageObjects
{
    public class PlaygroundPage
    {
        private IWebDriver _driver;
        private const string URL = @"http://timvroom.com/selenium/playground/";
        public static string Title { get; } = "Selenium Playground";

        public PlaygroundPage(IWebDriver driver)
        {
            _driver = driver;

            _driver.Navigate().GoToUrl(URL);

            if (driver.Title != Title)
            {
                throw new WebDriverException("Page could not be loaded.");
            }
        }

        public string FillTitleAnswerSlot()
        {
            string title = _driver.Title;
            IWebElement answerSlot = _driver.FindElement(By.Id("answer1"));

            answerSlot.Clear();
            answerSlot.SendKeys(title);

            return answerSlot.GetAttribute("value");
        }
    }
}
