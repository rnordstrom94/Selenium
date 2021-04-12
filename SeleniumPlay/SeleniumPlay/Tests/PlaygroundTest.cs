using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPlay.PageObjects;
using System.Collections.Generic;
using System.Drawing;

namespace SeleniumPlay.Tests
{
    [TestFixture]
    class PlaygroundTest
    {
        private IWebDriver driver;
        private PlaygroundPage pp;
        private const string ResultOK = "OK";
        private const string ResultNotOK = "NOT OK";

        [SetUp]
        public void Initialize()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.Host = "::1";

            driver = new FirefoxDriver(service);
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
            Assert.IsFalse(string.IsNullOrEmpty(pp.FindRedBoxClass()));
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
            string boxOnTop = pp.BoxOnTop();

            Assert.IsTrue(boxOnTop == "green" || boxOnTop == "orange");
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
            string isHere = pp.CheckIsHere();

            Assert.IsTrue(isHere == "yes" || isHere == "no");
        }

        [Test]
        public void TestTask14()
        {
            string boxVisible = pp.CheckPurpleBox();

            Assert.IsTrue(boxVisible == "yes" || boxVisible == "no");
        }

        [Test]
        public void TestTask15And16()
        {
            pp.ClickThenWait();
        }

        [Test]
        public void TestTask17()
        {
            pp.ClickSubmit();
        }

        [Test]
        public void TestCheckResults()
        {
            List<string> results = pp.CheckResults();

            foreach (string r in results)
            {
                Assert.AreEqual(ResultNotOK, r);
            }
        }

        [Test]
        public void TestAll()
        {
            pp.FillTitleAnswerSlot();
            pp.FillNameSlot("Kilgore Trout");
            pp.SetOccupation("Science Fiction Author");
            pp.CountBlueBoxes();
            pp.ClickLink("click me");
            pp.FindRedBoxClass();
            pp.ExecuteJavaScriptNoReturn();
            pp.ExecuteJavaScriptReturn();
            pp.SelectRadioButton("Wrote Book");
            pp.RedBoxText();
            pp.BoxOnTop();
            pp.SetBrowserSize(850, 650);
            pp.CheckIsHere();
            pp.CheckPurpleBox();
            pp.ClickThenWait();
            pp.ClickSubmit();

            List<string> results = pp.CheckResults();

            Assert.AreEqual(17, results.Count);

            foreach (string r in results)
            {
                Assert.AreEqual(ResultOK, r);
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
