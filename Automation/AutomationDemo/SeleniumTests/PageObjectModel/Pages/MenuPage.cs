using AutomationDemo.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Pages
{
    class MenuPage : BasePage
    {
        private static string expectedTitle = "Menu";
        private static readonly By CheckOutButtons = By.XPath("//*[@class='button-content wsb-button-content']");
        public MenuPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public bool isMenuPageLoaded()
        {
            Wait.VisibilityOfElement(webDriver, PageTitle);
            return webDriver.FindElement(PageTitle).Text.Equals(expectedTitle);
        }
        public CheckOutPage ClickOnTeaButton()
        {
            IList<IWebElement> TeaButtons = webDriver.FindElements(CheckOutButtons);
            TeaButtons[1].Click();
            return new CheckOutPage(webDriver);
        }
    }
}
