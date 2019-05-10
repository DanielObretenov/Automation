using AutomationDemo.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Pages
{
    class HomePage : BasePage
    {
        private static string pageUrl = "http://www.practiceselenium.com";

        private static string expectedPagetitle = "We're passionate about tea. ";

        private static readonly By OurPassion = By.XPath("//a[@href='our-passion.html']");

        private static readonly By Menu = By.XPath("//ul//a[@href='menu.html']");

        private static readonly By LetsTalkTea = By.XPath("//a[@href='let-s-talk-tea.html']");

        private static readonly By CheckOut = By.XPath("//a[@href='check-out.html']");

        

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(pageUrl);
        }
        public bool IsTitleCorrect()
        {
            return webDriver.FindElement(PageTitle).Text.Equals(expectedPagetitle);
        }

        public OurPassionPage NavigateToOurPassionPage()
        {
            webDriver.FindElement(OurPassion).Click();
            return new OurPassionPage(webDriver);
        }
        public MenuPage NavigateToMenuPage()
        {
            webDriver.FindElement(Menu).Click();
            return new MenuPage(webDriver);
        }

        public LetsTalkTeaPage NavigateToLetsTalkTeaPage()
        {
            Wait.ClickableElement(webDriver, webDriver.FindElement(OurPassion));
            webDriver.FindElement(LetsTalkTea).Click();
            return new LetsTalkTeaPage(webDriver);
        }

    }
}
