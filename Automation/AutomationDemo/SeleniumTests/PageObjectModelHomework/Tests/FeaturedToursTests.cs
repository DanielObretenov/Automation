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
    class FeaturedToursTests : BaseTestHomework
    {
        [Test]
        public void PricesAndSharebuttons()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            FeaturedToursPage lowestPriceFeaturedTour = homePage.NavigateToFeaturedToursPageWithLowestPrice();
            lowestPriceFeaturedTour.DisplayMapErrorMessage();
            lowestPriceFeaturedTour.ClickAndCloseRandomShareButton();
            lowestPriceFeaturedTour.GetPriceBox();
            Assert.IsTrue(lowestPriceFeaturedTour.IsPriceCorrect());
        }
    }
}
