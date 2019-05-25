using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class AdminLoginPage:BasePage
    {

        [FindsBy(How = How.XPath, Using = "//input[@id='UserUsername']")]
        protected IWebElement AdminUserNameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='UserPassword']")]
        protected IWebElement AdminPasswordField;


        [FindsBy(How = How.XPath, Using = "//button[@name='submitbutton']")]
        protected IWebElement LogInSubmitButton;

        public AdminLoginPage(IWebDriver driver) : base(driver)
        {
        }
        public AdminDashboardPage LogInAsAdmin()
        {
            AdminUserNameField.Clear();
            AdminUserNameField.SendKeys(adminUserName);
            AdminPasswordField.Clear();
            AdminPasswordField.SendKeys(adminPassword);
            LogInSubmitButton.Click();
            return new AdminDashboardPage(webDriver);
        }

    }
}
