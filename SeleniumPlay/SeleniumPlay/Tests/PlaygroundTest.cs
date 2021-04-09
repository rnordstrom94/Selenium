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

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
