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

namespace AutomationDemo
{
    [TestFixture]
    public class AdvancedSeleniumTests : BaseTest
    {
        [Test]

        public void HandleAlerts()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            driver.FindElement(By.LinkText("JavaScript Alerts")).Click();

            driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();
            Assert.AreEqual("I am a JS Alert", GetAlertText());
            HandleAlert(true);

            driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']")).Click();
            Assert.AreEqual("I am a JS Confirm", GetAlertText());
            HandleAlert(false);
            
            driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']")).Click();
            Assert.AreEqual("I am a JS prompt", GetAlertText());
            EnterTextToAlert("There comes the boom");
            HandleAlert(true);
        }

        [Test]
        public void HandleNewBrowserWindow()
        {
            driver.Navigate().GoToUrl("https://www.toolsqa.com/automation-practice-switch-windows/");
            driver.FindElement(By.Id("button1")).Click();
            List<string> allWindows = driver.WindowHandles.ToList();
            foreach (var window in allWindows)
            {
                Console.WriteLine(window);
            }
            driver.SwitchTo().Window(allWindows[1]);
            Wait.VisibilityOfElement(driver, By.ClassName("dt-mobile-menu-icon"));
            driver.FindElement(By.ClassName("dt-mobile-menu-icon")).Click();
        }
        [Test]
        public void HanleMsgWindow()
        {
            driver.Navigate().GoToUrl("https://www.toolsqa.com/automation-practice-switch-windows/");
            driver.FindElement(By.XPath("//button[text()='New Message Window']")).Click();
            List<string> allWindows = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(allWindows[1]);
        }

        [Test]
        public void HanleNewBrowserTab()
        {
            driver.Navigate().GoToUrl("https://www.toolsqa.com/automation-practice-switch-windows/");
            driver.FindElement(By.XPath("//button[text()='New Browser Tab']")).Click();
            List<string> allTabs = driver.WindowHandles.ToList();

            foreach (var tab in allTabs)
            {
                Console.WriteLine(tab);
            }
            Console.WriteLine(driver.Title);
            driver.SwitchTo().Window(allTabs[1]);
            Console.WriteLine(driver.Title);
            driver.Close();
            driver.SwitchTo().Window(allTabs[0]);
            Console.WriteLine(driver.Title);
        }



    }
}
