using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Tests
{
    class HomePageTests : BaseTestHomework
    {
    

   
        [Test]
        public void ChangeLanguagePOM()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            homePage.ChangeLanguage();
            Assert.IsTrue(homePage.expMsgChangeLanguageToEN());
        }
    }
}
