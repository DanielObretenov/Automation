using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Pages
{
    class OurPassionPage : BasePage

    {
        private static string expectedPageTitle = "Our Passion";
        public OurPassionPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public bool isOurPassionCorrectTitle()
        {
            return webDriver.FindElement(PageTitle).Text.Equals(expectedPageTitle);
        }
    }
}
