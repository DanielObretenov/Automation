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
    class BookARoomFormTests : BaseTestHomework
    {
        [Test]
        public void FeaturedHotelsBookARoomPOM()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            HotelPage hotelPage = homePage.FeaturedHoteWithLowestPrice();
            hotelPage.WaitUntilPageLoads();
            BookHotelRoomPage bookHotelRoomPage = hotelPage.BookRoomWithLowestPrice();
            bookHotelRoomPage.WaitForBookHotelRoomPageToLoad();
            InvoicePage invoicePage = bookHotelRoomPage.FillOutForm();
            invoicePage.WaitForBookHotelRoomPageToLoad();
            Assert.IsTrue(invoicePage.InVoiceSectionVisibility());
           
        }

    }
}
