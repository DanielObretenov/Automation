using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PracticalTaskSeleniumProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class HomePage : BasePage
    {
        [FindsBy(How = How.XPath,Using = "//a[@href='/users/admin_login/']")]
        protected IWebElement LogInAdminButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(homePage);
        }

        public AdminLoginPage NavigateToAdminLogInPage()
        {
            Wait.WaitUntilClickable(webDriver, LogInAdminButton);
            LogInAdminButton.Click();
            return new AdminLoginPage(webDriver);
        }
    }
}
