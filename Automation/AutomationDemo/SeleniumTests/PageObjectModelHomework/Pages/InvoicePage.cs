using AutomationDemo.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class InvoicePage : BasePage
    {
        private static readonly By invoiceTable = By.CssSelector("#invoiceTable");
        public InvoicePage(IWebDriver webDriver) : base(webDriver)
        {


        }

        public void WaitForBookHotelRoomPageToLoad()
        {
            Wait.VisibilityOfElement(webDriver, invoiceTable);
        }

        public bool InVoiceSectionVisibility()
        {
          return  webDriver.FindElement(invoiceTable).Displayed;
        }

    }
}
