using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class BasePage
    {
        protected IWebDriver webDriver { get; }

        protected string homePage = ConfigurationManager.AppSettings["URL"];
        protected string adminUserName = "admin";
        protected string adminPassword = "password";
        public BasePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

    }
}
