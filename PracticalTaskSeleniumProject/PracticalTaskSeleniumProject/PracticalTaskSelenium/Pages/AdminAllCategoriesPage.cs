using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using PracticalTaskSeleniumProject.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class AdminAllCategoriesPage:BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create')]")]
        protected IWebElement CreateNewButton;

        public AdminAllCategoriesPage(IWebDriver driver) : base(driver)
        {

        }
        public AdminCreateOrEditProductPage clickOnCreateNewButton()
        {
            Wait.WaitUntilClickable(webDriver, CreateNewButton);
            CreateNewButton.Click();
            return new AdminCreateOrEditProductPage(webDriver);
        }
    }
}
