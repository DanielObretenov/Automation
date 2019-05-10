using AutomationDemo.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.Pages
{
    class HomePageEaster : BasePageEaster
    {
        private string urlHome = "https://learnenglishkids.britishcouncil.org/";
        private static readonly By aToZTopics = By.XPath("//div[@id='block-views-topics-block-1']");
        private static readonly By letterETopics = By.XPath("//a[@href='/glossary/resourse/e']");
        private static readonly By easterGameTopics = By.XPath("//*[@id='block-views-topics-block-1']//a[text() = 'Easter']");


        public HomePageEaster(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(urlHome);
        }

        public TopicsPageEasterPage NavigateToEasterTopicFromAZTopics()
        {
            //action.MoveToElement(webDriver.FindElement(letterETopics)).Perform();
            Wait.VisibilityOfElement(webDriver, cookieBannerBox);
            webDriver.FindElement(cookieBanner).Click();
            webDriver.SwitchTo().DefaultContent();
            webDriver.FindElement(letterETopics).Click();
            Wait.VisibilityOfElement(webDriver, easterGameTopics);
            webDriver.FindElement(easterGameTopics).Click();
            return new TopicsPageEasterPage(webDriver);
        }

    }
}
