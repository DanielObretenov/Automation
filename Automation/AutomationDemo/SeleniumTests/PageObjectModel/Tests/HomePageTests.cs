using AutomationDemo.SeleniumTests.PageObjectModel.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Tests
{
    class HomePageTests : BaseTest
    {
        [Test]
        public void VerifyHomePageLoaded()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            Assert.IsTrue(homePage.IsTitleCorrect());
        }

        [Test]
        public void VerifyOurPassionTitle()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            OurPassionPage ourPassionPage = homePage.NavigateToOurPassionPage();
            Assert.IsTrue(ourPassionPage.isOurPassionCorrectTitle());
        }
    }
}
