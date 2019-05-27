using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void SetDriver()
        {
            InitializeBrowser();
            driver.Manage().Window.Maximize();
        }

        public void InitializeBrowser()
        {
            switch (ConfigurationManager.AppSettings["Browser"])
            {
                case "Chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver();
                    break;
            }
        }

        [OneTimeTearDown]
        public void TakeScreenshotAndQuit()
        {
            if (TestContext.CurrentContext.Result.Outcome !=
                NUnit.Framework.Interfaces.ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotFileName = TestContext.CurrentContext.Test.FullName;
                screenshot.SaveAsFile(@"D:\" + screenshotFileName + ".png");
            }
            driver.Dispose();
        }

    }
}
