using AutomationDemo.SeleniumTests.PageObjectModel.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Tests
{
    class CheckOutTests : BaseTest
    {
        [Test]
        public void VerifyCheckOut()
        {
            
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            MenuPage menuPage = homePage.NavigateToMenuPage();
            CheckOutPage checkOutPage = menuPage.ClickOnTeaButton();
            checkOutPage.FillingForm();
            checkOutPage.PlaceOrder();
            Assert.IsTrue(menuPage.isMenuPageLoaded());
        }

    }
}
