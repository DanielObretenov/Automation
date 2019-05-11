using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Tests
{
    class HotelTests : BaseTestHomework
    {

        [Test]
        public void AddToWishlistMessage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
          //  HotelPage hotelPage =  homePage.FeaturedHoteWithLowestPrice();
            HotelPage hotelPage =  homePage.NavigateToAHotelWithRooms();
            hotelPage.ScrolltoAddToWishListButton();
            hotelPage.ClicktoAddToWishListButton();
            Assert.IsTrue(hotelPage.IsWishListMsgCorrect());
        }
        [Test]
        public void CheckAvailabilityCalender()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            //  HotelPage hotelPage =  homePage.FeaturedHoteWithLowestPrice();
            HotelPage hotelPage = homePage.NavigateToAHotelWithRooms();
            hotelPage.NavigateToRoomsSection();
            hotelPage.ClickOnLastRoomAvailability();

        }
    }
}
