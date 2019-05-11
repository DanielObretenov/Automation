using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class FeaturedToursPage : BasePage
    {
        //private static readonly By MapVisibilityFrame = By.CssSelector("div.fotorama__stage");
        //private static readonly By MapError = By.XPath("//div[@class='gm-err-title']");

        //private static readonly By SharedButtons = By.CssSelector("[class^='st-label']");
        //private static readonly By PriceBox = By.XPath("//h4[@class='well well-sm text-center strong']");
        //private static readonly By ActPrice = By.CssSelector("h4.well-sm.text-center strong");
        //[FindsBy(How = How.CssSelector, Using = "[class^='st-label']")]
        //protected IWebElement PhotoSlider;

        private static string mapFrame = "mapframe";
        private static readonly By PhotoSlider = By.CssSelector("div.fotorama__nav.fotorama__nav--thumbs");
        private int actPrice = 0;
        protected int random = 0;
        protected static Random rnd = new Random();

        [FindsBy(How = How.CssSelector, Using = "div.fotorama__stage")]
        protected IWebElement MapVisibilityFrame;

        [FindsBy(How = How.XPath, Using = "//div[@class='gm-err-title']")]
        protected IWebElement MapError;
       
        [FindsBy(How = How.CssSelector, Using = "#st-1 div")]
        protected IList<IWebElement> SharedButtons;

        [FindsBy(How = How.XPath, Using = "//span[@class='totalCost']")]
        protected IWebElement PriceBox;

        [FindsBy(How = How.CssSelector, Using = "h4.well-sm.text-center strong")]
        protected IWebElement ActPrice;

    

        

        public FeaturedToursPage(IWebDriver webDriver):base(webDriver)
        {

            
        }

        public void SwitchToFrame()
        {
            webDriver.SwitchTo().Frame(mapFrame);
        }
        public void DisplayMapErrorMessage()
        {

            Wait.ClickableElement(webDriver, MapVisibilityFrame);
            Console.WriteLine(MapError.Text);
            webDriver.SwitchTo().DefaultContent();
            
        }

        public void ClickOnARandomShareButton()
        {
            Wait.InvisibilityOfElement(webDriver, PhotoSlider);
            random = rnd.Next(SharedButtons.Count);
            SharedButtons[random].Click();
        
           
        }
        public void CloseShareButton()
        {
            List<string> allWindows = webDriver.WindowHandles.ToList();
            webDriver.SwitchTo().Window(allWindows[1]);
            webDriver.Close();
            webDriver.SwitchTo().Window(allWindows[0]);
        }
        public void GetPriceBox()
        {
         
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", PriceBox, this.webDriver);
            bool convertPriece = int.TryParse(ActPrice.Text, out actPrice);
        }

        public int IsPriceCorrect()
        {

            int PriceInHotelPage = int.Parse(PriceBox.Text.Replace("USD $", "").ToString());

            return PriceInHotelPage;
            
        }
    }
}
