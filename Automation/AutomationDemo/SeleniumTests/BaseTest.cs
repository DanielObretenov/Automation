using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationDemo.SeleniumTests
{
    public class BaseTest
    {
        public IWebDriver driver;
        public IAlert alert;

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
            if (TestContext.CurrentContext.Result.Outcome!= 
                NUnit.Framework.Interfaces.ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotFileName = TestContext.CurrentContext.Test.FullName;
                screenshot.SaveAsFile(@"D:\"+screenshotFileName+".png");
            }
        }


        public string GetAlertText()
        {
            alert = driver.SwitchTo().Alert();

            return alert.Text;
        }

        public void HandleAlert(bool accept)
        {
            alert = driver.SwitchTo().Alert();
            if (accept)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
        }

        public void EnterTextToAlert(string text)
        {
            alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
        }

        public void RunJS(string script)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
        public void RunJS(string script, IWebElement el)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script, el);
        }

    }
}
