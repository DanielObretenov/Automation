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
    class FeaturedToursPage : BasePage
    {
        private static readonly By MapVisibilityFrame = By.CssSelector("div.fotorama__stage");
        private static string mapFrame = "mapframe";
        private static readonly By MapError = By.XPath("//div[@class='gm-err-title']");
        private static readonly By PhotoSlider = By.CssSelector("div.fotorama__nav.fotorama__nav--thumbs");
        private static readonly By SharedButtons = By.CssSelector("[class^='st-label']");
        private static readonly By PriceBox = By.XPath("//h4[@class='well well-sm text-center strong']");
        private static readonly By ActPrice = By.CssSelector("h4.well-sm.text-center strong");
        private double actPrice =0;
        public FeaturedToursPage(IWebDriver webDriver):base(webDriver)
        {

            
        }

        public void DisplayMapErrorMessage()
        {

            Wait.VisibilityOfElement(webDriver, MapVisibilityFrame);
            webDriver.SwitchTo().Frame(mapFrame);
            Console.WriteLine(webDriver.FindElement(MapError).Text);
            webDriver.SwitchTo().DefaultContent();
            
        }

        public void ClickAndCloseRandomShareButton()
        {
            Wait.InvisibilityOfElement(webDriver, PhotoSlider);
            IList<IWebElement> shareButtonsList = webDriver.FindElements(SharedButtons);
            random = rnd.Next(shareButtonsList.Count);
            shareButtonsList[random].Click();
            //driver.FindElement(By.XPath("//div[@data-network='linkedin']"));
            List<string> allWindows = webDriver.WindowHandles.ToList();
            webDriver.SwitchTo().Window(allWindows[1]);
            webDriver.Close();
            webDriver.SwitchTo().Window(allWindows[0]);
           
        }
        public void GetPriceBox()
        {
         
            RunningJSTests runJS = new RunningJSTests();
            runJS.RunJS("arguments[0].scrollIntoView(true)", webDriver.FindElement(PriceBox));
            bool convertPriece = double.TryParse(webDriver.FindElement(ActPrice).Text, out actPrice);
        }

        public bool IsPriceCorrect()
        {
            HomePage homePage = new HomePage(webDriver);
            return webDriver.FindElement(PriceBox).Text.Equals((homePage.MinPriceRoom).ToString());
            
        }
    }
}
