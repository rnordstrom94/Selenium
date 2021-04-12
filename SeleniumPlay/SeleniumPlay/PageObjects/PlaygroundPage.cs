using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Linq;

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

        public string FindRedBoxClass()
        {
            IWebElement redBox = _driver.FindElement(By.Id("redbox"));
            IWebElement answerSlot6 = _driver.FindElement(By.Id("answer6"));

            answerSlot6.Clear();
            answerSlot6.SendKeys(redBox.GetAttribute("class"));

            return answerSlot6.GetAttribute("value");
        }

        public void ExecuteJavaScriptNoReturn()
        {
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;

            js.ExecuteScript("ran_this_js_function()");
        }

        public string ExecuteJavaScriptReturn()
        {
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            IWebElement answerSlot8 = _driver.FindElement(By.Id("answer8"));

            var result = js.ExecuteScript("return got_return_from_js_function()");

            if (result != null)
            {
                answerSlot8.Clear();
                answerSlot8.SendKeys(result.ToString());
            }

            return answerSlot8.GetAttribute("value");
        }

        public bool SelectRadioButton(string option)
        {
            IWebElement form = _driver.FindElement(By.Id("testform"));
            IWebElement radioButton1 = form.FindElement(By.CssSelector("[value=\"wrotebook\"]"));
            IWebElement radioButton2 = form.FindElement(By.CssSelector("[value=\"didntwritebook\"]"));
            bool selected = false;

            switch (option)
            {
                case "Wrote Book":
                    radioButton1.Click();
                    selected = radioButton1.Selected;
                    break;
                case "Didn't Write Book":
                    radioButton2.Click();
                    selected = radioButton2.Selected;
                    break;
            }

            return selected;
        }

        public string RedBoxText()
        {
            IWebElement redBox = _driver.FindElement(By.Id("redbox"));
            IWebElement answerSlot10 = _driver.FindElement(By.Id("answer10"));
            string redBoxText = redBox.Text;

            answerSlot10.Clear();
            answerSlot10.SendKeys(redBoxText);

            return answerSlot10.GetAttribute("value");
        }

        public string BoxOnTop()
        {
            var allBoxes = _driver.FindElements(By.CssSelector("span:not(.ok)"));
            IWebElement firstBox = allBoxes[allBoxes.Count - 2];
            string answer = "";

            if (firstBox != null)
            {
                string color = firstBox.Text.Split(" ")[0];
                answer = color.First().ToString().ToUpper() + color.Substring(1);
                IWebElement answerSlot11 = _driver.FindElement(By.Id("answer11"));

                answerSlot11.Clear();
                answerSlot11.SendKeys(answer);

                return answerSlot11.GetAttribute("value");
            }

            return answer;
        }

        public Size SetBrowserSize(int width, int height)
        {
            _driver.Manage().Window.Size = new Size(width, height);

            return _driver.Manage().Window.Size;
        }

        public string CheckIsHere()
        {
            IWebElement isHere;
            string answer;

            try
            {
                isHere = _driver.FindElement(By.Id("ishere"));
                answer = "yes";
            }
            catch (NoSuchElementException)
            {
                answer = "no";
            }

            IWebElement answerSlot13 = _driver.FindElement(By.Id("answer13"));

            answerSlot13.Clear();
            answerSlot13.SendKeys(answer);

            return answerSlot13.GetAttribute("value");
        }

        public string CheckPurpleBox()
        {
            IWebElement purpleBox = _driver.FindElement(By.Id("purplebox"));
            IWebElement answerSlot14 = _driver.FindElement(By.Id("answer14"));

            string answer;

            if (purpleBox.Displayed)
            {
                answer = "yes";
            }
            else
            {
                answer = "no";
            }

            answerSlot14.Clear();
            answerSlot14.SendKeys(answer);

            return answerSlot14.GetAttribute("value");
        }
    }
}
