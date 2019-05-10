using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
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
            new DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();

            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();


            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
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
