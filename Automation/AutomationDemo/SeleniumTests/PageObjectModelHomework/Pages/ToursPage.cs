using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class ToursPage : BasePage
    {
        //private static readonly By FilterInTours = By.CssSelector("div.filter");

        [FindsBy(How = How.CssSelector, Using = "div.filter")]
        protected IWebElement FilterInTours;

        
        public ToursPage(IWebDriver webDriver): base(webDriver)
        {

        }

        public bool visibleFilter()
        {
            return FilterInTours.Displayed;
        }
    }
}
