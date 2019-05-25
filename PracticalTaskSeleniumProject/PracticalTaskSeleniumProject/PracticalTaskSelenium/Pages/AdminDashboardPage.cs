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
    class AdminDashboardPage:BasePage
    {

        [FindsBy(How = How.XPath, Using = "//div[@id='pageContent']//a[@href='/contents/admin/']")]
        protected IWebElement CategoriesProductButton;


        public AdminDashboardPage(IWebDriver driver) : base(driver)
        {
          
        }

        public AdminAllCategoriesPage NavigateToAllCategoriesPage()
        {
            Wait.WaitUntilClickable(webDriver, CategoriesProductButton);
            CategoriesProductButton.Click();
            return new AdminAllCategoriesPage(webDriver);
        }
    }
}
