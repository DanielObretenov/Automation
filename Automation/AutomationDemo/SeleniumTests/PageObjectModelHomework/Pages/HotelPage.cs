using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class HotelPage : BasePage
    {

        //private static readonly By AvailableRooms = By.CssSelector("#ROOMS tr");
        //private static readonly By LastRoomInList = By.CssSelector("#ROOMS tr:first-child");
        //private static readonly By AvailableRoomsPrices = By.CssSelector("#ROOMS tr h2.book_price");
        //private static readonly By DetailsSection = By.CssSelector("div.col-md-12.go-left div.row");
        //private static readonly By BookButton = By.CssSelector("button.book_button");
        //private static readonly By Desctiption = By.CssSelector("div.panel-body div.visible-lg");
        //private static readonly By ControlIndicator = By.CssSelector("div.control__indicator");
        private IList<IWebElement> listOfRoomPrices;
        private IList<IWebElement> roomCheckBoxes;
        private bool FeaturedHotelsHavePrices;
        private int[] priceOptions;
        private Actions action;
        private string ActAlertMsg;
        private string expMsg = "Please Login to add to wishlist.";


        [FindsBy(How = How.CssSelector, Using = "#ROOMS tr")]
        protected IWebElement AvailableRooms;

        [FindsBy(How = How.CssSelector, Using = "#ROOMS tr:first-child")]
        protected IWebElement LastRoomInList;

        [FindsBy(How = How.CssSelector, Using = "#ROOMS tr h2.book_price")]
        protected IList<IWebElement> AvailableRoomsPrices;


        [FindsBy(How = How.CssSelector, Using = "div.col-md-12.go-left div.row")]
        protected IWebElement DetailsSection;

        [FindsBy(How = How.CssSelector, Using = "button.book_button")]
        protected IWebElement BookButton;

        [FindsBy(How = How.CssSelector, Using = "div.panel-body div.visible-lg")]
        protected IWebElement Desctiption;

        [FindsBy(How = How.CssSelector, Using = "div.control__indicator")]
        protected IList<IWebElement> ControlIndicator;

        [FindsBy(How = How.CssSelector, Using = "span.btn.addwishlist")]
        protected IWebElement WishListButton;



        [FindsBy(How = How.CssSelector, Using = "[href='#tours']")]
        protected IWebElement TourTab;

        public HotelPage(IWebDriver webDriver):base(webDriver)
        {

        }

        public BookHotelRoomPage BookRoomWithLowestPrice()
        {

            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", (Desctiption), this.webDriver);
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", (LastRoomInList), this.webDriver);
            Wait.ClickableElement(webDriver, (LastRoomInList));
            listOfRoomPrices = (AvailableRoomsPrices).ToList();

            if (HasRooms())
            {
                action = new Actions(this.webDriver);
                int minPriceIndex = Array.IndexOf(priceOptions, priceOptions.Min());
                action.MoveToElement(ControlIndicator[minPriceIndex]).Perform();
                ControlIndicator[minPriceIndex].Click();
                (BookButton).Click();
            }

            return new BookHotelRoomPage(webDriver);

        }
        public void WaitUntilPageLoads()
        {
            Wait.ClickableElement(webDriver, DetailsSection);
        }


        public bool HasRooms()
        {
            FeaturedHotelsHavePrices = false;
            priceOptions = new int[listOfRoomPrices.Count];

            if (listOfRoomPrices.Count>0)
            {
                for (int i = 0; i < listOfRoomPrices.Count; i++)
                {
                    Wait.ClickableElement(webDriver, listOfRoomPrices[i]);
                    priceOptions[i] = int.Parse(listOfRoomPrices[i].Text.Replace("USD $", ""));
                }
                FeaturedHotelsHavePrices = true;
            }

            return FeaturedHotelsHavePrices;
        }

        public void ScrolltoAddToWishListButton()
        {
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", WishListButton, webDriver);
        }
        public void ClicktoAddToWishListButton()
        {
            WishListButton.Click();
        }
        public void DismissAlert()
        {
            Alerts.HandleAlert(true, webDriver);
        }
        public bool IsWishListMshCorrect()
        {
            string ActAlertMsg = Alerts.GetAlertText(webDriver);
            return ActAlertMsg.Equals(expMsg);
        }
    }
}
