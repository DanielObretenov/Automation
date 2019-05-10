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
    class ToursFilterTest : BaseTestHomework
    {
        [Test]
        public void CorrectDestinationPOM()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            homePage.NavigateToToursTab();
            homePage.SelectRandomCityInToursTab();
            homePage.SelectRandomAdultsinTourTab();
            homePage.SelectRandomTourTypeinTourTab();
            ToursPage tourPage = homePage.ClickSearchForTourButton();
            Assert.IsTrue(tourPage.visibleFilter());
        }
    }
}
