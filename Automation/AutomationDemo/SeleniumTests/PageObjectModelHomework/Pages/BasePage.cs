using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class BasePage
    {
        protected IWebDriver webDriver { get; }
        protected int random { get; set; }
        protected static Random rnd = new Random();




        public BasePage(IWebDriver driver)
        {
            this.webDriver = driver;
            // int random ;
        }

        protected static readonly By cookieButtonGotIt = By.CssSelector("#cookyGotItBtn");
        protected static readonly By homePageButtonNav = By.CssSelector("[href='https://www.phptravels.net/']");


    }
}
