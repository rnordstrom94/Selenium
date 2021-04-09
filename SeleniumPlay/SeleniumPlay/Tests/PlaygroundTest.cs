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

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void TestPlaygroundPage()
        {
            PlaygroundPage pp = new PlaygroundPage(driver);

            Assert.AreEqual(PlaygroundPage.Title, pp.FillTitleAnswerSlot());
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
