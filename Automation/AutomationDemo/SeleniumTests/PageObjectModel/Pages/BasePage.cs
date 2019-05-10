using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Pages
{
    class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        protected static readonly By PageTitle = By.XPath("//h1");

        protected IWebDriver webDriver { get; }


        //summary
        //Web driver used on all Pages
        //summary
    }
}
