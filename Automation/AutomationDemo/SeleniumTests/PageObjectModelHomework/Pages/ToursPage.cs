using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class ToursPage : BasePage
    {
        private static readonly By FilterInTours = By.CssSelector("div.filter");
        public ToursPage(IWebDriver webDriver): base(webDriver)
        {

        }

        public bool visibleFilter()
        {
            return webDriver.FindElement(FilterInTours).Displayed;
        }
    }
}
