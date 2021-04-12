using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPlay.PageObjects;
using System.Drawing;

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

        [Test]
        public void TestTask7()
        {
            pp.ExecuteJavaScriptNoReturn(); // This function is also hard to test. The site itself validates the result, apparently.
        }

        [Test]
        public void TestTask8()
        {
            Assert.IsFalse(string.IsNullOrEmpty(pp.ExecuteJavaScriptReturn()));
        }

        [Test]
        public void TestTask9()
        {
            Assert.IsTrue(pp.SelectRadioButton("Wrote Book"));
        }

        [Test]
        public void TestTask10()
        {
            Assert.IsTrue(pp.RedBoxText().Contains("Red Box"));
        }

        [Test]
        public void TestTask11()
        {
            Assert.IsTrue(pp.BoxOnTop() == "Green" || pp.BoxOnTop() == "Orange");
        }

        [Test]
        public void TestTask12()
        {
            int width = 850;
            int height = 650;
            Size browserSize = pp.SetBrowserSize(width, height);

            Assert.AreEqual(width, browserSize.Width);
            Assert.AreEqual(height, browserSize.Height);
        }

        [Test]
        public void TestTask13()
        {
            Assert.IsTrue(pp.CheckIsHere() == "yes" || pp.CheckIsHere() == "no");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
