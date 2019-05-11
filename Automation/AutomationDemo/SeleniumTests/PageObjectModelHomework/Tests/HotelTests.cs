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
            HotelPage hotelPage =  homePage.NavigateToHotelPage();
            hotelPage.ScrolltoAddToWishListButton();
            hotelPage.ClicktoAddToWishListButton();
            Assert.IsTrue(hotelPage.IsWishListMshCorrect());
        }

    }
}
