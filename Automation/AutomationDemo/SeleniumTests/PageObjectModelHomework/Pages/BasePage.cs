using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class BasePage
    {
        protected IWebDriver webDriver { get; }
      

        [FindsBy(How = How.CssSelector, Using = "#cookyGotItBtn")]
        protected IWebElement cookieButtonGotIt;
        [FindsBy(How = How.CssSelector, Using = "[href = 'https://www.phptravels.net/']")]
        protected IWebElement homePageButtonNav;
        protected static string HomePageUrl = ConfigurationManager.AppSettings["URL"];


        public BasePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
            // int random ;
        }


    }
}
