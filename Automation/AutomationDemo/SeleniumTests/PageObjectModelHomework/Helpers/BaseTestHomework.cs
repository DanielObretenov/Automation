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

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster
{
    public class BaseTestHomework
    {

        public IWebDriver driver;


        [SetUp]
        public void SetDriver()
        {
            InitializeBrowser();



            driver.Manage().Window.Maximize();

            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
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
        public void QuitDriver()
        {
            driver.Dispose();
        }




        [TearDown]
        public void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome !=
                NUnit.Framework.Interfaces.ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotFileName = TestContext.CurrentContext.Test.FullName;
                screenshot.SaveAsFile(@"D:\" + screenshotFileName + ".png");
            }
        }
    }
}
