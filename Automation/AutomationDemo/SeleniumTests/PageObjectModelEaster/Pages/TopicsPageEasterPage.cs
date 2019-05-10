using AutomationDemo.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.Pages
{
    class TopicsPageEasterPage:BasePageEaster
    {
        private static readonly By EasterGame = By.CssSelector("span.field-content a[href='/word-games/easter']");
        public TopicsPageEasterPage(IWebDriver webDriver) :base( webDriver)
        {

        }

        public WordGamesEasterPage NavigateToEasterGame()
        {
            Wait.VisibilityOfElement(webDriver, EasterGame);
            webDriver.FindElement(EasterGame).Click();
            return new WordGamesEasterPage(webDriver);
        }
    }
}
