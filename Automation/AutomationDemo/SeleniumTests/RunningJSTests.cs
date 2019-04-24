using AutomationDemo.SeleniumTests;
using AutomationDemo.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests
{
    [TestFixture]
    class RunningJSTests : BaseTest
    {
        [Test]
        public void ScrollIntoViewTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("Large & Deep DOM")).Click();
            IWebElement table = driver.FindElement(By.Id("large-table"));

            RunJS("arguments[0].scrollIntoView(true)", table);
           // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", table);
            Thread.Sleep(2000);

        }

        [Test]
        public void ScrollWithOffSetTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("Large & Deep DOM")).Click();
            IWebElement table = driver.FindElement(By.Id("large-table"));
            int x = table.Location.X;
            int y = table.Location.Y;

            RunJS("window.scrollTo("+ x+ ", " + y +")");

            //  ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo("+ x+ "," + y +")");
            Thread.Sleep(2000);

        }

       
    }
}
