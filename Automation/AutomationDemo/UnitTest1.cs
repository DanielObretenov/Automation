using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AutomationTest
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void SetDriver()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
        }
        [Test]
        [Category("SimpleTests")]

        [TestCase("https://www.abv.bg")]
        [TestCase("https://www.chess.com/")]
        [TestCase("https://www.sportal.bg")]
        [TestCase("https://www.youtube.com")]
        [TestCase("https://www.google.com")]

        public void LoadPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            Assert.IsTrue(driver.Url.Contains(url));

        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Dispose();
        }
    }

}
