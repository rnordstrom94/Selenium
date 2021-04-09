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
            IWebElement answerSlot1 = _driver.FindElement(By.Id("answer1"));

            answerSlot1.Clear();
            answerSlot1.SendKeys(title);

            return answerSlot1.GetAttribute("value");
        }

        public string FillNameSlot(string name)
        {
            IWebElement nameSlot = _driver.FindElement(By.Id("name"));

            nameSlot.Clear();
            nameSlot.SendKeys(name);

            return nameSlot.GetAttribute("value");
        }
    }
}
