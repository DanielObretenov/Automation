using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class HotelPage : BasePage
    {

        private static readonly By AvailableRooms = By.CssSelector("#ROOMS tr");
        private static readonly By LastRoomInList = By.CssSelector("#ROOMS tr:first-child");
        private static readonly By AvailableRoomsPrices = By.CssSelector("#ROOMS tr h2.book_price");
        private static readonly By DetailsSection = By.CssSelector("div.col-md-12.go-left div.row");
        private static readonly By BookButton = By.CssSelector("button.book_button");
        private static readonly By Desctiption = By.CssSelector("div.panel-body div.visible-lg");
        private static readonly By ControlIndicator = By.CssSelector("div.control__indicator");
        private IList<IWebElement> listOfRoomPrices;
        private IList<IWebElement> roomCheckBoxes;
        private bool FeaturedHotelsHavePrices;
        private int[] priceOptions;
        private Actions action;
        public HotelPage(IWebDriver webDriver):base(webDriver)
        {

        }

        public BookHotelRoomPage BookRoomWithLowestPrice()
        {
            JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(Desctiption), this.webDriver);
            JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(LastRoomInList), this.webDriver);
            Wait.ClickableElement(webDriver, webDriver.FindElement(LastRoomInList));
            listOfRoomPrices = webDriver.FindElements(AvailableRoomsPrices).ToList();

            if (HasRooms())
            {
                roomCheckBoxes = webDriver.FindElements(ControlIndicator);
                int minPriceIndex = Array.IndexOf(priceOptions, priceOptions.Min());
                action.MoveToElement(roomCheckBoxes[minPriceIndex]).Perform();
                roomCheckBoxes[minPriceIndex].Click();
                webDriver.FindElement(BookButton).Click();
            }

            return new BookHotelRoomPage(webDriver);

        }
        public void WaitUntilPageLoads()
        {
            Wait.VisibilityOfElement(webDriver, DetailsSection);
        }


        public bool HasRooms()
        {
            FeaturedHotelsHavePrices = false;

            if(listOfRoomPrices.Count>0)
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

    }
}
