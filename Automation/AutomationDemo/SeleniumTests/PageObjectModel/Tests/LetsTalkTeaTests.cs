using AutomationDemo.SeleniumTests.PageObjectModel.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Tests
{
    class LetsTalkTeaTests : BaseTest
    {
        [Test]
        public void FillingForm()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            LetsTalkTeaPage letsTalkTeaPage = homePage.NavigateToLetsTalkTeaPage();
            letsTalkTeaPage.FillinForm();
            letsTalkTeaPage.ClickSubmit();
            //assertion
        }
    }
}
