using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPlay.PageObjects;

namespace SeleniumPlay.Tests
{
    [TestFixture]
    class PlaygroundTest
    {
        IWebDriver driver;
        PlaygroundPage pp;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
            pp = new PlaygroundPage(driver);
        }

        [Test]
        public void TestTask1()
        {
            Assert.AreEqual(PlaygroundPage.Title, pp.FillTitleAnswerSlot());
        }

        [Test]
        public void TestTask2()
        {
            string name = "Kilgore Trout";

            Assert.AreEqual(name, pp.FillNameSlot(name));
        }

        [Test]
        public void TestTask3()
        {
            string occupation = "Science Fiction Author";

            Assert.AreEqual(occupation, pp.SetOccupation(occupation)); 
        }

        [Test]
        public void TestTask4()
        {
            Assert.IsFalse(string.IsNullOrEmpty(pp.CountBlueBoxes()));
        }

        [Test]
        public void TestTask5()
        {
            pp.ClickLink("click me"); // This link doesn't seem to do anything (on FireFox), so testing with asserts is difficult.
        }

        [Test]
        public void TestTask6()
        {
            Assert.AreEqual("maroon", pp.FindRedBoxClass());
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
