using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
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
        public HotelPage(IWebDriver webDriver):base(webDriver)
        {

        }

        public void BookRoomWithLowestPrice()
        {
            JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(Desctiption), this.webDriver);
            JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(LastRoomInList), this.webDriver);
            Wait.ClickableElement(webDriver, webDriver.FindElement(LastRoomInList));



            IList<IWebElement> listOfRoomPrices = webDriver.FindElements(AvailableRoomsPrices).ToList();
            foreach (var item in listOfRoomPrices)
            {
                Console.WriteLine(item.Text);
            }
        }
        public void WaitUntilPageLoads()
        {
            Wait.VisibilityOfElement(webDriver, DetailsSection);
        }

    }
}
