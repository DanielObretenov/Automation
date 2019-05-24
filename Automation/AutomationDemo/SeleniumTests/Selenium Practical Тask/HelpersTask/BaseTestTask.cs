using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationDemo.SeleniumTests.Selenium_Practical_Тask.HelpersTask
{
    public class BaseTestTask
    {
        public IWebDriver driver;

        [SetUp]
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
        [TearDown]
        public void TakeScreenShotAndQuitBrowser()
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
