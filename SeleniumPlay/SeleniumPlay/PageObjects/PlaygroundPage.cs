using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public string SetOccupation(string occupation)
        {
            IWebElement occupationForm = _driver.FindElement(By.Id("occupation"));
            SelectElement occupationSelect = new SelectElement(occupationForm);
            string occupationValue = "";

            switch (occupation)
            {
                case "Astronaut":
                    occupationValue = "astronaut";
                    break;
                case "Politician":
                    occupationValue = "politician";
                    break;
                case "Science Fiction Author":
                    occupationValue = "scifiauthor";
                    break;
            }

            occupationSelect.SelectByValue(occupationValue);

            return occupationSelect.SelectedOption.Text;
        }

        public string CountBlueBoxes()
        {
            var blueBoxes = _driver.FindElements(By.ClassName("bluebox"));

            IWebElement answerSlot4 = _driver.FindElement(By.Id("answer4"));

            answerSlot4.Clear();
            answerSlot4.SendKeys(blueBoxes.Count.ToString());

            return answerSlot4.GetAttribute("value");
        }

        public void ClickLink(string linkText)
        {
            _driver.FindElement(By.LinkText(linkText)).Click();
        }
    }
}
