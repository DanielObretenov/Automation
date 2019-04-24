using AutomationDemo.SeleniumTests;
using AutomationDemo;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutomationDemo.Helpers;

namespace AutomationDemo.SeleniumTests
{
    [TestFixture]
    public class WaitingTests : BaseTest
    {
        [Test]
        public void WaitTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("Dynamic Controls")).Click();
            driver.FindElement(By.XPath("//button[text()='Remove']")).Click();
            int start = DateTime.Now.Second;
            Wait.InvisibilityOfElement(driver, By.Id("checkbox"));
            int end = DateTime.Now.Second;
            Console.WriteLine(end - start);

        }

    }
}
