using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo
{
    class TodoListMePage : BaseTest
    {

        string url = "http://todolistme.net/";
        public static readonly By addListButton = By.XPath("//img[@id='addlist']");
        public static readonly By textFieldNewList = By.XPath("//form/input[@type='text']");
        public static readonly By SubmitNewList = By.XPath("//*[@type='submit']");
        public static readonly By EnterActivity = By.XPath("//input[@id='newtodo']");

        public static readonly By ActivityItem = By.XPath("//span[@id='mytodo_0']");
        public static readonly By TomorrowSection = By.XPath("//h3[@id='tomorrowtitle']");

        string newListName = "TestList";
        string firstActivity = "firstActivity";
        Actions action;
        public void NavigateToURL()
        {
            driver.Navigate().GoToUrl(url);
        }
        public void AddList()
        {
            Wait.ClickableElement(driver, driver.FindElement(addListButton));
            driver.FindElement(addListButton).Click();
            driver.FindElement(textFieldNewList).SendKeys(newListName);
            driver.FindElement(SubmitNewList).Click();

           // driver.FindElement(textFieldNewList).SendKeys(newListName+Keys.Enter);

        }
        public void AddActivity()
        {
            driver.FindElement(EnterActivity).Clear();
            driver.FindElement(EnterActivity).SendKeys(firstActivity + Keys.Enter);
        }

        public void DragAndDropItemForTomorrow()
        {
            action = new Actions(driver);
            action.DragAndDrop(driver.FindElement(ActivityItem), driver.FindElement(TomorrowSection)).Perform();
        }

        [Test]
        public void AddActivityinNewList()
        {
            NavigateToURL();
            AddList();
            AddActivity();
            DragAndDropItemForTomorrow();
        }

    }
}
